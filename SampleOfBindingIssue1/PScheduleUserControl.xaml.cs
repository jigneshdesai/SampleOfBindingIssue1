using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace SampleOfBindingIssue1
{
    public sealed partial class PScheduleUserControl : UserControl
    {
        public ObservableCollection<DynamicPricingList> dpl = new ObservableCollection<DynamicPricingList>();
        
        public PScheduleUserControl()
        {
            this.InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            dpl.Add(new DynamicPricingList("Free"));
            for (int i = 1; i < 24; i++)
            {
                dpl.Add(new DynamicPricingList(string.Format("{0} USD", i)));
                myList.Add(new DynamicPricingList(string.Format("{0} USD", i)));
               
            }

            int xx = 0;
           
          
        }
    }

    // https://stackoverflow.com/questions/16164521/list-in-resource-xaml-and-access-in-viewmodel
    public class cdpl : List<DynamicPricingList>
    {
        public string PV { get; set; }
    }
    public class DynamicPricingList 
    {
        public string PriceValue { get; set; }
        public DynamicPricingList() { }
        public DynamicPricingList(string pPriceValue)
        {
            PriceValue = pPriceValue;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is DynamicPricingList))
                return false;

            return ((DynamicPricingList)obj).PriceValue == this.PriceValue;
        }
    }
}
