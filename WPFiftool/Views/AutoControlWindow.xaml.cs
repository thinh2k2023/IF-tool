using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ControlzEx.Standard;
using WPFiftool.Models;
using Xamarin.Forms;

namespace WPFiftool.Views
{
    /// <summary>
    /// Interaction logic for AutoControlWindow.xaml
    /// </summary>
    public partial class AutoControlWindow : Window
    {
        // declearate some variable for onpen window one time
        const Int16 OFF = 0;
        const Int16 ON = 1;

        public AutoControlWindow()
        {
            InitializeComponent();
        }

        private void StartUpProgramLoaded(object sender, RoutedEventArgs e)
        {
            DataConversion.ShowAutoControlWindow = ON;
        }

        private void CloseProgramUnloaded(object sender, RoutedEventArgs e)
        {
            DataConversion.ShowAutoControlWindow = OFF;
        }
    }
}
