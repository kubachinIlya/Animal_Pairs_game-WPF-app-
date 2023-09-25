using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;


namespace Animal_Pairs_game
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            SetupGame();

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
                int index = random.Next(animalEmoji.Count);
                string
                nextEmoji = animalEmoji[index];
                textBlock.Text = nextEmoji;
                animalEmoji.RemoveAt(index);
            }

        }
    }
}
