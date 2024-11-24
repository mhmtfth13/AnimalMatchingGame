using System.Runtime.CompilerServices;

namespace AnimalMatchingGame
{
    public partial class MainPage : ContentPage
    {
        int count = 0;
        Button lastClicked;
        bool findingMatch = false;
        int matchesFound;

        public MainPage()
        {
            InitializeComponent();
            //PlayAgainButton_Clicked(null, null);
            //PlayAgainButton.IsVisible = false;
        }

        private void PlayAgainButton_Clicked(object sender, EventArgs e)
        {
            AnimalsButtons.IsVisible= true;
            PlayAgainButton.IsVisible= false;

            List<string> animalEmoji = [
                "🐼", "🐼",
                "🐦‍⬛","🐦‍⬛",
                "🐿️","🐿️",
                "🦄","🦄",
                "🐈‍⬛","🐈‍⬛",
                "🐮","🐮",
                "🦩","🦩",
                "🦈","🦈"
            ];
            foreach (var button in AnimalsButtons.Children.OfType<Button>())
            { 
                int index = Random.Shared.Next(animalEmoji.Count);
                string nextEmoji = animalEmoji[index];
                button.Text = nextEmoji;
                animalEmoji.RemoveAt(index);
            }

        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            if (sender is Button buttonClicked)
            {
                if (!string.IsNullOrEmpty(buttonClicked.Text) && (findingMatch == false))
                {
                    buttonClicked.Background = Colors.Red;
                    lastClicked = buttonClicked;
                    findingMatch = true;
                }
                else
                {
                    if ((buttonClicked != lastClicked) && (buttonClicked.Text == lastClicked.Text) && (!String.IsNullOrWhiteSpace(buttonClicked.Text)))
                    {
                        matchesFound++;
                        lastClicked.Text = " ";
                        buttonClicked.Text = " ";
                    }
                    lastClicked.Background = Colors.LightGreen;
                    buttonClicked.BackgroundColor = Colors.LightGreen;
                    findingMatch = false;
                }
            }
            if (matchesFound == 8)
            { 
                matchesFound = 0;
                AnimalsButtons.IsVisible = false;
                PlayAgainButton.IsVisible = true;
                foreach (var button in AnimalsButtons.Children.OfType<Button>())
                {
                    button.Background = Colors.LightBlue;
                }
            }
        }
    }

}
