    // using Amazon.SimpleNotificationService;
    // using Amazon.SimpleNotificationService.Model;
    
    var client = new AmazonSimpleNotificationServiceClient();
    var request = new ListTopicsRequest();
    var response = new ListTopicsResponse();
    
    do
    {
      response = client.ListTopics(request);  
    
      foreach (var topic in response.Topics)
      {
        Console.WriteLine("Topic: {0}", topic.TopicArn);
    
        var subs = client.ListSubscriptionsByTopic(
          new ListSubscriptionsByTopicRequest
          {
            TopicArn = topic.TopicArn
          });
    
        var ss = subs.Subscriptions;
    
        if (ss.Any())
        {
          Console.WriteLine("  Subscriptions:");
    
          foreach (var sub in ss)
          {
            Console.WriteLine("    {0}", sub.SubscriptionArn);
          }
        }
    
        var attrs = client.GetTopicAttributes(
          new GetTopicAttributesRequest
          {
            TopicArn = topic.TopicArn
          }).Attributes;
    
        if (attrs.Any())
        {
          Console.WriteLine("  Attributes:");
    
          foreach (var attr in attrs)
          {
            Console.WriteLine("    {0} = {1}", attr.Key, attr.Value);
          }
        }    
    
        Console.WriteLine();
      }
    
      request.NextToken = response.NextToken;
    
    } while (!string.IsNullOrEmpty(response.NextToken));
