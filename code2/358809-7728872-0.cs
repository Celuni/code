     class EventLimiter
     {
        Queue<DateTime> requestTimes;
        int maxRequests;
        TimeSpan timeSpan;
        public EventLimiter(int maxRequests, TimeSpan timeSpan)
        {
            this.maxRequests = maxRequests;
            this.timeSpan = timeSpan;
            requestTimes = new Queue<DateTime>(maxRequests);
        }
        private void SynchronizeQueue()
        {
            while ((requestTimes.Count > 0) && (requestTimes.Peek().Add(timeSpan) < DateTime.Now))
                requestTimes.Dequeue();
        }
        public bool CanRequestNow()
        {
            SynchronizeQueue();
            return requestTimes.Count < maxRequests;
        }
        public void EnqueueRequest()
        {
            while (!CanRequestNow())
                System.Threading.Thread.Sleep(1000);
            requestTimes.Enqueue(DateTime.Now);
        }
     }
