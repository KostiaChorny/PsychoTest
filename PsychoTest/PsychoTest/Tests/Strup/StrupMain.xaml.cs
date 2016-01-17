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
    /// Interaction logic for StrupMain.xaml
    /// </summary>
    public partial class StrupMain : Window
    {
        private int wordsCount;
        private int currentWord;
        private int currentPart = 1;
        private DateTime startTime;
        private DateTime finishTime;
        private int errorCount;
        private StrupResult result;
        private string name;
        private List<string> words;
        private Dictionary<string, Color> colors;
        private System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        private string currentAnswer;


        public StrupMain()
        {
            InitializeComponent();
            InitWords();
            InitColors();
            StartPart(currentPart);
        }

        private void InitColors()
        {
            colors = new Dictionary<string, Color>
            {
                {"Червоний"    , Color.FromRgb(0xff,0x00,0x00) },
                {"Рожевий"     , Color.FromRgb(0xff,0xc0,0xcb) },
                {"Помаранчевий", Color.FromRgb(0xff,0xa5,0x00) },
                {"Жовтий"      , Color.FromRgb(0xff,0xff,0x00) },
                {"Фіолетовий"  , Color.FromRgb(0xee,0x82,0xee) },
                {"Зелений"     , Color.FromRgb(0x00,0x80,0x00) },
                {"Синій"       , Color.FromRgb(0x00,0x00,0xff) },
                {"Коричневий"  , Color.FromRgb(0xa5,0x2a,0x2a) },
                {"Чорний"      , Color.FromRgb(0x00,0x00,0x00) },
                {"Сірий"       , Color.FromRgb(0x80,0x80,0x80) }
            };
        }

        public StrupMain(int wordsCount, string name) : this()
        {
            this.wordsCount = wordsCount;
            this.name = name;
            this.result = new StrupResult() { Name = name };
            this.timer.Interval = 1000;
            this.timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            timerLabel.Content = (DateTime.Now - startTime).ToString("mm':'ss");
        }

        private void InitWords()
        {
            words = new List<string>()
            {
                "Слово1",
                "Слово2",
                "Слово3",
                "Слово4",
                "Слово5",
                "Слово6",
                "Слово7",
                "Слово8",
                "Слово9",
                "Слово10",
                "Слово11",
                "Слово12",
                "Слово13",
                "Слово14"
            };

        }

        private void StartPart(int partNumber)
        {
            switch (partNumber)
            {
                case 1:
                    partNumberLabel.Content = "Частина 1";
                    descriptionLabel.Content = "Оберіть слово що відображається в полі";
                    break;
                case 2:
                    partNumberLabel.Content = "Частина 2";
                    descriptionLabel.Content = "Оберіть колір зірочок в полі";
                    break;
                case 3:
                    partNumberLabel.Content = "Частина 3";
                    descriptionLabel.Content = "Оберіть колір слова що відображається в полі";
                    break;
                default:
                    break;
            }
        }

        private async void StartButton_Click(object sender, RoutedEventArgs e)
        {
            if (StartButton.Content.ToString() == "Старт")
            {
                StartButton.Content = "Стоп";
                startTime = DateTime.Now;
                errorCount = 0;
                currentWord = 0;
                timer.Start();

                NextQuestion();
                Buttons.IsEnabled = true;
                resultGrid.Visibility = Visibility.Hidden;
            }
            else if (StartButton.Content.ToString() == "Стоп")
            {
                if (currentPart == 3)
                {
                    StartButton.Content = "Завершити тест";
                }
                else
                {
                    StartButton.Content = "Наступна частина";
                }
                finishTime = DateTime.Now;
                Buttons.IsEnabled = false;
                wordsResultCountLabel.Content = wordsCount;
                errorsResultCountLabel.Content = errorCount;
                timeResultLabel.Content = (finishTime - startTime).TotalSeconds;
                resultGrid.Visibility = Visibility.Visible;
                timer.Stop();
                timerLabel.Content = "";

                result.Parts.Add(new PartResult()
                {
                    ErrorsCount = errorCount,
                    QuestionsCount = wordsCount,
                    Part = currentPart,
                    Time = (finishTime - startTime).TotalSeconds
                });                                    
            }
            else if (StartButton.Content.ToString() == "Наступна частина")
            {
                currentPart++;
                StartPart(currentPart);
                StartButton.Content = "Старт";
                answer1Button.Content = "";
                answer2Button.Content = "";
                answer3Button.Content = "";
                answer4Button.Content = "";
                wordBox.Text = "";
                resultGrid.Visibility = Visibility.Hidden;
                timerLabel.Content = "00:00";
            }
            else if (StartButton.Content.ToString() == "Завершити тест")
            {
                using (var context = new Model.DB())
                {
                    context.StrupTestResults.Add(result);
                    await context.SaveChangesAsync();
                    StartButton.IsEnabled = false;
                }
                Close();
            }

        }

        private void NextQuestion()
        {
            var answers = GetAnswers();
            currentAnswer = answers[0];
            switch (currentPart)
            {
                case 1:
                    wordBox.Text = currentAnswer;
                    break;
                case 2:
                    wordBox.Text = "*************";
                    wordBox.Foreground = new SolidColorBrush(colors[currentAnswer]);
                    break;
                case 3:
                    wordBox.Text = GetAnswers()[0];
                    wordBox.Foreground = new SolidColorBrush(colors[currentAnswer]);
                    break;
                default:
                    break;
            }

            var buttonNumber = new Random().Next(1, 4);

            switch (buttonNumber)
            {
                case 1:
                    answer1Button.Content = answers[0];
                    answer2Button.Content = answers[1];
                    answer3Button.Content = answers[2];
                    answer4Button.Content = answers[3];
                    break;
                case 2:
                    answer1Button.Content = answers[1];
                    answer2Button.Content = answers[0];
                    answer3Button.Content = answers[2];
                    answer4Button.Content = answers[3];
                    break;
                case 3:
                    answer1Button.Content = answers[1];
                    answer2Button.Content = answers[2];
                    answer3Button.Content = answers[0];
                    answer4Button.Content = answers[3];
                    break;
                case 4:
                    answer1Button.Content = answers[1];
                    answer2Button.Content = answers[2];
                    answer3Button.Content = answers[3];
                    answer4Button.Content = answers[0];
                    break;
                default:
                    break;
            }
        }

        private List<string> GetAnswers()
        {
            switch (currentPart)
            {
                case 1:
                    return words.OrderBy(w => Guid.NewGuid()).Take(4).ToList();
                case 2:                    
                case 3:
                    return colors.Keys.OrderBy(w => Guid.NewGuid()).Take(4).ToList();
            }
            return null;   
        }

        private void CheckAnswer(string answer)
        {
            if (answer != currentAnswer)
            {
                errorCount++;
            }

            currentWord++;

            if (currentWord >= wordsCount)
            {
                StartButton_Click(null, null);
            }
            else
            {
                NextQuestion();
            }
        }

        private void answer1Button_Click(object sender, RoutedEventArgs e)
        {
            CheckAnswer(answer1Button.Content.ToString());
        }

        private void answer2Button_Click(object sender, RoutedEventArgs e)
        {
            CheckAnswer(answer2Button.Content.ToString());
        }

        private void answer3Button_Click(object sender, RoutedEventArgs e)
        {
            CheckAnswer(answer3Button.Content.ToString());
        }

        private void answer4Button_Click(object sender, RoutedEventArgs e)
        {
            CheckAnswer(answer4Button.Content.ToString());
        }
    }
}
