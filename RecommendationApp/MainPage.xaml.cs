using System.Text;
using System.Text.Json;

namespace RecommendationApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnPredictClicked(object sender, EventArgs e)
        {
            string BaseAddress = DeviceInfo.Platform == DevicePlatform.Android
                    ? "https://10.0.2.2:55952" : "https://localhost:55952";
#if DEBUG
            HttpsClientHandlerService handler = new HttpsClientHandlerService();
            HttpClient Client = new HttpClient(handler.GetPlatformMessageHandler());
#else
            HttpClient Client = new HttpClient();
#endif
            object data = new
            {
                UserId = UserId.Text,
                MovieId = MovieId.Text,
            };
            string Uri = $"{BaseAddress}/predict";
            string strContent = JsonSerializer.Serialize(data);
            var content = new StringContent(strContent, Encoding.UTF8, "application/json");
            HttpResponseMessage Response = await Client.PostAsync(Uri, content);
            Response.EnsureSuccessStatusCode();
            string Json = await Response.Content.ReadAsStringAsync();
            var Result = JsonSerializer.Deserialize<ModelOutput>(Json);
            float Score = Result.score;
            await DisplayAlert("預測電影評論分數", $"{Score:N2}分", "關閉");
        }
    }
}
