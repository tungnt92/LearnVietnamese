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
using Microsoft.Phone.BackgroundAudio;
using System.Diagnostics;
using System.IO;
using System.IO.IsolatedStorage;
using System.Runtime.Serialization.Json;
using Learn_Vietnamese.ViewModels;
using Newtonsoft.Json;
using System.Windows.Media;

namespace Learn_Vietnamese
{
    public partial class DetailsPage : PhoneApplicationPage
    {
        AudioTrack GABAudio;
        bool isClicked = true;

        // Constructor
        public DetailsPage()
        {
            InitializeComponent();

            ApplicationBar = new ApplicationBar();

            ApplicationBarIconButton playAppbar = new ApplicationBarIconButton();
            playAppbar.IconUri = new Uri("/Assets/AppBar/transport.play.png", UriKind.Relative);
            playAppbar.Text = "play";
            ApplicationBar.Buttons.Add(playAppbar);
            playAppbar.Click += new EventHandler(playAppbar_Click);

            ApplicationBarIconButton homeAppbar = new ApplicationBarIconButton();
            homeAppbar.IconUri = new Uri("/Assets/AppBar/calendar.png", UriKind.Relative);
            homeAppbar.Text = "fav";
            ApplicationBar.Buttons.Add(homeAppbar);
            homeAppbar.Click += new EventHandler(homeAppbar_Click);

            BackgroundAudioPlayer.Instance.PlayStateChanged += new EventHandler(Instance_PlayStateChanged);
        }
        protected void Instance_PlayStateChanged(object sender, EventArgs e)
        {
            ApplicationBarIconButton playbtn = (ApplicationBarIconButton)ApplicationBar.Buttons[0];
            switch (BackgroundAudioPlayer.Instance.PlayerState)
            {
                case PlayState.Playing:
                    playbtn.Text = "pause";
                    playbtn.IconUri = new Uri("/Assets/AppBar/transport.pause.png", UriKind.Relative);
                    
                    break;

                case PlayState.Paused:

                case PlayState.Stopped:
                    playbtn.Text = "play";
                    playbtn.IconUri = new Uri("/Assets/AppBar/transport.play.png", UriKind.Relative);
                    break;
            }
        }

        private void homeAppbar_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
            
        }

        // When page is navigated to set data context to selected item in list
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (DataContext == null)
            {
                string selectedIndex = "";
                if (NavigationContext.QueryString.TryGetValue("selectedItem", out selectedIndex))
                {
                    int index = int.Parse(selectedIndex);
                    DataContext = App.ViewModel.Items[index];
                }
            }

            ApplicationBarIconButton playbtn = (ApplicationBarIconButton)ApplicationBar.Buttons[0];
            if (PlayState.Playing == BackgroundAudioPlayer.Instance.PlayerState)
            {
                playbtn.Text = "pause";
                playbtn.IconUri = new Uri("/Assets/AppBar/transport.pause.png", UriKind.Relative);
            }
            else
            {
                playbtn.Text = "play";
                playbtn.IconUri = new Uri("/Assets/AppBar/transport.play.png", UriKind.Relative);
            }

            SolidColorBrush sl = new SolidColorBrush();
            sl.Color = Color.FromArgb(0, 0, 100, 170);
            SystemTray.SetBackgroundColor(this, sl.Color);
        }

        private void playAppbar_Click(object sender, EventArgs e)
        {
            if (isClicked)
            {
                string link = "";
                string audioLink = "";
                if (NavigationContext.QueryString.TryGetValue("linkAudio", out link))
                {
                    audioLink = link.ToString();
                }

                string track = "";
                string audioTrack = "";
                if (NavigationContext.QueryString.TryGetValue("trackAudio", out track))
                {
                    audioTrack = track.ToString();
                }

                GABAudio = new AudioTrack(new Uri(audioLink, UriKind.Absolute), audioTrack, null, null, null, null, EnabledPlayerControls.All);
                BackgroundAudioPlayer.Instance.Track = GABAudio;
                
                isClicked = false;
            }
            if (PlayState.Playing == BackgroundAudioPlayer.Instance.PlayerState)
            {
                BackgroundAudioPlayer.Instance.Pause();
                //MessageBox.Show("Pause");
            }
            else
            {
                BackgroundAudioPlayer.Instance.Play();
                //MessageBox.Show("Play");
            }

            //Debug.WriteLine(PlayState.Playing);
            //Debug.WriteLine(BackgroundAudioPlayer.Instance.PlayerState);
        }

    }
}