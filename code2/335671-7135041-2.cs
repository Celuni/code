    static class WebClientEx {
        public static void DownloadSemiSync(this WebClient webClient, Uri address, string filename) {
            var evt = new AutoResetEvent(false);
            webClient.DownloadFileCompleted += (s, e) => evt.Set();
            webClient.DownloadFileAsync(address, filename);
            evt.WaitOne();
        }
    }
