using Prism.Mvvm;
using System;
using System.Collections.Generic;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace SampleOfBindingIssue1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public HostViewModel1 objHVM1 = new HostViewModel1();
        public HostViewModel2 objHVM2 = new HostViewModel2();
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            this.DataContext = objHVM1;

           
        }

        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            objHVM1.NextButtonText = "Changed from code";
          
        }

        private void btn3_Click(object sender, RoutedEventArgs e)
        {
            this.DataContext = objHVM2;
        }

        private void btn4_Click(object sender, RoutedEventArgs e)
        {
            objHVM2.NextButtonText = "Changed from code using BindableBase using library Prism.Mvvm";
        }
    }







    public class HostViewModel1
    {
        public HostViewModel1()
        {
            this.NextButtonText = "Next";
        }

        public string NextButtonText { get; set; }
    }

    // https://stackoverflow.com/questions/28844518/bindablebase-vs-inotifychanged
    public class HostViewModel2  : BindableBase
    {
        private string nextButtonText;
        public HostViewModel2()
        {
            this.NextButtonText = "Next";
        }

        public string NextButtonText
        {
            get { return this.nextButtonText; }
            set { this.SetProperty(ref this.nextButtonText, value); }
        }
    }




}
