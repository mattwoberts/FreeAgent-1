using FreeAgent.Helpers;
using FreeAgent.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Refit;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Linq;

namespace FreeAgent
{
    public class FreeAgentClient
    {
        public FreeAgentClient(bool useSandBox, string apiKey, string apiSecret, string refreshToken = null, HttpClient httpClient = null)
            : this(new Configuration() 
            {  
                ApplicationKey = apiKey, 
                ApplicationSecret = apiSecret, 
                UseSandbox = useSandBox,
                RefreshToken = refreshToken
            }, 
            httpClient)
        {
        }

        public FreeAgentClient(Configuration config, HttpClient httpClient = null)
        {
            // don't allow zero or negative auto refresh periods
            if (config.AutoRefreshMinutes <= 0)
            {
                config.AutoRefreshMinutes = 120;
            }

            this.Configuration = config;

            // set the json converter to handle the underscores in the names and the string/enum values 
            var refitSettings = new RefitSettings
            {
                JsonSerializerSettings = new JsonSerializerSettings
                {
                    ContractResolver = new SnakeCasePropertyNamesContractResolver(),
                    Converters = { new StringEnumConverter() }
                }
            };

            // set the httpclient base address and configure the client
            var rootUrl = this.Configuration.UseSandbox 
                            ? "https://api.sandbox.freeagent.com/v2" 
                            : "https://api.freeagent.com/v2";

            if (httpClient != null)
            {
                httpClient.BaseAddress = new Uri(rootUrl);
                this.FreeAgentApi = RestService.For<IFreeAgentApi>(httpClient, refitSettings);
            }
            else
            {
                this.FreeAgentApi = RestService.For<IFreeAgentApi>(rootUrl, refitSettings);
            }
        }

        internal async Task<TResult> GetOrCreateAsync<TResult,TWrapped>(Func<IFreeAgentApi, Task<TWrapped>> action, Func<TWrapped, TResult> returns)
        {
            //TODO - safety stuff here??
            TWrapped result = await this.Execute(action);
            return returns(result);
        }

        internal Task UpdateOrDeleteAsync(IUrl resource, Func<IFreeAgentApi, int, Task> action)
        {
            //TODO - safety stuff here??
            var id = this.ExtractId(resource);
            return this.Execute(c => action(c,id));
        }

        internal async Task Execute(Func<IFreeAgentApi, Task> action)
        {
            try
            {
                await RenewAccessIfRequired();
                await action(this.FreeAgentApi);
            }
            catch (FreeAgentException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new FreeAgentException("Error executing function, see inner exception", ex);
            }
        }

        internal async Task<T> Execute<T>(Func<IFreeAgentApi,Task<T>> action) 
        {
            try
            {
                await RenewAccessIfRequired();
                return await action(this.FreeAgentApi);
            }
            catch (FreeAgentException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new FreeAgentException("Error executing function, see inner exception", ex);
            }
        }

        public async Task RenewAccessIfRequired()
        {
            var tryRenewal = false;
            var currentDate = DateTime.UtcNow;

            if (!this.Configuration.CurrentTokenExpiry.HasValue)
            {
                tryRenewal = true;
            }
            if (this.Configuration.CurrentTokenExpiry.HasValue)
            {
                var timeToExpiry = this.Configuration.CurrentTokenExpiry.Value.Subtract(currentDate);
                if (timeToExpiry.TotalSeconds < this.Configuration.AutoRefreshMinutes)
                    tryRenewal = true;
            }

            if (!tryRenewal)
                return;

            // got to try renewing the token
            var request = new AccessRequest
            {
                 GrantType = AccessRequestType.refresh_token,
                 ClientId = this.Configuration.ApplicationKey,
                 ClientSecret = this.Configuration.ApplicationSecret,
                 RefreshToken = this.Configuration.RefreshToken
            };

            var response = await this.FreeAgentApi.RefreshAccessToken(request);

            this.Configuration.CurrentToken = response.AccessToken;
            this.Configuration.CurrentTokenExpiry = currentDate.AddSeconds(response.ExpiresIn);
        }

        internal Uri ExtractUrl(IUrl model)
        {
            if (model == null)
                throw new FreeAgentException("Cannot extract URL from null model");

            if (model.Url == null || model.Url.Segments.Length <= 0)
                throw new FreeAgentException("Model URL is null");

            return model.Url;
        }

        internal int ExtractId(IUrl model)
        {
            if (model == null)
                throw new FreeAgentException("Cannot extract ID from null model");

            return ExtractId(model.Url);
        }

        internal int ExtractId(Uri url)
        {
            if (url == null || url.Segments.Length <= 0)
                throw new FreeAgentException("Cannot extract ID from blank Url");

            var idVal = url.Segments.Last();

            int id = 0;

            if (!int.TryParse(idVal, out id))
                throw new FreeAgentException(string.Format("Cannot extract ID, expected an integer [{0}]", url.AbsoluteUri));

            return id;
        }

        public Configuration Configuration { get; private set;  }
        private IFreeAgentApi FreeAgentApi { get; set; }
    }
}
