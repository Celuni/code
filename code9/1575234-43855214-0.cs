    var contentLinksManager = ContentLinksManager.GetManager();
    var librariesManager= LibrariesManager.GetManager();
    var masterId = data.OriginalContentId; //IF data is Live status or data.Id if is Master status
    var imageFileLink = contentLinksManager.GetContentLinks().FirstOrDefault(cl=>cl.ParentItemId == masterId && cl.ComponentPropertyName == "Image");
    if (previewFileLink!= null)
    {
        var image= librariesManager.GetImage(imageFileLink.ChildItemId);
        if (image!= null)
        {
           //WORK WITH IMAGE OBJECT
        }
    
}
