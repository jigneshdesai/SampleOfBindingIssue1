using SampleOfBindingIssue1.Classes;
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
    public sealed partial class PricingUserControl : UserControl
    {
        public PricingUserControl()
        {

            this.InitializeComponent();
        }

        ObservableCollection<DynamicPricingList> dpl = new ObservableCollection<DynamicPricingList>();
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

            dpl.Add(new DynamicPricingList("Free"));
            for (int i = 1; i < 24; i++)
            {
                dpl.Add(new DynamicPricingList(string.Format("{0} USD", i)));
            }

            int xx = 0;

            // XAML binding of SelectedValue="{Binding DisplayPricing}" is not working.
            // So temp workaround is to set it via coding,  but need to find out why it does not work in xaml;
            cbPriceValueList.SelectedValue = ((PricingData)this.DataContext).DisplayPricing;
        }

    }




    public class DynamicPricingList
    {
        public string PriceValue { get; set; }
        public DynamicPricingList(string pPriceValue)
        {
            PriceValue = pPriceValue;
        }
    }



}



