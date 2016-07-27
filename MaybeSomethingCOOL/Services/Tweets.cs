using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Newtonsoft.Json;

namespace MaybeSomethingCOOL.Services
{
    public class RootObject :INotifyPropertyChanged 
    {
        //Forms the list which contans search data
        public RootObject()
        {

        }
        private string _text;
        public string text
        {
            get { return _text; }
            set { _text = value; NotifyPropertyChanged("text"); }
        }

        public User user { get; set; }
        

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    public class User : INotifyPropertyChanged
    {
        private string _screen_name;
        public string screen_name
        {
            get { return _screen_name; }
            set { _screen_name = value; NotifyPropertyChanged("screen_name"); }
        }


        private string _profile_image_url;
        public string profile_image_url
        {
            get { return _profile_image_url; }
            set { _profile_image_url = value; NotifyPropertyChanged("profile_image_url"); }
        }

        private string _name;
        public string name
        {
            get { return _name; }
            set { _name = value; NotifyPropertyChanged("name"); }
        }
  

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
    //List which is fed to myViewModel
    public class RootObjectList : INotifyPropertyChanged 
    {
        public RootObjectList()
        {
            list = new ObservableCollection<RootObject>();    
        }
        public ObservableCollection<RootObject> _list;
        public ObservableCollection<RootObject> list
        {
            get { return _list; }
            set { _list = value; NotifyPropertyChanged("list"); }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
         
    }
  
    // The binding for the listBox which displays tweets
    public class myViewModel
    {
        public RootObjectList userList { get; set; }
        
        public myViewModel()
        {
            userList = new RootObjectList();
        }
        
        
    }
}
