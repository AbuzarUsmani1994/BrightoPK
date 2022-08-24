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
    public class VisitDetailMapViewController : ApiController
    {
        FOSDataModel db = new FOSDataModel();

        public IHttpActionResult Get(int SOID,string Date)
        {
            FOSDataModel dbContext = new FOSDataModel();
            try
            {
                DateTime dtFromTodayUtc = Convert.ToDateTime(Date);

                DateTime dtFromToday = dtFromTodayUtc.Date;
                DateTime dtToToday = dtFromToday.AddDays(1);

                var RegionID = db.SOAttendances.Where(x => x.SOID == SOID && x.CreatedAt >= dtFromTodayUtc && x.CreatedAt <= dtToToday).Select(x => x.RegionID).FirstOrDefault();

                if (SOID > 0 && RegionID > 0)
                {
                    object[] param = { SOID };
                    
                    
                        var result = dbContext.Sp_MyVisitsMapViewForGPC1_4(SOID,dtFromToday,dtToToday,RegionID).ToList();
                    
                    if (result != null && result.Count > 0)
                    {
                        return Ok(new
                        {
                            MyVisitsMapView = result
                            
                        });
                    }
                  
                }
            }
            catch (Exception ex)
            {
                Log.Instance.Error(ex, "MyVisitsMapView  API Failed");
            }
            object[] paramm = {  };
            return Ok(new
            {
                MyVisitsMapView = paramm
            });

        }


    }
}