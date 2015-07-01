using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Learn_Vietnamese.Resources;
using Learn_Vietnamese.ViewModels;
using System.Diagnostics;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using System.Net.Http;
using Learn_Vietnamese.Model;
using Windows.System;
using System.Windows.Media;

namespace Learn_Vietnamese
{
    public partial class MainPage : PhoneApplicationPage
    {
        public List<YoutubeVideo> vlist { get; set; }
        int isSearch = 0;
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // Set the data context of the LongListSelector control to the sample data
            DataContext = App.ViewModel;
            
        }

        // Load data for the ViewModel Items
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (!App.ViewModel.IsDataLoaded)
            {
                App.ViewModel.LoadData();
            }

            if(!App.YouTubeModel.IsDataLoaded)
            {
                App.YouTubeModel.LoadData();
            }

            PlaylistVideos.ItemsSource = App.YouTubeModel.vlinks;

            List<MoTa> mt = new List<MoTa>();
            mt.Add(new MoTa("Url", "SHTP-TRAINING", "/Assets/Item-53e88f6f-42e4-4d2c-ab41-a8d568894434.png", "bingmaps:?cp=10.855064~106.785569&lvl=17"));
            mt.Add(new MoTa("Url", "Address: Lô E1 – Khu Công nghệ cao, Xa lộ Hà Nội, Phường Hiệp Phú, Quận 9, TP.HCM", "/Assets/location.png", "bingmaps:?cp=10.855064~106.785569&lvl=17"));
            mt.Add(new MoTa("Phone", "Phone: (84-8) 39.322.230 (17) ", "/Assets/phoneicon.png", "tel:(84-8) 39.322.230 (17)"));
            mt.Add(new MoTa("Phone", "Learn Vietnamese", "/Assets/ApplicationIcon.png", "tel:(84-8) 39.322.230 (17)"));
            mt.Add(new MoTa("Url", "Author: tungnt92", "/Assets/User-Monitor.png", ""));
            mt.Add(new MoTa("Url", "Version: 1.0.0", "/Assets/Download.png", ""));
            ListMT.ItemsSource = mt;

            SolidColorBrush sl = new SolidColorBrush();
            sl.Color = Color.FromArgb(0, 0, 100, 170);
            SystemTray.SetBackgroundColor(this, sl.Color);
        }

        // Handle selection changed on LongListSelector
        private void MainLongListSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // If selected item is null (no selection) do nothing
            if (MainLongListSelector.SelectedItem == null)
                return;

            // Navigate to the new page
            NavigationService.Navigate(new Uri("/DetailsPage.xaml?selectedItem=" + (MainLongListSelector.SelectedItem as ItemViewModel).ID + "&linkAudio=" + (MainLongListSelector.SelectedItem as ItemViewModel).Link + "&trackAudio=" + (MainLongListSelector.SelectedItem as ItemViewModel).Track, UriKind.Relative));

            // Reset selected item to null (no selection)
            MainLongListSelector.SelectedItem = null;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (isSearch == 0)
            {
                if (txtsearch.Text != null)
                {
                    SecondLongListSelector.ItemsSource = App.ViewModel.Items.Where(x => x.LineOne.ToLower().Contains(txtsearch.Text.ToLower())).ToList();
                }
            }
            else
            {
                if (txtsearch.Text != null)
                {
                    SecondVideoLongListSelector.ItemsSource = App.YouTubeModel.vlinks.Where(x => x.Title.ToLower().Contains(txtsearch.Text.ToLower())).ToList();
                }
            }
        }

        private void SecondLongListSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // If selected item is null (no selection) do nothing
            if (SecondLongListSelector.SelectedItem == null)
                return;

            // Navigate to the new page
            NavigationService.Navigate(new Uri("/DetailsPage.xaml?selectedItem=" + (SecondLongListSelector.SelectedItem as ItemViewModel).ID + "&linkAudio=" + (SecondLongListSelector.SelectedItem as ItemViewModel).Link + "&trackAudio=" + (SecondLongListSelector.SelectedItem as ItemViewModel).Track, UriKind.Relative));

            // Reset selected item to null (no selection)
            SecondLongListSelector.SelectedItem = null;
        }

        private void VideosList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            YoutubeVideo video = e.AddedItems[0] as YoutubeVideo;
            if (video != null)
                NavigationService.Navigate(new Uri("/VideoPage.xaml?videoLink=" + video.VideoLink, UriKind.Relative));
        }

        private void ToggleSwitch_Checked(object sender, RoutedEventArgs e)
        {
            SecondVideoLongListSelector.Visibility = Visibility.Visible;
            SecondLongListSelector.Visibility = Visibility.Collapsed;
            isSearchLesson.Content = "Video";
            isSearch = 1;
            
        }

        private void ToggleSwitch_Unchecked(object sender, RoutedEventArgs e)
        {
            SecondLongListSelector.Visibility = Visibility.Visible;
            SecondVideoLongListSelector.Visibility = Visibility.Collapsed;
            isSearchLesson.Content = "Lesson";
            isSearch = 0;
            
        }

        private void SecondVideoLongListSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            YoutubeVideo video = e.AddedItems[0] as YoutubeVideo;
            if (video != null)
                NavigationService.Navigate(new Uri("/VideoPage.xaml?videoLink=" + video.VideoLink, UriKind.Relative));
        }

        private async void ListMT_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListMT.SelectedItem != null)
            {
                if (((MoTa)ListMT.SelectedItem).Target != "")
                {
                    await Launcher.LaunchUriAsync(new Uri(((MoTa)ListMT.SelectedItem).Target, UriKind.Absolute));
                }
            }
            ListMT.SelectedIndex = -1;
        }
    }
}