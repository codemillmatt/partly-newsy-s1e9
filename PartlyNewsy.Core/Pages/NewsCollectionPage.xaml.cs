using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PartlyNewsy.Models;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace PartlyNewsy.Core
{    
    public partial class NewsCollectionPage : ContentPage
    {
        public NewsCollectionPage()
        {
            InitializeComponent();
        }
        bool isLoaded = false;

        string categoryName;
        public string CategoryName
        {
            get => categoryName;
            set
            {
                categoryName = value;
                OnPropertyChanged(nameof(CategoryName));
            }
        }

        string localityName;
        public string LocalityName
        {
            get => localityName;
            set
            {
                localityName = value;
                OnPropertyChanged(nameof(LocalityName));
            }
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            await GetData();
        }

        async Task GetData()
        {
            var svc = new NewsService();

            List<Article> articles;

            if (string.IsNullOrWhiteSpace(CategoryName))
            {
                articles = await svc.GetTopNews();
            }
            else if (CategoryName == "local")
            {
                var query = await GetLastLocation() ?? await GetFullLocation();

                titleLabel.Text = $"{query} News";

                articles = await svc.GetLocalNews(query);
            }
            else
            {
                articles = await svc.GetNewsByCategory(CategoryName);
            }

            newsList.ItemsSource = articles;
        }

        protected async void newsListItemSelected(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection[0] is Article article)
            {
                var url = Uri.EscapeDataString(article.ArticleUrl);

                await Shell.Current.GoToAsync($"articledetail?articleUrl={url}", true);

                //newsList.SelectedItem = null;
            } 
        }

        async Task<string> GetLastLocation()
        {
            Location location = null;

            try
            {
                location = await Geolocation.GetLastKnownLocationAsync();

                if (location != null)
                {
                    var placemarks = await Geocoding.GetPlacemarksAsync(location);

                    return placemarks.FirstOrDefault()?.Locality;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
            }

            return null;
        }

        async Task<string> GetFullLocation()
        {
            Location location = null;

            try
            {
                location = await Geolocation.GetLocationAsync();

                if (location != null)
                {
                    var placemarks = await Geocoding.GetPlacemarksAsync(location);

                    return placemarks.FirstOrDefault()?.Locality;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
            }

            return null;
        }
    }
}
