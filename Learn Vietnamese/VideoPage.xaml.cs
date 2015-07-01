using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Net.NetworkInformation;
using MyToolkit.Multimedia;

namespace Learn_Vietnamese
{
    public partial class VideoPage : PhoneApplicationPage
    {
        public VideoPage()
        {
            InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            try
            {
                if (NetworkInterface.GetIsNetworkAvailable())
                {
                    string videoLink = String.Empty;
                    if (NavigationContext.QueryString.TryGetValue("videoLink", out videoLink))
                    {
                        //Get The Video Uri and set it as a player source
                        //var url = await YouTube.GetVideoUriAsync(videoLink, YouTubeQuality.Quality480P);
                        //player.Source = url.Uri;
                        player.Source = new Uri("https://www.youtube.com/embed/" + videoLink, UriKind.Absolute); 
                    }
                }
                else
                {
                    MessageBox.Show("You're not connected to Internet!");
                    NavigationService.GoBack();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

            base.OnNavigatedTo(e);
        }
    }
}