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
        public string variableForXBind { get; set; }
        public MainPage()
        {
            this.InitializeComponent();

            variableForXBind = "Hello World";
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

        private void btn5_Click(object sender, RoutedEventArgs e)
        {
            // Binding Mode two way only transfers data from textbox control to variable. 
            // but if variable changes it does not show updated data into textbox control. - Two way has no effect.
            variableForXBind = "X:bind can see when changes are done to variables.";

            // after you've loaded data, you can force one-time bindings to be initialized by calling this.Bindings.Update()
            // force a manual update at any time with a call to Update
            this.Bindings.Update();
        }

        private void btn6_Click(object sender, RoutedEventArgs e)
        {
            // x:bind in textbox control does not see changes done from codebehind , until mode is set to "oneway"
            // even when underlying class has BindableBase
            objHVM2.NextButtonText = "Change from code behind";
        }


        private string XBindFunction()
        {

            return ("This value is returned by XBindFunction");
        }

        private List<string> ReturnListOfValues1()
        {
            List<string> x = new List<string>();
            x.Add("One");
            x.Add("Two");
            x.Add("Three");
            x.Add("Four");
            return (x);

        }
        static private List<string> ReturnListOfValues2()
        {
            List<string> x = new List<string>();
            x.Add("One");
            x.Add("Two");
            x.Add("Three");
            x.Add("Four");
            return (x);

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
