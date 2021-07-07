using FOS.DataLayer;
using FOS.Setup;
using Shared.Diagnostics.Logging;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace FOS.Web.UI.Controllers.API
{
    public class MyOrderListDetailController : ApiController
    {
        FOSDataModel db = new FOSDataModel();

        public IHttpActionResult Get(int JobID)
        {
            List<Sp_MyOrderListDetail_Result> result = new List<Sp_MyOrderListDetail_Result>();
            FOSDataModel dbContext = new FOSDataModel();
            try
            {
                if (JobID > 0)
                {
                    object[] param = { JobID };

                    var Reason = db.JobsDetails.Where(x => x.JobID == JobID).FirstOrDefault();
                    if (Reason.VisitPurpose == "Ordering")
                    {


                         result = dbContext.Sp_MyOrderListDetail(JobID).ToList();
                        if (result != null && result.Count > 0)
                        {
                            return Ok(new
                            {
                                MyOrderListDetail = result

                            });
                        }
                    }
                    else
                    {
                        var name = db.Tbl_FollowupReasons.Where(x => x.ID == Reason.FollowupReason).Select(x=> new {
                            JobID=x.ID,
                            ItemName= x.Name,
                            Quantity=0,

                        }).FirstOrDefault();
                        if (name != null )
                        {
                            object[] stringArray = new object[] { name };
                            return Ok(new
                            {
                                MyOrderListDetail = stringArray

                            });
                        }
                    }
                    
                }
            }
            catch (Exception ex)
            {
                Log.Instance.Error(ex, "VisitDetailController GET API Failed");
            }
            object[] paramm = {};
            return Ok(new
            {
                MyOrderListDetail = paramm
            });

        }


    }
}