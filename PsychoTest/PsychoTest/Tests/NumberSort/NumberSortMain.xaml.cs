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
    /// Interaction logic for NumberSortMain.xaml
    /// </summary>
    public partial class NumberSortMain : Window
    {
        string name;
        List<int> numbers;
        List<int> answersList;
        List<Button> buttons;
        List<Button> answeredButtons;
        DateTime startTime;
        string answer;
        int errors;
        private System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();

        public NumberSortMain(string name)
        {
            InitializeComponent();

            this.name = name;
            buttons = new List<Button>
            {
                answer1Button,
                answer2Button,
                answer3Button,
                answer4Button,
                answer5Button,
                answer6Button,
                answer7Button,
                answer8Button,
                answer9Button,
                answer10Button,
                answer11Button,
                answer12Button,
                answer13Button,
                answer14Button,
                answer15Button,
                answer16Button,
                answer17Button,
                answer18Button,
                answer19Button,
                answer20Button,
                answer21Button,
                answer22Button,
                answer23Button,
                answer24Button,
                answer25Button
            };

            answeredButtons = new List<Button>();
            answersList = new List<int>();
            this.timer.Interval = 1000;
            this.timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            timerLabel.Content = (DateTime.Now - startTime).ToString("mm':'ss");
        }

        private void startButton_Click(object sender, RoutedEventArgs e)
        {
            if (startButton.Content.ToString() == "Старт")
            {
                numbers = GetNumbers();
                for (int i = 0; i < numbers.Count; i++)
                {
                    buttons[i].Content = numbers[i];
                }

                ResultPanel.Visibility = Visibility.Hidden;
                timer.Start();
                startTime = DateTime.Now;
                startButton.Content = "Стоп";
            }
            else if (startButton.Content.ToString() == "Стоп")
            {
                for (int i = 0; i < numbers.Count; i++)
                {
                    buttons[i].Content = "";
                }

                CheckResult();
                timer.Stop();
                timerLabel.Content = "";

                ResultPanel.Visibility = Visibility.Visible;
                var timeElapsed = (DateTime.Now - startTime).TotalSeconds;
                timeResultLabel.Content = timeElapsed.ToString("F3");
                errorResultLabel.Content = errors;

                using (var db = new Model.DB())
                {
                    var result = new NumberSortResult()
                    {
                        Name = name,
                        ErrorCount = errors,
                        Time = timeElapsed
                    };
                    db.NumberSortTestResults.Add(result);
                    db.SaveChanges();
                }

                numbers = null;
                answersList = new List<int>();
                answeredButtons = new List<Button>();
                answer = "";
                errors = 0;
                startButton.Content = "Завершити тест";
            }
            else if (startButton.Content.ToString() == "Завершити тест")
            {
                Close();
            }
        }

        private void CheckResult()
        {
            var sorterNumbers = numbers.OrderBy(n => n).ToList();
            int i = 0, j = 0, rightAnswersCount = 0;
            while (i < answersList.Count)
            {
                while (j < sorterNumbers.Count && answersList[i] != sorterNumbers[j])
                {
                    j++;
                }

                var subset = new List<int>();
                while (j < sorterNumbers.Count && 
                    i < answersList.Count && 
                    answersList[i] == sorterNumbers[j])
                {
                    subset.Add(answersList[i]);
                    i++;
                    j++;
                }

                if (subset.Count > 1)
                {
                    rightAnswersCount += subset.Count;
                }

                j = 0;
            }

            errors = numbers.Count - rightAnswersCount;
        }

        private List<int> GetNumbers()
        {
            return Enumerable.Range(1, 99).OrderBy(m => Guid.NewGuid()).Take(25).ToList();
        }

        private void answer1Button_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (!answeredButtons.Contains(button))
            {
                answeredButtons.Add(button);
                answer += button.Content.ToString() + " ";
                answersList.Add(Convert.ToInt32(button.Content.ToString()));
                listLabel.Content = answer;
            }

            if (answersList.Count == numbers.Count || Convert.ToInt32(button.Content.ToString()) == numbers.Max())
            {
                // TODO:
                startButton_Click(null, null);
            }
        }
    }
}
