using System;
using System.Linq;
using System.Threading.Tasks;

namespace FreeAgent.Tests
{
    public static partial class Helper
    {
        public static Exception RecordException(Func<Task> action)
        {
            try
            {
                action().Wait();
                return null;
            }
            catch (Exception ex)
            {
                if (ex is AggregateException)
                    return ((AggregateException)ex).InnerExceptions.FirstOrDefault();

                return ex;
            }
        }
        
        public static Exception RecordException(Action action)
        {
            try
            {
                action();
                return null;
            }
            catch (Exception ex)
            {
                return ex;
            }
        }

    }

}
