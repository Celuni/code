    Facebook.FacebookConfigurationSection s = new FacebookConfigurationSection();
                    s.AppId = 'ApplicationID';
                    s.AppSecret = 'ApplicationSecret';
                    FacebookWebContext wc = new FacebookWebContext(s);
                    dynamic da = wc.SignedRequest.Data;
                    dynamic page = da.page;
                    string pageid = page.id;
                    bool isLiked = page.liked;
                    bool isAdmin = page.admin;
 
