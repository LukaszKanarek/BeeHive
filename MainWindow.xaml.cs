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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BeeHive
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Queen queen;
        public MainWindow()
        {
            InitializeComponent();
            queen = new Queen();
            statusReportTextBox.Text = queen.StatusReport;
        }

        private void WorkShiftButton_Click(object sender, RoutedEventArgs e)
        {
            queen.WorkNextShift();
            statusReportTextBox.Text = queen.StatusReport;
        }

        private void AssignJobButton_Click(object sender, RoutedEventArgs e)
        {
            queen.AssighBee(jobsComboBox.Text);
            statusReportTextBox.Text = queen.StatusReport;
        }


    }
}
