using System;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Newtonsoft.Json;
using System.IO;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace Json
{
    public partial class MainPage : ContentPage
    {
        private string url;
        static string requestUrl;
        private Entry isbn;
        /*
        public MainPage()
        {
            InitializeComponent();

            var p = new person();
            p.Name = "Kamada Yuto";
            p.country = "Japan";
            p.Age = 20;

            var json = JsonConvert.SerializeObject(p);  //---------------------------Json形式に変更
            var layout = new StackLayout { HorizontalOptions = LayoutOptions.CenterAndExpand,VerticalOptions = LayoutOptions.CenterAndExpand };

            var label = new Label
            {
                Text = $"{json}" //{"Name":"Kamada Yuto","Age":20}
            };
            layout.Children.Add(label);

            var deserialized = JsonConvert.DeserializeObject<person>(json); //---------------------------Json形式から元に戻す
            var label2 = new Label
            {
                Text = $"Name: {deserialized.Name}" //Kamada Yuto
            };
            var label3 = new Label
            {
                Text = $"Age: {deserialized.Age}" //20
            };
            layout.Children.Add(label2);
            layout.Children.Add(label3);

            Content = layout;
        }
        */

        public MainPage()
        {
            InitializeComponent();


            url = "https://app.rakuten.co.jp/services/api/BooksBook/Search/20170404?format=json&applicationId=1051637750796067320";

            var layout = new StackLayout { HorizontalOptions = LayoutOptions.CenterAndExpand, VerticalOptions = LayoutOptions.CenterAndExpand };

            isbn = new Entry    //EntryでISBNコードを入力
            {
                Placeholder = "ISBNコードを入力",
                PlaceholderColor = Color.Gray,
                WidthRequest = 170
            };
            layout.Children.Add(isbn);

            //string requestUrl = url + "&isbn=" + 9784046022257;    //URLにISBNコードを挿入
            //https://app.rakuten.co.jp/services/api/BooksBook/Search/20170404?format=json&applicationId=1051637750796067320&isbn=9784838729036



            var Serch = new Button
            {
                WidthRequest = 60,
                Text = "Serch!",
                TextColor = Color.Red,
            };
            layout.Children.Add(Serch);
            Serch.Clicked += Serch_Click;

            Content = layout;
        }

        private async void Serch_Click(object sender, EventArgs e)
        {
            var layout2 = new StackLayout { HorizontalOptions = LayoutOptions.CenterAndExpand, VerticalOptions = LayoutOptions.CenterAndExpand };
            var scroll = new ScrollView { Orientation = ScrollOrientation.Vertical };
            layout2.Children.Add(scroll);
            var layout = new StackLayout { HorizontalOptions = LayoutOptions.CenterAndExpand, VerticalOptions = LayoutOptions.CenterAndExpand };
            scroll.Content = layout;

            string isbncode = isbn.Text; //Entryの値を格納
            requestUrl = url + "&isbn=" + isbncode;    //URLにISBNコードを挿入

            //-------------------------------------ボタン再配置--------------------------
            isbn = new Entry    //EntryでISBNコードを入力
            {
                Placeholder = "ISBNコードを入力",
                PlaceholderColor = Color.Gray,
                WidthRequest = 170
            };
            layout.Children.Add(isbn);

            var Serch = new Button
            {
                WidthRequest = 60,
                Text = "Serch!",
                TextColor = Color.Red,
            };
            layout.Children.Add(Serch);
            Serch.Clicked += Serch_Click;
            //-------------------------------------ボタン再配置--------------------------
            

            /*
            //HTTPアクセス //書き方が古いらしい
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(requestUrl);
            req.Method = "GET";
            HttpWebResponse res = req.GetResponseAsync();
            */

            //HTTPアクセスメソッドを呼び出す
            string APIdata = await GetApiAsync();

            //レスポンス(JSON)をオブジェクトに変換 
            Stream s = GetMemoryStream(APIdata);
            StreamReader sr = new StreamReader(s);
            string json = sr.ReadToEnd();

            

            //デシリアライズ
            var deserialize = JsonConvert.DeserializeObject<RakutenBooks>(json);

            var books = deserialize.Items;

            var List1 = new List<String>();

            //layout.Children.Add(new Label { Text = $"タイトル: { books }" });

            foreach (var book in books)
            {
                List1.Add(book.title);
                /*
                layout.Children.Add(new Label { Text = $"タイトル: { book.title }" });

                //layout.Children.Add(new Label { Text = $"タイトルカナ: { book.titleKana }" });

                layout.Children.Add(new Label { Text = $"著者名: { book.author }" });

                layout.Children.Add(new Label { Text = $"出版社: { book.publisherName }" });
            */};
            layout.Children.Add(new Label { Text = $"タイトル：" + List1[0]});
            layout.Children.Add(new Label { Text = "読み取り終了",TextColor = Color.Black });

            layout.Children.Add(new Label { Text = "JSON形式で書き出す", TextColor = Color.Red });
            layout.Children.Add(new Label { Text = json }); //JSON形式で書き出す

            Content = layout2;
        }

        //HTTPアクセスメソッド
        public static async Task<string> GetApiAsync()
        {
            string APIurl = requestUrl;

            using (HttpClient client = new HttpClient())
                try
                {
                    string urlContents = await client.GetStringAsync(APIurl);
                    await Task.Delay(1000);
                    return urlContents;
                }
                catch (Exception e)
                {
                    string a = e.ToString();
                    return a;
                }
        }
        //stringをstreamに
        public MemoryStream GetMemoryStream(string text)
        {
            string a = text;
            return new MemoryStream(Encoding.UTF8.GetBytes(a));
        }
    }
}
