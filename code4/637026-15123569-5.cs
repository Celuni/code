    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    namespace WebApplication1
    {
        public partial class giveMeSomeJson : System.Web.UI.Page
        {
            protected override void OnLoad(EventArgs e)
            {
                Response.ContentType = "text/json";
                var year = DateTime.Now.Year;
                var month = DateTime.Now.Month;
                Response.Write(JsonConvert.SerializeObject(new[]
                    {
                        new
                        {
                            id = "111",
                            title = "Event1",
                            start = String.Format("{0}-{1}-10", year, month),
                            url = "http://yahoo.com/"
                        },
                        new
                        {
                            id = "222",
                            title = "Event2",
                            start = String.Format("{0}-{1}-20", year, month),
                            url = "http://yahoo.com/"
                        }
                    }));
            }
        }
    }
