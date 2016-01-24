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

namespace PsychoTest.Tests.ConfusedLines
{
    /// <summary>
    /// Interaction logic for ConfusedLinesMain.xaml
    /// </summary>
    public partial class ConfusedLinesMain : Window
    {
        private string name;
        Dictionary<TextBox, int> answers;
        DateTime startTime = DateTime.Now;
        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();

        public ConfusedLinesMain(string name)
        {
            InitializeComponent();

            this.name = name;
            answers = new Dictionary<TextBox, int>
            {
                {answer1Box, 5},
                {answer2Box, 12},
                {answer3Box, 4},
                {answer4Box, 9},
                {answer5Box, 14},
                {answer6Box, 16},
                {answer7Box, 1},
                {answer8Box, 8},
                {answer9Box, 18},
                {answer10Box, 7},
                {answer11Box, 19},
                {answer12Box, 22},
                {answer13Box, 15},
                {answer14Box, 23},
                {answer15Box, 6},
                {answer16Box, 21},
                {answer17Box, 2},
                {answer18Box, 20},
                {answer19Box, 3},
                {answer20Box, 10},
                {answer21Box, 11},
                {answer22Box, 25},
                {answer23Box, 24},
                {answer24Box, 17},
                {answer25Box, 13},
            };
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            timerBox.Content = (DateTime.Now - startTime).ToString("mm':'ss");
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (startButton.Content.ToString() == "Старт")
            {
                startButton.Content = "Стоп";
                foreach (var item in answers)
                {
                    item.Key.IsEnabled = true;
                }
                timer.Start();
                startTime = DateTime.Now;
                resultPanel.Visibility = Visibility.Hidden;
            }
            else if (startButton.Content.ToString() == "Стоп")
            {
                startButton.Content = "Завершити тест";
                timerBox.Content = "";
                timer.Stop();
                var answersCount = CheckAnswers(answers);
                var finishTime = (DateTime.Now - startTime).TotalSeconds;
                resultPanel.Visibility = Visibility.Visible;

                errorCountResultLabel.Content = 25 - answersCount;
                timeResultLabel.Content = finishTime.ToString("F3");
                if (answersCount >= 19)
                {
                    resultResultLabel.Content = "Чудово";
                }
                else if (answersCount >= 10)
                {
                    resultResultLabel.Content = "Добре";
                }
                else if (answersCount >= 4)
                {
                    resultResultLabel.Content = "Задовільно";
                }
                else
                {
                    resultResultLabel.Content = "Незадовільно";
                }

                using (var db = new Model.DB())
                {
                    var result = new ConfusedLinesTestResult()
                    {
                        Date = DateTime.Now,
                        ErrorsCount = 25 - answersCount,
                        Name = name,
                        Time = finishTime,
                        Result = resultResultLabel.Content.ToString()
                    };
                    db.ConfusedLinesTestResults.Add(result);
                    db.SaveChanges();
                }

                foreach (var item in answers)
                {
                    item.Key.Text = "";
                    item.Key.IsEnabled = false;
                }
            }
            else if (startButton.Content.ToString() == "Завершити тест")
            {
                Close();
            }
        }

        private int CheckAnswers(Dictionary<TextBox, int> answers)
        {
            int i = 0;
            foreach (var item in answers)
            {
                int a;
                
                if (Int32.TryParse(item.Key.Text, out a) && Convert.ToInt32(item.Key.Text) == item.Value)
                {
                    i++;
                }
            }
            return i;
        }
    }
}
