    var categorynew = new List<string>();
    categorynew.Add(((Categorypicker.SelectedItem as CategoriesModel).category));
    var categoryArray = categorynew.ToArray();
    var jsoncategoryArray = JsonConvert.SerializeObject(categoryArray);
    content.Add(baContent, "Image", name);
    content.Add(new StringContent(DealerAddr.Text), "DealersAddress");
    content.Add(new StringContent(itemName.Text), "ItemName");
    content.Add(new StringContent(itemDescription.Text), "ItemDescription");
    content.Add(new StringContent(itemPrice.Text), "PreferredPrice");
    content.Add(new StringContent(DealerPhone.Text), "DealerPhone");
    content.Add(new StringContent(DealerCity.Text), "City");
    content.Add(new StringContent(StoreUrl.Text), "SellerWeblink");
    content.Add(new StringContent(jsoncategoryArray),"category");
