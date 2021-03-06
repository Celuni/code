    public static class QueueOperations
    {
        [FunctionName("Support_ReprocessPoisonQueueMessages")]
        public static async Task<IActionResult> Support_ReprocessPoisonQueueMessages([HttpTrigger(AuthorizationLevel.Admin, "put", Route = "support/reprocessQueueMessages/{queueName}")]HttpRequest req, ILogger log,
            [Queue("{queueName}")] CloudQueue queue,
            [Queue("{queueName}-poison")] CloudQueue poisonQueue, string queueName)
        {
            log.LogInformation("Support_ReprocessPoisonQueueMessages function processed a request.");
            int.TryParse(req.Query["messageCount"], out var messageCountParameter);
            var messageCount = messageCountParameter == 0 ? 10 : messageCountParameter;
            var processedMessages = 0;
            while (processedMessages < messageCount)
            {
                var message = await poisonQueue.GetMessageAsync();
                if (message == null)
                    break;
                var messageId = message.Id;
                var popReceipt = message.PopReceipt;
                await queue.AddMessageAsync(message); // a new Id and PopReceipt is assigned
                await poisonQueue.DeleteMessageAsync(messageId, popReceipt);
                processedMessages++;
            }
            return new OkObjectResult($"Reprocessed {processedMessages} messages from the {poisonQueue.Name} queue.");
        }
    }
