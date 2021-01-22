    // any price:
    Prices prices = new Prices();
    prices.SetPriceByLegacyName("0D", 1.2345M);
    // or, your loop becomes a bit easier:
    SetPricesValues(IDictionary<string, decimal> pricesDictionary)  
    {  
        foreach(string key in pricesDictionary.Keys)
        {
            // assuming "this" is of type Prices (you didn't specify)
            this.SetPriceByLegacyName(key, pricesDictionary[key]);
        }    
    }  
