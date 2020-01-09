using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleOfBindingIssue1.Classes
{
    public class PricingData
    {
        public string PricingTitle { get; set; }
        public string PricingValue { get; set; }
        public string PricingCurrency { get; set; }
        public List<PricingSchedule> PricingScheduleList { get; set; }

        public string DisplayPricing => $"{PricingValue} {PricingCurrency}";

        public PricingData(string pPricingTitle, string pPricingValue, string pPricingCurrency)
        {
            PricingScheduleList = new List<PricingSchedule>();
            PricingTitle = pPricingTitle;
            PricingValue = pPricingValue;
            PricingCurrency = pPricingCurrency;
        }

    }

    public class PricingSchedule
    {
        public string SchedulePricingValue { get; set; }
        public string SchedulePricingCurrency { get; set; }
        public DateTime SchedulePricingDate { get; set; }
        public string SchedulePricingTime { get; set; }
        public string SchedulePricingTimeZone { get; set; }

        public PricingSchedule(string schedulePricingValue, string schedulePricingCurrency, DateTime schedulePricingDate, string schedulePricingTime, string schedulePricingTimeZone)
        {
            SchedulePricingValue = schedulePricingValue;
            SchedulePricingCurrency = schedulePricingCurrency;
            SchedulePricingDate = schedulePricingDate;
            SchedulePricingTime = schedulePricingTime;
            SchedulePricingTimeZone = schedulePricingTimeZone;
        }
    }

    public class DummyPricingData
    {
        public ObservableCollection<PricingData> pricingDatas = new ObservableCollection<PricingData>();

        public void FillData()
        {
            pricingDatas.Add(new PricingData("BasePrice", "1", "USD"));
            pricingDatas.Add(new PricingData("USA", "Free", ""));
            pricingDatas.Add(new PricingData("Canada", "2", "USD"));

            pricingDatas[0].PricingScheduleList.Add(new PricingSchedule("1", "USD", DateTime.Now, "01:00", "UTC"));
            pricingDatas[0].PricingScheduleList.Add(new PricingSchedule("2", "USD", DateTime.Now, "05:00", "UTC"));
            pricingDatas[0].PricingScheduleList.Add(new PricingSchedule("3", "USD", DateTime.Now, "07:00", "UTC"));



            pricingDatas[2].PricingScheduleList.Add(new PricingSchedule("11", "USD", DateTime.Now, "01:00", "UTC"));
            pricingDatas[2].PricingScheduleList.Add(new PricingSchedule("21", "USD", DateTime.Now, "02:00", "UTC"));
            pricingDatas[2].PricingScheduleList.Add(new PricingSchedule("31", "USD", DateTime.Now, "03:00", "UTC"));
            pricingDatas[2].PricingScheduleList.Add(new PricingSchedule("41", "USD", DateTime.Now, "01:00", "UTC"));
        }
    }
}
