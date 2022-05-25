using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Text;

namespace API_TEST_CLIENT
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            HttpClient client = new HttpClient();
            AnimeReturn anime = new AnimeReturn
            {
                ID_Anime = 15,
                imgPath = "КикиПупу.пнг",
                TitleCritic = 8.3f,
                TitleGenre = "Мистика",
                TitleName = "ЫыыыЫЫЫ АНЕМЕ",
                TitleYear = 2012
            };

            var httpContent = new StringContent(System.Text.Json.JsonSerializer.Serialize(anime), Encoding.UTF8, "application/json");
            Uri uri = new Uri($"http://localhost:58566/api/ListOfAnimes/");
            await client.PostAsync(uri, httpContent);

            var content = await client.GetStringAsync($"http://localhost:58566/api/ListOfAnimes");
            List <AnimeReturn> json = JsonConvert.DeserializeObject<List<AnimeReturn>>(content);

            dataGrid.ItemsSource = json;
        }

        /// <summary>
        /// Комментарий для Session2
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void reloadButton_Click(object sender, RoutedEventArgs e)
        {
            HttpClient client = new HttpClient();
            if (!string.IsNullOrWhiteSpace(yearTextBox.Text))
            {
                var content = await client.GetStringAsync($"http://localhost:58566/api/ListOfAnimes/{yearTextBox.Text}");
                //AnimeReturn json = JsonConvert.DeserializeObject<AnimeReturn>(content); 
                AnimeReturn json = System.Text.Json.JsonSerializer.Deserialize<AnimeReturn>(content);
                string imgPath = json.imgPath.ToString();

                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(imgPath, UriKind.Absolute);
                bitmap.EndInit();

                //dataGrid.ItemsSource = json;
                animeCoverImage.Source = bitmap;
            }
            else
            {
                var content = await client.GetStringAsync($"http://localhost:58566/api/ListOfAnimes");
                List<AnimeReturn> json = JsonConvert.DeserializeObject<List<AnimeReturn>>(content);

                dataGrid.ItemsSource = json;
            }
        }

        private async void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            HttpClient httpClient = new HttpClient();
            Uri uri = new Uri($"http://localhost:58566/api/ListOfAnimes/{yearTextBox.Text}");
            await httpClient.DeleteAsync(uri);
        }

        private async void putButton_Click(object sender, RoutedEventArgs e)
        {
            HttpClient httpClient = new HttpClient();
            Uri uri = new Uri($"http://localhost:58566/api/ListOfAnimes/{yearTextBox.Text}");

            AnimeReturn animeReturn = new AnimeReturn
            {
                ID_Anime = Convert.ToInt32(yearTextBox.Text),
                imgPath = "Изменённое.пнг",
                TitleCritic = 10.0f,
                TitleGenre = "Изменённое",
                TitleName = "Изменённое АНЕМЕ",
                TitleYear = 2077
            };

            HttpContent httpContent = new StringContent(System.Text.Json.JsonSerializer.Serialize(animeReturn), Encoding.UTF8, "application/json");


            await httpClient.PutAsync(uri, httpContent);

            var content = await httpClient.GetStringAsync($"http://localhost:58566/api/ListOfAnimes");
            List<AnimeReturn> json = JsonConvert.DeserializeObject<List<AnimeReturn>>(content);

            dataGrid.ItemsSource = json;
        }
    }
}