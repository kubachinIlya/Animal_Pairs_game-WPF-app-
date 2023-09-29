using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;


namespace Animal_Pairs_game

{
    using System.Windows.Threading;
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timer = new DispatcherTimer();
        int tenthsOfSecondsElapsed;
        int matchesFound;
        int LifeCounter = 3;
        public MainWindow()
        {
            InitializeComponent();
            timer.Interval = TimeSpan.FromSeconds(.1);
            timer.Tick += Timer_Tick;
            SetupGame();

        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            tenthsOfSecondsElapsed++;
            timeTextBlock.Text = (tenthsOfSecondsElapsed / 10F).ToString("0.0s");
            if (matchesFound == 8)
            {
                timer.Stop();
                timeTextBlock.Text = timeTextBlock.Text + " - Play again? Click Restart button";
            }
        }

        public void SetupGame()
        {
            List<string> animalEmoji = new List<string>()
            {
                "🐷", "🐷",
                "🐮", "🐮",
                "🦊", "🦊",
                "🐒", "🐒",

                "🐌", "🐌",
                "🕷", "🕷",
                "🐶", "🐶",
                "🐔", "🐔",

            };
            Random random = new Random();
            foreach (TextBlock textBlock in mainGrid.Children.OfType<TextBlock>())
            {
                if (textBlock.Name != "timeTextBlock" && textBlock.Name != "HealthBlock" && textBlock.Name != "YourLives")
                {
                    textBlock.Visibility = Visibility.Visible;
                    int index = random.Next(animalEmoji.Count);
                    string nextEmoji = animalEmoji[index];
                    textBlock.Text = nextEmoji;
                    animalEmoji.RemoveAt(index);
                }
            }
            timer.Start();
            tenthsOfSecondsElapsed = 0;
            matchesFound = 0;
            HealthBlock.Text = "❤️❤️❤️";
            LifeCounter = 3;

        }

        TextBlock lastTextBlockClicked;
        bool findingMatch = false;
        private void TextBlock_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            TextBlock textBlock = sender as TextBlock;
            if (findingMatch == false)
            {
                textBlock.Visibility = Visibility.Hidden;
                lastTextBlockClicked = textBlock;
                findingMatch = true;
            }
            else if (textBlock.Text == lastTextBlockClicked.Text)
            {
                matchesFound++;
                textBlock.Visibility = Visibility.Hidden;
                findingMatch = false;
            }
            else
            {
                lastTextBlockClicked.Visibility = Visibility.Visible;
                findingMatch = false;
                MinusLife();
                if (LifeCounter == 0)
                {
                    timer.Stop();
                    timeTextBlock.Text = timeTextBlock.Text + " Loser, click restart and try again";
                }
            }
        }

        private void MinusLife()
        {
            LifeCounter -= 1;
            if (LifeCounter == 3) HealthBlock.Text = "❤️❤️❤️";
            if (LifeCounter == 2) HealthBlock.Text = "❤️❤";
            if (LifeCounter == 1) HealthBlock.Text = "❤️";
            if (LifeCounter == 0) HealthBlock.Text = "you died))))";
        }

        private void TimeTextBlock_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (matchesFound == 8)
            {
                //
            }
        }

        private void restartGame(object sender, RoutedEventArgs e)
        {
            SetupGame();
        }
    }
}
