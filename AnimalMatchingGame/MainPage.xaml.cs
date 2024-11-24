using System.ComponentModel.Design;
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
        }

        private void PlayAgainButton_Clicked(object sender, EventArgs e)
        {
            AnimalsButtons.IsVisible = true;
            PlayAgainButton.IsVisible = false;

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
            Dispatcher.StartTimer(TimeSpan.FromSeconds(.1), TimerTick);
        }


        int tenthsOfSecondsElapsed = 0;
        private bool TimerTick()
        {
            if (!this.IsLoaded) return false;
            tenthsOfSecondsElapsed++;
            TimeElapsed.Text = "Time elapsed: " +
            (tenthsOfSecondsElapsed / 10F).ToString("0.0s");
            if (PlayAgainButton.IsVisible)
            {
                tenthsOfSecondsElapsed = 0;
                return false;
            }
            return true;

        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            if (sender is Button buttonClicked)
            {
                if (!string.IsNullOrWhiteSpace(buttonClicked.Text) && (findingMatch == false))
                {

                    buttonClicked.BackgroundColor = Colors.Red;
                    lastClicked = buttonClicked;
                    findingMatch = true;
                }
                else
                {
                    if ((buttonClicked != lastClicked) && (buttonClicked.Text == lastClicked.Text) && (!string.IsNullOrWhiteSpace(buttonClicked.Text)))
                    {
                        lastClicked.BackgroundColor = Colors.LightGreen;
                        buttonClicked.BackgroundColor = Colors.LightGreen;
                        matchesFound++;
                        lastClicked.Text = " ";
                        buttonClicked.Text = " ";


                    }
                    else
                    {
                        lastClicked.BackgroundColor = Colors.LightBlue;
                        buttonClicked.BackgroundColor = Colors.LightBlue;

                    }
                    
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
                    button.BackgroundColor = Colors.LightBlue;
                }
            }
        }   
    }
}
