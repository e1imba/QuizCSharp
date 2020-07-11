using QuizCSharp.Models;
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

namespace QuizCSharp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Questions> allQuestions = new List<Questions>();
        List<string> singleQuestion = new List<string>();
        Random random = new Random();
        int randomSort = 0;
        int questionNumber = 1;
        int answersInRow = 0;
        public MainWindow()
        {
            InitializeComponent();
            GetAllQuestions();
            GetQuestion();
        }

        // Update statistic data about correct answers 
        private void UpdateStatistic()
        {
            lblNumber.Content = questionNumber;
            lblAnswersArray.Content = answersInRow;
        }

        // Getting single question
        private void GetQuestion()
        {
            UpdateStatistic();
            int quest = random.Next(1, allQuestions.Count);
            question.Text = allQuestions[quest].Question;
            singleQuestion.Add(allQuestions[quest].Answer);
            // do-while loop which is collecting 3 random answers
            do
            {
                int a1 = random.Next(0, allQuestions.Count);
                int a2 = random.Next(0, allQuestions.Count);
                int a3 = random.Next(0, allQuestions.Count);
                if (a1 == quest || a2 == quest || a3 == quest || a1 == a2 || a1 == a3 || a2 == a3)
                {
                    continue;
                }
                else
                {
                    singleQuestion.Add(allQuestions[a1].Answer);
                    singleQuestion.Add(allQuestions[a2].Answer);
                    singleQuestion.Add(allQuestions[a3].Answer);
                }
            } while (singleQuestion.Count < 4);
            // do-while loop which is ordering answers in text blocks
            do
            {
                int a1 = random.Next(0, 4);
                int a2 = random.Next(0, 4);
                int a3 = random.Next(0, 4);
                int a4 = random.Next(0, 4);
                if (a1 == a4 || a2 == a4 || a3 == a4 || a1 == a2 || a1 == a3 || a2 == a3)
                {
                    continue;
                }
                else
                {
                    randomSort = 4;
                    answer1.Text = singleQuestion[a1];
                    answer2.Text = singleQuestion[a2];
                    answer3.Text = singleQuestion[a3];
                    answer4.Text = singleQuestion[a4];
                }
            } while (randomSort < 3);
        }

        // Reset data from last question
        private void ResetQuestionData()
        {
            singleQuestion.RemoveRange(0, 4);
            randomSort = 0;
        }

        // Getting all questions and answers from database to List of type Questions
        private void GetAllQuestions()
        {
            using (QuestionsContext context = new QuestionsContext())
            {
                var result = context.Questions.ToList();
                foreach (var r in result)
                {
                    allQuestions.Add(r);
                }
            }
        }

        // Button click event for getting new question
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            answer1.Background = new SolidColorBrush(Colors.Transparent);
            answer2.Background = new SolidColorBrush(Colors.Transparent);
            answer3.Background = new SolidColorBrush(Colors.Transparent);
            answer4.Background = new SolidColorBrush(Colors.Transparent);
            ResetQuestionData();
            GetQuestion();
        }

        #region Coloring answer fields

        // Changing text and border color withing hovering answer 1
        private void answer1_MouseMove(object sender, MouseEventArgs e)
        {
            answer1.Foreground = new SolidColorBrush(Colors.Aqua);
            border1.BorderBrush = new SolidColorBrush(Colors.Aqua);
        }
        // Removing color after mouse leave field with answer 1
        private void answer1_MouseLeave(object sender, MouseEventArgs e)
        {
            answer1.Foreground = new SolidColorBrush(Colors.White);
            border1.BorderBrush = new SolidColorBrush(Colors.White);
        }
        // Changing text and border color withing hovering answer 2
        private void answer2_MouseMove(object sender, MouseEventArgs e)
        {
            answer2.Foreground = new SolidColorBrush(Colors.Aqua);
            border2.BorderBrush = new SolidColorBrush(Colors.Aqua);
        }
        // Removing color after mouse leave field with answer 2
        private void answer2_MouseLeave(object sender, MouseEventArgs e)
        {
            answer2.Foreground = new SolidColorBrush(Colors.White);
            border2.BorderBrush = new SolidColorBrush(Colors.White);
        }
        // Changing text and border color withing hovering answer 3
        private void answer3_MouseMove(object sender, MouseEventArgs e)
        {
            answer3.Foreground = new SolidColorBrush(Colors.Aqua);
            border3.BorderBrush = new SolidColorBrush(Colors.Aqua);
        }
        // Removing color after mouse leave field with answer 3
        private void answer3_MouseLeave(object sender, MouseEventArgs e)
        {
            answer3.Foreground = new SolidColorBrush(Colors.White);
            border3.BorderBrush = new SolidColorBrush(Colors.White);
        }
        // Changing text and border color withing hovering answer 4
        private void answer4_MouseMove(object sender, MouseEventArgs e)
        {
            answer4.Foreground = new SolidColorBrush(Colors.Aqua);
            border4.BorderBrush = new SolidColorBrush(Colors.Aqua);
        }
        // Removing color after mouse leave field with answer 4
        private void answer4_MouseLeave(object sender, MouseEventArgs e)
        {
            answer4.Foreground = new SolidColorBrush(Colors.White);
            border4.BorderBrush = new SolidColorBrush(Colors.White);
        }
        #endregion

        #region Logic for events for bad and correct answers
        private void answer1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var selectedAnswer = sender as TextBlock;
            if (selectedAnswer.Text == singleQuestion[0])
            {
                answer1.Background = new SolidColorBrush(Colors.Green);
                questionNumber++;
                answersInRow++;
            }
            else
            {
                if (answer2.Text == singleQuestion[0])
                {
                    answer2.Background = new SolidColorBrush(Colors.Green);
                }
                if (answer3.Text == singleQuestion[0])
                {
                    answer3.Background = new SolidColorBrush(Colors.Green);
                }
                if (answer4.Text == singleQuestion[0])
                {
                    answer4.Background = new SolidColorBrush(Colors.Green);
                }
                answer1.Background = new SolidColorBrush(Colors.Red);
                answersInRow = 0;
                questionNumber++;
            }
        }
        private void answer2_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var selectedAnswer = sender as TextBlock;
            if (selectedAnswer.Text == singleQuestion[0])
            {
                answer2.Background = new SolidColorBrush(Colors.Green);
                questionNumber++;
                answersInRow++;
            }
            else
            {
                if (answer1.Text == singleQuestion[0])
                {
                    answer1.Background = new SolidColorBrush(Colors.Green);
                }
                if (answer3.Text == singleQuestion[0])
                {
                    answer3.Background = new SolidColorBrush(Colors.Green);
                }
                if (answer4.Text == singleQuestion[0])
                {
                    answer4.Background = new SolidColorBrush(Colors.Green);
                }
                answer2.Background = new SolidColorBrush(Colors.Red);
                answersInRow = 0;
                questionNumber++;
            }
        }
        private void answer3_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var selectedAnswer = sender as TextBlock;
            if (selectedAnswer.Text == singleQuestion[0])
            {
                answer3.Background = new SolidColorBrush(Colors.Green);
                questionNumber++;
                answersInRow++;
            }
            else
            {
                if (answer1.Text == singleQuestion[0])
                {
                    answer1.Background = new SolidColorBrush(Colors.Green);
                }
                if (answer2.Text == singleQuestion[0])
                {
                    answer2.Background = new SolidColorBrush(Colors.Green);
                }
                if (answer4.Text == singleQuestion[0])
                {
                    answer4.Background = new SolidColorBrush(Colors.Green);
                }
                answer3.Background = new SolidColorBrush(Colors.Red);
                answersInRow = 0;
                questionNumber++;
            }
        }
        private void answer4_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var selectedAnswer = sender as TextBlock;
            if (selectedAnswer.Text == singleQuestion[0])
            {
                answer4.Background = new SolidColorBrush(Colors.Green);
                questionNumber++;
                answersInRow++;
            }
            else
            {
                if (answer1.Text == singleQuestion[0])
                {
                    answer1.Background = new SolidColorBrush(Colors.Green);
                }
                if (answer2.Text == singleQuestion[0])
                {
                    answer2.Background = new SolidColorBrush(Colors.Green);
                }
                if (answer3.Text == singleQuestion[0])
                {
                    answer3.Background = new SolidColorBrush(Colors.Green);
                }
                answer4.Background = new SolidColorBrush(Colors.Red);
                answersInRow = 0;
                questionNumber++;
            }
        }
        #endregion
    }
}
