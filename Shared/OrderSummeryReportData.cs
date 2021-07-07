using FOS.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOS.Shared
{
    public class OrderSummaryReportData
    {

        public int RetailerID { get; set; }
        public string ShopName { get; set; }
        public string DateFrom { get; set; }
        public string DateTo { get; set; }
        public int DistributorID { get; set; }
        public int RangeID { get; set; }
        public int RegionID { get; set; }
        public int CityID { get; set; }
        public int SaleOfficerID { get; set; }
        public string Email { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
        public List<CategoryData> range { get; set; }
        public List<MainCategories> ranges { get; set; }
        public List<SaleOfficerData> saleofficerdata { get; set; }
        public virtual List<SaleOfficer> SaleOfficer { get; set; }
        public List<RetailerData> dealerdata { get; set; }
        public List<CityData> CityData { get; set; }
        public virtual List<RegionalHeadData> RegionalHead { get; set; }
        public List<RegionData> regionData { get; set; }
    }




    public class KPIData
    {

        public int SOID { get; set; }
        public string SoName { get; set; }
        public string RHName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string ElapseTime { get; set; }
        public int? totalVisits { get; set; }
        public int ProductiveShops { get; set; }
        public int NonProductive { get; set; }
        public decimal ProductivePer { get; set; }
        public double perDayorders { get; set; }
        public int? totallines { get; set; }
        public string Linesperbill { get; set; }
      
    }
}
