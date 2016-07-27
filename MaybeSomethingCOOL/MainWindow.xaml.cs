using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
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
using System.Net.Http;
using MaybeSomethingCOOL.Services;
using Newtonsoft.Json;
using System.ComponentModel;
using System.Web.Script.Serialization;

namespace MaybeSomethingCOOL
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static ObservableCollection<RootObject> masterList = new ObservableCollection<RootObject>();
        public myViewModel viewContext = new myViewModel();
        public MainWindow()
        {
            InitializeComponent();
            
            this.DataContext = viewContext;
            
        }

        


        //Sends a POST request to twitter API to upload a status
        private void openImage_Click(object sender, RoutedEventArgs e)
        {


            var post = new TwitterPostStatusService();
            post.tryRequest(tweetBox.Text);



        }

        //Button which returns list of searches for a given username
        private void getTweet_Click(object sender, RoutedEventArgs e)
        {
            

            string url = "https://api.twitter.com/1.1/statuses/user_timeline.json";
            string username = textBoxUsername.Text;

            var request = new TwitterGetStatusService();

            request.tryGetStatusRequest(url, username);
            viewContext.userList.list = masterList;
            textBoxUsername.Text = "";
        }
       

        private void buttonUpdate_Click(object sender, RoutedEventArgs e)
        {


        }

        public void prePopulateView()
        {
            string url = "https://api.twitter.com/1.1/statuses/user_timeline.json";
            string username = textBoxUsername.Text;

            var request = new TwitterGetStatusService();

            request.tryGetStatusRequest(url, username);
            viewContext.userList.list = masterList;
            textBoxUsername.Text = "";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var post = new TwitterPostStatusService();
            post.tryRequest(tweetBox.Text);
        }

        
    }
}


//Authorization: 
//        OAuth oauth_consumer_key="lraInGL0JA4JfvvoFED4CStzG", 
//              oauth_nonce="kYjzVBB8Y0ZFabxSWbWovY3uYSQ2pTgmZeNu2VS4cg", 
//              oauth_signature="tnnArxj06cWHq44gCs1OSKk%2FjLY%3D", 
//              oauth_signature_method="HMAC-SHA1", 
//              oauth_timestamp="1318622958", 
//              oauth_token="370773112-GmHxMAgYyLbNEtIKZeRNFsMKPR9EyMZeS9weJAEb", 
//              oauth_version="1.0"