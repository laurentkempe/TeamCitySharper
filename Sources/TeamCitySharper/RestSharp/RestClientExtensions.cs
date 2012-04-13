using System;
using System.Threading;
using System.Threading.Tasks;
using RestSharp;

namespace TeamCitySharper.RestSharp
{
    public static class RestClientExtensions
    {
        public static Task<TResult> GetAsync<TResult>(this RestClient client,
                                                         RestRequest request) where TResult : new()
        {
            var tcs = new TaskCompletionSource<TResult>();

            WaitCallback
                asyncWork = _ =>
                {
                    try
                    {
                        client.ExecuteAsync<TResult>(request,
                                                     response => tcs.SetResult(response.Data));
                    }
                    catch (Exception exc)
                    {
                        tcs.SetException(exc);
                    }
                };

            return GetAsync(asyncWork, tcs);
        }

        public static Task<TResult> GetAsync<T, TResult>(this RestClient client,
                                                            RestRequest request,
                                                            Func<T, TResult> adapter) where T : new()
        {
            var tcs = new TaskCompletionSource<TResult>();

            WaitCallback
                asyncWork = _ =>
                {
                    try
                    {
                        client.ExecuteAsync<T>(request,
                                               response =>
                                               tcs.SetResult(adapter.Invoke(response.Data)));
                    }
                    catch (Exception exc)
                    {
                        tcs.SetException(exc);
                    }
                };

            return GetAsync(asyncWork, tcs);
        }

        private static Task<TResult> GetAsync<TResult>(WaitCallback asyncWork,
            TaskCompletionSource<TResult> tcs)
        {
            ThreadPool.QueueUserWorkItem(asyncWork);

            return tcs.Task;
        }
    }
}