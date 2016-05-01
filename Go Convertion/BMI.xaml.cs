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
using Windows.UI.Popups;
using Windows.UI.ViewManagement;
// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Go_Convertion
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class BMI : Page
    {
       
        
        public BMI()
        {
            this.InitializeComponent();
        }

        

        private async void button_Click(object sender, RoutedEventArgs e)
        {
            
            float BB, TB, BMI, BI;
            //            if (!isNumeric && textBox_from.Text != "")
            bool isNumPBB = float.TryParse(tbb.Text, out BB);
            bool isNumPTB = float.TryParse(ttb.Text, out TB);
            
            if ((!isNumPBB && !isNumPTB))
            {
                var dialog = new MessageDialog("Input invalid, please correct your input !");
                await dialog.ShowAsync();
                ttb.Text = "";
                tbb.Text = "";
            }

            else
            {
                if (comboGen.SelectedIndex == 0)
                {
                    BI = ((TB * 100) - 100) - ((10 / 100) * ((TB * 100) - 100));
                }
                else
                {
                    BI = ((TB * 100) - 100) - ((15 / 100) * ((TB * 100) - 100));
                }
                BMI = BB / (TB * TB);
                conbox1.Text = "" + BMI;
                if (BMI < 18.5)
                {
                    conbox2.Text = "Underweight";
                }
                if (BMI >= 18.5 && BMI <= 24)
                {
                    conbox2.Text = "Normal";
                }
                if (BMI > 24 && BMI <= 29)
                {
                    conbox2.Text = "Overweight";
                }
                if (BMI > 29)
                {
                    conbox2.Text = "Obesity";
                }
                conbox3.Text = "" + BI;
            }
        }
    }
}