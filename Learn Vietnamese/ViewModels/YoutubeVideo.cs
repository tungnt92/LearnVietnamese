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
    public class YoutubeVideo
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string VideoLink { get; set; }

        public YoutubeVideo()
        {
            this.vlinks = new ObservableCollection<YoutubeVideo>();
        }
        public ObservableCollection<YoutubeVideo> vlinks { get; private set; }
        public bool IsDataLoaded
        {
            get;
            private set;
        }
        public void LoadData()
        {

            this.vlinks.Add(new YoutubeVideo() { Id = "0", Title = "Lesson 1: Hello", VideoLink = "L4nqjTnGLOA" });
            this.vlinks.Add(new YoutubeVideo() { Id = "1", Title = "Lesson 2: Order a coffee", VideoLink = "s8I55mDG0YM" });
            this.vlinks.Add(new YoutubeVideo() { Id = "2", Title = "Lesson 3: Airport arriving", VideoLink = "Ils_M4fV7vY" });
            this.vlinks.Add(new YoutubeVideo() { Id = "3", Title = " Lesson 4: Taxi ", VideoLink = "NfkWpCga7wQ" });
            this.vlinks.Add(new YoutubeVideo() { Id = "4", Title = " Lesson 5: Check in hotel ", VideoLink = "TLaaIR3ck0o" });
            this.vlinks.Add(new YoutubeVideo() { Id = "5", Title = "Lesson 6: Numbers", VideoLink = "2K1ZcugA3_0" });
            this.vlinks.Add(new YoutubeVideo() { Id = "6", Title = "Lesson 7: Breakfast", VideoLink = "dbyNJ82ZX8k" });
            this.vlinks.Add(new YoutubeVideo() { Id = "7", Title = "Lesson 8: Go shopping", VideoLink = "dS5ZoaCD-XE" });
            this.vlinks.Add(new YoutubeVideo() { Id = "8", Title = "Lesson 9: Introducing with others ", VideoLink = "ik3IAVaddgE" });
            this.vlinks.Add(new YoutubeVideo() { Id = "9", Title = " Lesson 10: Have a meet with colleague ", VideoLink = "Ot934AWtB4w" });
            this.vlinks.Add(new YoutubeVideo() { Id = "10", Title = "Adjectives 1 ", VideoLink = "ThgjuMpZPO4" });
            this.vlinks.Add(new YoutubeVideo() { Id = "11", Title = "Adjectives2", VideoLink = "dBz20UzCSYA" });
            this.vlinks.Add(new YoutubeVideo() { Id = "12", Title = " Airplane ", VideoLink = "IeRDy4XYoPw" });
            this.vlinks.Add(new YoutubeVideo() { Id = "13", Title = "Animals", VideoLink = "8Uk7PMqHOI8" });
            this.vlinks.Add(new YoutubeVideo() { Id = "14", Title = "Bathroom ", VideoLink = "w2JaWHEl7fo" });
            this.vlinks.Add(new YoutubeVideo() { Id = "15", Title = "Beach", VideoLink = "BzsnQo9oBgY" });
            this.vlinks.Add(new YoutubeVideo() { Id = "16", Title = "Learn Vietnamese through film: Cô bé lọ lem (cinderela) ", VideoLink = "OXT2hFmMlv4" });
            this.vlinks.Add(new YoutubeVideo() { Id = "17", Title = "Learn Vietnamese through film: Cô bé quàng khăn đỏ (Little red riding hood) ", VideoLink = "ckACDsLCYV8" });
            this.vlinks.Add(new YoutubeVideo() { Id = "18", Title = "Learn Vietnamese through film: Cô bé bán diêm (The Little Match Girl) ", VideoLink = "xdBydz_CwFY" });
            this.vlinks.Add(new YoutubeVideo() { Id = "19", Title = "Learn Vietnamese through film: Công chúa ngủ trong rừng (Sleeping Beauty) ", VideoLink = "GkvZuwvIPDg" });
            this.vlinks.Add(new YoutubeVideo() { Id = "20", Title = "Learn Vietnamese through film: Xin lỗi ", VideoLink = "Yg2DdXMn7lY" });
            this.vlinks.Add(new YoutubeVideo() { Id = "21", Title = "Learn Vietnamese through film:  Cha và con gái ", VideoLink = "MUn2HdN6MdQ" });
            this.vlinks.Add(new YoutubeVideo() { Id = "22", Title = "Learn Vietnamese through film: Chú bé bán báo  ", VideoLink = "2Xo4V4udtUA" });
            this.vlinks.Add(new YoutubeVideo() { Id = "23", Title = "Learn Vietnamese through film: Bữa cơm đáng nhớ  ", VideoLink = "6ZDfhpIeU48" });
            this.vlinks.Add(new YoutubeVideo() { Id = "24", Title = "Learn Vietnamese through film: Carot, trứng và cafe  ", VideoLink = "HJKrXnh9XY0" });
            this.vlinks.Add(new YoutubeVideo() { Id = "25", Title = "Learn Vietnamese through film: Mười phút mỗi ngày  ", VideoLink = "sPoAFBmbDH4" });
            this.vlinks.Add(new YoutubeVideo() { Id = "26", Title = "Vietnamese Cuisine - A day with Hanoi food  ", VideoLink = "psP3V7Haqes" });
            this.vlinks.Add(new YoutubeVideo() { Id = "27", Title = "Vietnamese Cuisine - Bread - Bánh mỳ ", VideoLink = "GJP6f7GkxGk" });
            this.vlinks.Add(new YoutubeVideo() { Id = "28", Title = "Vietnamese Cuisine - Grill Food - Nướng Hopping  ", VideoLink = "tpr4U6gGObA" });
            this.vlinks.Add(new YoutubeVideo() { Id = "29", Title = "Vietnamese Cuisine - Taste of Autumn in Hanoi ", VideoLink = "yd3hdiIPuPc" });
            this.vlinks.Add(new YoutubeVideo() { Id = "30", Title = "Korean Cuisine in Hanoi  ", VideoLink = "DMwajfdved4" });
            this.vlinks.Add(new YoutubeVideo() { Id = "31", Title = "Spanish Cuisine in Hanoi   ", VideoLink = "PBSm731UH5c" });
            this.vlinks.Add(new YoutubeVideo() { Id = "32", Title = "Vietnamese Cuisine - Quảng Nam's Jackfruit  ", VideoLink = "hak8p3zvk4M" });
            this.vlinks.Add(new YoutubeVideo() { Id = "33", Title = "Vietnamese Cuisine - Sea food of Phu Yen province   ", VideoLink = "WVmTg4_Y4yA" });
            this.vlinks.Add(new YoutubeVideo() { Id = "34", Title = "Vietnamese Cuisine - Royal Cuisine at Huế  ", VideoLink = "H92Z-WjTOTs" });
            this.vlinks.Add(new YoutubeVideo() { Id = "35", Title = "Vietnamese Cuisine - A warmer winter with Hanoi sweet soups  ", VideoLink = "uXWIllFbdwE" });
            this.vlinks.Add(new YoutubeVideo() { Id = "36", Title = "Vietnamese Cuisine - Tastes of our home  ", VideoLink = "FaFX-OFeHzk" });
            this.vlinks.Add(new YoutubeVideo() { Id = "37", Title = "Vietnamese Cuisine -  Fruit garden's taste ", VideoLink = "hXvIlx0WHnY" });
            this.vlinks.Add(new YoutubeVideo() { Id = "38", Title = "Vietnamese Cuisine - Sa Pa' soil  ", VideoLink = "5ijkopREXdk" });
            this.vlinks.Add(new YoutubeVideo() { Id = "39", Title = "Vietnamese Cuisine - Taste Tet' colours  ", VideoLink = "MCL_CYBtzZA" });
            this.vlinks.Add(new YoutubeVideo() { Id = "40", Title = "Vietnamese Cuisine -The folk cake in the Southern of Vietnam  ", VideoLink = "zcYEIqqbdKk" });
            this.vlinks.Add(new YoutubeVideo() { Id = "41", Title = "Vietnamese Culture 20141219   ", VideoLink = "GpfA43yFFIM" });
            this.vlinks.Add(new YoutubeVideo() { Id = "42", Title = "Vietnamese Culture 20141205   ", VideoLink = "tceI9TLtN_8" });
            this.vlinks.Add(new YoutubeVideo() { Id = "43", Title = "Vietnamese Culture 2014/29/11  ", VideoLink = "iZfONpIk1l4" });
            this.vlinks.Add(new YoutubeVideo() { Id = "44", Title = "Vietnamese Culture 2014/21/11   ", VideoLink = "nRdUam8-T6s" });
            this.vlinks.Add(new YoutubeVideo() { Id = "45", Title = "Vietnamese Culture 2014/12/26   ", VideoLink = "ugmIZ-wRkvE" });
            this.vlinks.Add(new YoutubeVideo() { Id = "46", Title = "Vietnamese Culture  2015/03/01   ", VideoLink = "krpNwP3w8ec" });
            this.vlinks.Add(new YoutubeVideo() { Id = "47", Title = "Vietnamese Culture 2015/01/09   ", VideoLink = "O7ebjSqofT4" });
            this.vlinks.Add(new YoutubeVideo() { Id = "48", Title = "Vietnamese Culture 2015/01/16   ", VideoLink = "8HHls5mq_Wc" });
            this.vlinks.Add(new YoutubeVideo() { Id = "49", Title = "Vietnamese Culture 2015/24/01   ", VideoLink = "rLnUYQsKhuc" });
            this.vlinks.Add(new YoutubeVideo() { Id = "50", Title = "Vietnamese Culture 2015/31/01   ", VideoLink = "hhl6wh5JT5s" });
            this.vlinks.Add(new YoutubeVideo() { Id = "51", Title = "Vietnamese Culture 2015/02/06   ", VideoLink = "t771CXL6JrQ" });
            this.vlinks.Add(new YoutubeVideo() { Id = "52", Title = "Vietnamese Culture 2015/02/13   ", VideoLink = "EQy8nhyxtlc" });
            this.vlinks.Add(new YoutubeVideo() { Id = "53", Title = "Vietnamese Culture  2015/02/20   ", VideoLink = "ZSeMJIBlmbw" });
            this.vlinks.Add(new YoutubeVideo() { Id = "54", Title = "Vietnamese Culture 2015/03/06   ", VideoLink = "1QI_OA2sOgg" });
            this.vlinks.Add(new YoutubeVideo() { Id = "55", Title = "Vietnamese Culture 2015/03/13   ", VideoLink = "xH17f3ieEy4" });
            this.vlinks.Add(new YoutubeVideo() { Id = "56", Title = "Vietnamese Culture 2015/03/20   ", VideoLink = "jkQ82D0DJmk" });
            this.vlinks.Add(new YoutubeVideo() { Id = "57", Title = "Vietnamese Culture  2015/03/27   ", VideoLink = "SZQ5TVV6qN8" });
            this.vlinks.Add(new YoutubeVideo() { Id = "58", Title = "Vietnamese Culture  2015/04/03   ", VideoLink = "KCUt-FYgQ7k" });
            this.vlinks.Add(new YoutubeVideo() { Id = "59", Title = "Vietnamese Culture  2015/04/10   ", VideoLink = "ALXHhiykTzg" });

            this.IsDataLoaded = true;

        }
    }
}
