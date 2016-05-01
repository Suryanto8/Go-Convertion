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
    public sealed partial class suhu : Page
    {
        public suhu()
        {
            this.InitializeComponent();
            con1.Text = "-          :";
            con2.Text = "-          :";
            con3.Text = "-          :";
            conbox1.Text = "-";
            conbox2.Text = "-";
            conbox3.Text = "-";
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            double result;
            double temp;
            bool isNumeric = double.TryParse(textBox_from.Text, out temp);
            if (isNumeric == true)
            {
                temp = double.Parse(textBox_from.Text);
                result = temp * -1;
                textBox_from.Text = Convert.ToString(result);
            }
        }
        public void comboBox_from_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            double K = 0, R = 0, C = 0, F = 0, Input;

            bool isNumeric = double.TryParse(textBox_from.Text, out Input);

            if (comboBox_from.SelectedIndex == 0) // Kelvin
            {
                con1.Text = "Celcius    :";
                con2.Text = "Reamur     :";
                con3.Text = "Fahrenheit :";
                K = Input;
                C = K - 273.15;
                F = (K * 1.8) - 459.67;
                R = (K - 273.15) * 0.8;
                conbox1.Text = "" + Math.Round(C, 3);
                conbox2.Text = "" + Math.Round(R, 3);
                conbox3.Text = "" + Math.Round(F, 3);
            }
            if (comboBox_from.SelectedIndex == 1) // celcius
            {
                con1.Text = "Kelvin      :";
                con2.Text = "Reamur      :";
                con3.Text = "Fahrenheit  :";
                C = Input;
                K = C + 273.15;
                F = (C * 1.8) + 32;
                R = C * 0.8;
                conbox1.Text = "" + Math.Round(K, 3);
                conbox2.Text = "" + Math.Round(R, 3);
                conbox3.Text = "" + Math.Round(F, 3);

            }
            if (comboBox_from.SelectedIndex == 2) // fahrenheit
            {
                con1.Text = "Kelvin     :";
                con2.Text = "Celcius    :";
                con3.Text = "Reamur     :";
                F = Input;
                K = (F + 459.67) / 1.8;
                C = (F - 32) / 1.8;
                R = (F - 32) / 2.25;
                conbox1.Text = "" + Math.Round(K, 3);
                conbox2.Text = "" + Math.Round(C, 3);
                conbox3.Text = "" + Math.Round(R, 3);
            }
            if (comboBox_from.SelectedIndex == 3) // reamur
            {
                con1.Text = "Kelvin     :";
                con2.Text = "Celcius    :";
                con3.Text = "Fahrenheit :";
                R = Input;
                K = (R / 0.8) + 273.15;
                C = R / 0.8;
                F = (R * 2.25) + 32;
                conbox1.Text = "" + Math.Round(K, 3);
                conbox2.Text = "" + Math.Round(C, 3);
                conbox3.Text = "" + Math.Round(F, 3);
            }

        }

        private async void textBox_from_TextChanged(object sender, TextChangedEventArgs e)
        {
            double K = 0, R = 0, C = 0, F = 0, Input;
            bool isNumeric = double.TryParse(textBox_from.Text, out Input);

            if (isNumeric == true)
            {

                if (comboBox_from.SelectedIndex == 0)
                {
                    K = Input;
                    C = K - 273.15;
                    F = (K * 1.8) - 459.67;
                    R = (K - 273.15) * 0.8;
                    conbox1.Text = "" + Math.Round(C, 3);
                    conbox2.Text = "" + Math.Round(R, 3);
                    conbox3.Text = "" + Math.Round(F, 3);
                }
                if (comboBox_from.SelectedIndex == 1)
                {

                    C = Input;
                    K = C + 273.15;
                    F = (C * 1.8) + 32;
                    R = C * 0.8;
                    conbox1.Text = "" + Math.Round(K, 3);
                    conbox2.Text = "" + Math.Round(R, 3);
                    conbox3.Text = "" + Math.Round(F, 3);
                }
                if (comboBox_from.SelectedIndex == 2)
                {
                    F = Input;
                    K = (F + 459.67) / 1.8;
                    C = (F - 32) / 1.8;
                    R = (F - 32) / 2.25;
                    conbox1.Text = "" + Math.Round(K, 3);
                    conbox2.Text = "" + Math.Round(C, 3);
                    conbox3.Text = "" + Math.Round(R, 3);

                }
                if (comboBox_from.SelectedIndex == 3)
                {
                    R = Input;
                    K = (R / 0.8) + 273.15;
                    C = R / 0.8;
                    F = (R * 2.25) + 32;
                    conbox1.Text = "" + Math.Round(K, 3);
                    conbox2.Text = "" + Math.Round(C, 3);
                    conbox3.Text = "" + Math.Round(F, 3);
                }
            }
            else
            {
                if (!isNumeric && textBox_from.Text != "")
                {
                    var dialog = new MessageDialog("Input Invalid, please correct your input !");
                    await dialog.ShowAsync();
                    textBox_from.Text = "";
                    conbox1.Text = "-";
                    conbox2.Text = "-";
                    conbox3.Text = "-";
                }
            }
        }
    }
}