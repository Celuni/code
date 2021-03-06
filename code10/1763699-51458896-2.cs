    // the ResponseJson on a list method is the entire list (as json) returned from stripe.
    // the ObjectJson is so we can store only the json for a single object in the list on that entity for
    // logging and/or debugging
    public static T MapFromJson(string json, string parentToken = null, StripeResponse stripeResponse = null)
    {
        var jsonToParse = string.IsNullOrEmpty(parentToken) ? json : JObject.Parse(json).SelectToken(parentToken).ToString();
        var result = JsonConvert.DeserializeObject<T>(jsonToParse);
        // if necessary, we might need to apply the stripe response to nested properties for StripeList<T>
        ApplyStripeResponse(json, stripeResponse, result);
        return result;
    }
    public static T MapFromJson(StripeResponse stripeResponse, string parentToken = null)
    {
        return MapFromJson(stripeResponse.ResponseJson, parentToken, stripeResponse);
    }
    private static void ApplyStripeResponse(string json, StripeResponse stripeResponse, object obj)
    {
        if (stripeResponse == null)
        {
            return;
        }
        foreach (var property in obj.GetType().GetRuntimeProperties())
        {
            if (property.Name == nameof(StripeResponse))
            {
                property.SetValue(obj, stripeResponse);
            }
        }
        stripeResponse.ObjectJson = json;
    }
