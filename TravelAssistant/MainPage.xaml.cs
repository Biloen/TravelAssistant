using System.Net;
//using ThreadNetwork;

namespace TravelAssistant
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            count++;

            /*if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);*/
        }

        private void UpdateClicked(object sender, EventArgs e)
        {
            GetCurrency();
        }
        async public void GetCurrency()
        {
            using HttpClient client = new HttpClient();

            HttpResponseMessage response = await client.GetAsync("https://api.nbp.pl/api/exchangerates/rates/a/chf/");
            response.EnsureSuccessStatusCode();
            string requestBody = await response.Content.ReadAsStringAsync();

            DisplayAlert("", requestBody, "");

        }


    }
}
