    public class WebExceptionCatcher<T, R> where T : Task<R>
    {      
        public async Task<R> runTask(Func<T> t)
        {
            int i = 0;
            Policy p = Policy.Handle<WebException>()
            .Or<MobileServiceInvalidOperationException>()
            .Or<HttpRequestException>()
            .RetryForeverAsync(onRetryAsync: async (e,i) => await RefreshAuthorization());
            return await p.ExecuteAsync<R>( async () => 
            {
                i++;
                if ((i % 5) == 0) Device.BeginInvokeOnMainThread(async () =>
                {
                     await DisplayAlert("Making retry "+ i, "whatever", "Ok");
                });
                await myTask;
            });
        }
    }
