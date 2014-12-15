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
        public FreeAgentClient(string apiKey, string apiSecret, bool useSandBox, HttpClient httpClient = null)
            : this(new Configuration() 
            {  
                ApplicationKey = apiKey, 
                ApplicationSecret = apiSecret, 
                UseSandbox = useSandBox
            }, httpClient)
        {
        }

        public FreeAgentClient(Configuration config, HttpClient httpClient = null)
        {
            this.Configuration = config;

            JsonConvert.DefaultSettings =
                () => new JsonSerializerSettings()
                {
                    ContractResolver = new SnakeCasePropertyNamesContractResolver(),
                    Converters = { new StringEnumConverter() }
                };

            var rootUrl = this.Configuration.UseSandbox ? "https://api.sandbox.freeagent.com/v2" : "https://api.freeagent.com/v2";

            if (httpClient != null)
            {
                httpClient.BaseAddress = new Uri(rootUrl);
                this.FreeAgentApi = RestService.For<IFreeAgentApi>(httpClient);
            }
            else
            {
                this.FreeAgentApi = RestService.For<IFreeAgentApi>(rootUrl);
            }
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

        internal async Task RenewAccessIfRequired()
        {
            var tryRenewal = false;
            var currentDate = DateTime.UtcNow; 

            if (!this.Configuration.CurrentTokenExpiry.HasValue)
                tryRenewal = true;

            if (this.Configuration.CurrentTokenExpiry.HasValue)
            {
                var timeToExpiry = this.Configuration.CurrentTokenExpiry.Value.Subtract(currentDate);
                if (timeToExpiry.TotalSeconds < 120)
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
