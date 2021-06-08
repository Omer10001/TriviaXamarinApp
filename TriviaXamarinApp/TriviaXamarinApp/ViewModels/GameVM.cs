using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using TriviaXamarinApp.Views;
using System.Windows.Input;
using TriviaXamarinApp.Models;
using TriviaXamarinApp.Services;

namespace TriviaXamarinApp.ViewModels
{
    class Answer
    {
        public string Text { get; set; }
        public bool IsCorrect { get; set; }
    }
    class GameVM : INotifyPropertyChanged
    {
        #region INOTIFYEVENT
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
        private TriviaWebAPIProxy proxy;
        public AmericanQuestion Question { get; set; }
        public Answer[] Answers { get; set; }
        private string answer1;
        public string Answer1
        {
            get
            {
                return answer1;
            }
            set
            {
                if (answer1 != value)
                {
                    answer1 = value;
                    OnPropertyChanged("Answer1");
                }
            }
        }
        private string answer2;
        public string Answer2
        {
            get
            {
                return answer2;
            }
            set
            {
                if (answer2 != value)
                {
                    answer2 = value;
                    OnPropertyChanged("Answer2");
                }
            }
        }
        private string answer3;
        public string Answer3
        {
            get
            {
                return answer3;
            }
            set
            {
                if (answer3 != value)
                {
                    answer3 = value;
                    OnPropertyChanged("Answer3");
                }
            }
        }
        private string answer4;
        public string Answer4
        {
            get
            {
                return answer4;
            }
            set
            {
                if (answer4 != value)
                {
                    answer4 = value;
                    OnPropertyChanged("Answer4");
                }
            }
        }
        private bool hasAnswered;
        public bool HasAnswered
        {
            get
            {
                return hasAnswered;
            }
            set
            {
                if (hasAnswered != value)
                {
                    hasAnswered = value;
                    OnPropertyChanged("HasAnswered");
                }
            }
        }
        private string questionText;
        public string QuestionText
        {
            get
            {
                return questionText;
            }
            set
            {
                if (questionText != value)
                {
                    questionText = value;
                    OnPropertyChanged("QuestionText");
                }
            }
        }
        private int counter;
        public int Counter
        {
            get
            {
                return counter;
            }
            set
            {
                if (counter != value)
                {
                    counter = value;
                    OnPropertyChanged("Counter");
                    this.CounterText = $"You Answered {counter} corrects answers in a row";
                }
            }
        }
        private string counterText;
        public string CounterText
        {
            get
            {
                return counterText;
            }
            set
            {
                if (this.counterText != value)
                {
                    this.counterText = value;
                    OnPropertyChanged("CounterText");
                }
            }
        }
        
        private string result;
        public string Result
        {
            get
            {
                return result;
            }
            set
            {
                if (result != value)
                {
                    result = value;
                    OnPropertyChanged("Result");
                }
            }
        }
        //public Command CommandNameAnswer { get; set; }
        //public Command CommandNameNextQuestion { get; set; }
        public GameVM()
        {
            Answers = new Answer[4];
            CounterText = "You Answered 0 corrects answers in a row";
            HasAnswered = false;
            //CommandNameAnswer = new Command<int>(AnswerClicked);
            //CommandNameNextQuestion = new Command(GetNextQuestion);
            //CommandNameNextQuestion.ChangeCanExecute();
            proxy = TriviaWebAPIProxy.CreateProxy();
            Counter = 0;
            SetUpQuestion();
        }
        public async void SetUpQuestion()
        {
            
            Question = await proxy.GetRandomQuestion();
            QuestionText = Question.QText;

            
            Random r = new Random();
            int correct = r.Next(0, 4);
            int x = 0;
            for (int i = 0; i < Answers.Length; i++)
            {
                if (i == correct)
                {
                    Answers[i] = new Answer { Text= Question.CorrectAnswer, IsCorrect = true};
                }
                else
                {
                    Answers[i] = new Answer { Text = Question.OtherAnswers[x], IsCorrect = false };
                    x++;
                }
            }
            Answer1 = Answers[0].Text;
            Answer2 = Answers[1].Text;
            Answer3 = Answers[2].Text;
            Answer4 = Answers[3].Text;
        }
        public ICommand AnswerClickedCommand => new Command<string>(AnswerClicked);
        public ICommand NextQuestionCommand =>  new Command(GetNextQuestion);
        public void AnswerClicked(string str)
        {
            int num = int.Parse(str);
            if(!HasAnswered)
            {
                if (Answers[num].Text == Question.CorrectAnswer)
                {
                    Result = "You are correct";
                    Counter++;
                }
                else
                {
                    Result = "You are incorrect";
                    Counter = 0;
                }
                HasAnswered = true;
            }
            
            //CommandNameNextQuestion.ChangeCanExecute();
            //CommandNameAnswer.ChangeCanExecute();
        }
        public async void GetNextQuestion()
        {
            if (!HasAnswered)
            {
                Result = "answer the question first";
            }
            else
            {
                Question = await proxy.GetRandomQuestion();
                QuestionText = Question.QText;
                Random r = new Random();
                int correct = r.Next(0, 4);
                int x = 0;
                for (int i = 0; i < Answers.Length; i++)
                {
                    if (i == correct)
                    {
                        Answers[i] = new Answer { Text = Question.CorrectAnswer, IsCorrect = true };
                    }
                    else
                    {
                        Answers[i] = new Answer { Text = Question.OtherAnswers[x], IsCorrect = false };
                        x++;
                    }
                }
                Answer1 = Answers[0].Text;
                Answer2 = Answers[1].Text;
                Answer3 = Answers[2].Text;
                Answer4 = Answers[3].Text;

                Result = "";
                HasAnswered = false;
                //CommandNameNextQuestion.ChangeCanExecute();
                //CommandNameAnswer.ChangeCanExecute();
            }


        }

    }
}
