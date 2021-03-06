    public IHttpActionResult getCustomersById(string id){
        var isAuthenticated = tokenAuthorization.validateToken(access_token);
        if (isAuthenticated)
        {
            List<Customers> customers = new List<Customers>();
            Customers customer = null;
            customer = new Customers();
            customer.kunnr = id;
            customer.name = "John Doe";
            customers.Add(customer);
            return Ok(customers);
        }
        else
        {
            return BadRequest("Not a valid Access Token");
        }
    }
