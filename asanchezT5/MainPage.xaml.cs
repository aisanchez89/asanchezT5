using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace asanchezT5
{
    public partial class MainPage : ContentPage
    {
        private string Url = "http://192.168.100.65/wsisrael/post.php";
        private HttpClient cliente = new HttpClient();
        private ObservableCollection<Ruta> post;
        public MainPage()
        {
            InitializeComponent();
        }

        private async void btnMostrar_Clicked(object sender, EventArgs e)
        {
            var contenido = await cliente.GetStringAsync(Url);
            List<Ruta> listaPost = JsonConvert.DeserializeObject<List<Ruta>>(contenido);
            post = new ObservableCollection<Ruta>(listaPost);
            RutasRegistradas.ItemsSource = post;
        }
    }
}
