    using System;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    namespace seat
    {
	public partial class _Default : Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
		}
    protected void seat1_Click(object sender, ImageClickEventArgs e)
		{
			ImageButton button = (ImageButton)sender;
			foreach (var item in Seats.Controls)
			{
				if (item.GetType() == typeof(ImageButton) && ((ImageButton)item).ImageUrl == "Images/sseat.png" && ((ImageButton)item).ID != button.ID)
				{ 
					((ImageButton)item).ImageUrl = ((ImageButton)item).Attributes["originalUrl"];
					break;
				}
			}
			if (button.ImageUrl == "Images/sseat.png")
			{
				button.ImageUrl = button.Attributes["originalUrl"];
			}
			else
			{
				button.ImageUrl = "Images/sseat.png";
			}
		}
	   }
     }
