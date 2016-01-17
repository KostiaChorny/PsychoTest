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

namespace PsychoTest.Tests.Strup
{
    /// <summary>
    /// Interaction logic for StrupIntro.xaml
    /// </summary>
    public partial class StrupIntro : Window
    {
        public StrupIntro()
        {
            InitializeComponent();
            nameBox.Text = Environment.UserName;
        }

        private void startButton_Click(object sender, RoutedEventArgs e)
        {
            new StrupMain(Convert.ToInt32(wordsNumberBox.Text), nameBox.Text).Show();
            Close();
        }

        private void statButton_Click(object sender, RoutedEventArgs e)
        {
            new Statistics().ShowDialog();
        }
    }
}
