    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
    
        }
    
        public Guid GetUserID()
        {
            Guid currentUserId = (Guid)Membership.GetUser().ProviderUserKey;
            return currentUserId;
    
        }
    }
