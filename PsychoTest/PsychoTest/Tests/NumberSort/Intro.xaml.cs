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

namespace PsychoTest.Tests.NumberSort
{
    /// <summary>
    /// Interaction logic for Intro.xaml
    /// </summary>
    public partial class Intro : Window
    {
        public Intro()
        {
            InitializeComponent();
            nameBox.Text = Environment.UserName;
        }

        private void startButton_Click(object sender, RoutedEventArgs e)
        {
            new NumberSortMain(nameBox.Text).Show();
            Close();
        }

        private void statButton_Click(object sender, RoutedEventArgs e)
        {
            new Statistics().ShowDialog();
        }
    }
}
