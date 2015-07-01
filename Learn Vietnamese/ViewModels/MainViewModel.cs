using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Learn_Vietnamese.Resources;
using System.IO;
using System.Windows;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace Learn_Vietnamese.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel()
        {
            this.Items = new ObservableCollection<ItemViewModel>();
        }

        /// <summary>
        /// A collection for ItemViewModel objects.
        /// </summary>
        public ObservableCollection<ItemViewModel> Items { get; private set; }

        private string _sampleProperty = "Sample Runtime Property Value";
        /// <summary>
        /// Sample ViewModel property; this property is used in the view to display its value using a Binding
        /// </summary>
        /// <returns></returns>
        public string SampleProperty
        {
            get
            {
                return _sampleProperty;
            }
            set
            {
                if (value != _sampleProperty)
                {
                    _sampleProperty = value;
                    NotifyPropertyChanged("SampleProperty");
                }
            }
        }

        /// <summary>
        /// Sample property that returns a localized string
        /// </summary>
        public string LocalizedSampleProperty
        {
            get
            {
                return AppResources.SampleProperty;
            }
        }

        public bool IsDataLoaded
        {
            get;
            private set;
        }

        /// <summary>
        /// Creates and adds a few ItemViewModel objects into the Items collection.
        /// </summary>
        public void LoadData()
        {
            System.IO.Stream src = Application.GetResourceStream(new Uri("Learn Vietnamese;component/Data/data.json", UriKind.Relative)).Stream;
            string text;
            using (StreamReader sr = new StreamReader(src))
            {
                text = sr.ReadToEnd();
            }
            JObject o = JObject.Parse(text);
            var Items = new List<ItemViewModel>();
            foreach (dynamic Item in o["Items"])
            {
                this.Items.Add(new ItemViewModel(Item["ID"].ToString(), Item["LineOne"].ToString(), Item["LineTwo"].ToString(), Item["LineThree"].ToString(), Item["Link"].ToString(), Item["Track"].ToString(), Item["Fav"].ToString()));
            }
            //this.Items.Add(new ItemViewModel() { ID = "0", LineOne = "At the restaurant", LineTwo = "Maecenas praesent accumsan bibendum", LineThree = "Facilisi faucibus habitant inceptos interdum lobortis nascetur pharetra placerat pulvinar sagittis senectus sociosqu", Link = "http://vovworld.vn/Uploaded/lanphuong/2015_03_24/2303%20day%20tv.mp3", Track = "At the restaurant", Fav="1" });
            //this.Items.Add(new ItemViewModel() { ID = "1", LineOne = "Shopping", LineTwo = "Dictumst eleifend facilisi faucibus", LineThree = "Suscipit torquent ultrices vehicula volutpat maecenas praesent accumsan bibendum dictumst eleifend facilisi faucibus", Link = "http://vovworld.vn/Uploaded/lanphuong/2015_03_09/0903%20tqh.mp3", Track = "Shopping", Fav = "" });
            //this.Items.Add(new ItemViewModel() { ID = "2", LineOne = "Cost", LineTwo = "Habitant inceptos interdum lobortis", LineThree = "Habitant inceptos interdum lobortis nascetur pharetra placerat pulvinar sagittis senectus sociosqu suscipit torquent", Link = "http://vovworld.vn/Uploaded/lanphuong/2015_03_03/0203%20day%20tv.mp3", Track = "Cost", Fav = "" });
            //this.Items.Add(new ItemViewModel() { ID = "3", LineOne = "Post Office", LineTwo = "Nascetur pharetra placerat pulvinar", LineThree = "Ultrices vehicula volutpat maecenas praesent accumsan bibendum dictumst eleifend facilisi faucibus habitant inceptos", Link = "http://vovworld.vn/Uploaded/honganh/2015_02_03/2-2%20SMDT.mp3", Track = "Post Office", Fav = "" });
            //this.Items.Add(new ItemViewModel() { ID = "4", LineOne = "Family", LineTwo = "Nascetur pharetra placerat pulvinar", LineThree = "Ultrices vehicula volutpat maecenas praesent accumsan bibendum dictumst eleifend facilisi faucibus habitant inceptos", Link = "http://vovworld.vn/Uploaded/honganh/2015_01_30/29-1%20day%20TV.mp3", Track = "Family", Fav = "" });
            //this.Items.Add(new ItemViewModel() { ID = "5", LineOne = "Weather", LineTwo = "Nascetur pharetra placerat pulvinar", LineThree = "Ultrices vehicula volutpat maecenas praesent accumsan bibendum dictumst eleifend facilisi faucibus habitant inceptos", Link = "http://vovworld.vn/Uploaded/kimlan/2015_01_27/tieng_viet.mp3", Track = "Weather", Fav = "" });
            //this.Items.Add(new ItemViewModel() { ID = "6", LineOne = "Getting to know others", LineTwo = "Nascetur pharetra placerat pulvinar", LineThree = "Ultrices vehicula volutpat maecenas praesent accumsan bibendum dictumst eleifend facilisi faucibus habitant inceptos", Link = "http://vovworld.vn/Uploaded/honganh/2015_01_09/8-1%20TV.mp3", Track = "Getting to know others", Fav = "" });
            //this.Items.Add(new ItemViewModel() { ID = "7", LineOne = "Largest and smallest", LineTwo = "Nascetur pharetra placerat pulvinar", LineThree = "Ultrices vehicula volutpat maecenas praesent accumsan bibendum dictumst eleifend facilisi faucibus habitant inceptos", Link = "http://vovworld.vn/Uploaded/lanphuong/2014_12_11/0412%20day%20tv.mp3", Track = "Largest and smallest", Fav = "" });
            //this.Items.Add(new ItemViewModel() { ID = "8", LineOne = "Ask about time", LineTwo = "Nascetur pharetra placerat pulvinar", LineThree = "Ultrices vehicula volutpat maecenas praesent accumsan bibendum dictumst eleifend facilisi faucibus habitant inceptos", Link = "http://vovworld.vn/Uploaded/kimlan/2014_11_25/THOI_GIAN.mp3", Track = "Ask about time", Fav = "" });
            //this.Items.Add(new ItemViewModel() { ID = "9", LineOne = "Time", LineTwo = "Nascetur pharetra placerat pulvinar", LineThree = "Ultrices vehicula volutpat maecenas praesent accumsan bibendum dictumst eleifend facilisi faucibus habitant inceptos", Link = "http://vovworld.vn/Uploaded/kimlan/2014_11_25/THOI_GIAN.mp3", Track = "Time", Fav = "" });
            //this.Items.Add(new ItemViewModel() { ID = "10", LineOne = "The art", LineTwo = "Nascetur pharetra placerat pulvinar", LineThree = "Ultrices vehicula volutpat maecenas praesent accumsan bibendum dictumst eleifend facilisi faucibus habitant inceptos", Link = "http://vovworld.vn/Uploaded/honganh/2014_09_19/18-9%20TV.mp3", Track = "The art", Fav = "" });
            //this.Items.Add(new ItemViewModel() { ID = "11", LineOne = "The comparison", LineTwo = "Nascetur pharetra placerat pulvinar", LineThree = "Ultrices vehicula volutpat maecenas praesent accumsan bibendum dictumst eleifend facilisi faucibus habitant inceptos", Link = "http://vovworld.vn/Uploaded/kimlan/2014_08_05/TIENG_VIET.mp3", Track = "The comparison", Fav = "" });

            this.IsDataLoaded = true;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}