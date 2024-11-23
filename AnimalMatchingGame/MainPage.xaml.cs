using System.Runtime.CompilerServices;

namespace AnimalMatchingGame
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
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
                "🐮","🐮",
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

        }
    }

}
