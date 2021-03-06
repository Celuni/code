        if (activity.Type == ActivityTypes.Message)
        {
            // Ensure that message is a postBack (like a submission from Adaptive Cards
            if (dc.Context.Activity.GetType().GetProperty("ChannelData") != null) {
                var channelData = JObject.Parse(dc.Context.Activity.ChannelData.ToString());
                if (channelData.ContainsKey("postback"))
                {
                    var postbackActivity = dc.Context.Activity;
                    // Convert the user's Adaptive Card input into the input of a Text Prompt
                    // Must be sent as a string
                    postbackActivity.Text = postbackActivity.Value.ToString();
                    await dc.Context.SendActivityAsync(postbackActivity);
                }
            }            
        }
