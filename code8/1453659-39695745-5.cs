                            List<CodeCamper.EntityLayer.Transaction.SessionVO> y = new List<CodeCamper.EntityLayer.Transaction.SessionVO>();
                            CodeCamper.EntityLayer.Transaction.SessionVO x = new CodeCamper.EntityLayer.Transaction.SessionVO();
                            x.SessionTimeSlot = "Day 01";
                           y.Add(x);
                           x = new CodeCamper.EntityLayer.Transaction.SessionVO();
                           x.SessionTimeSlot = "Day 02";
                           y.Add(x);
                           x = new CodeCamper.EntityLayer.Transaction.SessionVO();
                           x.SessionTimeSlot = "Day 03";
                           y.Add(x);
                           SessionVORepeater.DataSource = y;
                           SessionVORepeater.DataBind();
