using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static readonly HttpClient client = new HttpClient();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TextBlock tb1 = this.FindName("tb1") as TextBlock;
            
            HttpClient client = new HttpClient();
            Task<string> task = client.GetStringAsync("http://mac.local:5000/WeatherForecast");
            tb1.Text = task.Result;
        }

        private static async Task<string> ProcessRepositories()
        {
            client.DefaultRequestHeaders.Add(
                   "User-Agent",
                   "Mozilla/5.0 (Windows NT 6.3; Trident/7.0; rv:11.0) like Gecko");

            client.DefaultRequestHeaders.Add("Accept-Language", "ja-JP");
            client.Timeout = TimeSpan.FromSeconds(10.0);
            //            return await client.GetStringAsync("http://mac.local:5000/WeatherForecast");
            try
            {
                return await client.GetStringAsync("http://www.yahoo.co.jp");
            }
            catch (Exception e)
            {
                Console.WriteLine("##########################");
                Console.WriteLine("例外発生:{0}", e);
                Console.WriteLine("##########################");
            }
            return null;
        }
    }
}
