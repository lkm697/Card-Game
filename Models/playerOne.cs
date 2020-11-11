using System;
using System.ComponentModel;

namespace Card_Game.Models
{
    static class playerOne
    {
        private static string _firstName = "Joe";
        private static string _lastName = "Smith";
        private static decimal _bankRoll = 1000m;
        private static double _shoeProgress = 0;

        public static double shoeProgress
        {
            get { return _shoeProgress; }
            set 
            {
                _shoeProgress = value;
                NotifyStaticPropertyChanged("shoeProgress");
            }
        }

        public static decimal bankRoll
        {
            get { return _bankRoll; }
            set
            {
                _bankRoll = (decimal)value;
                NotifyStaticPropertyChanged("bankRoll");
            }
        }


        public static string lastName
        {
            get { return _lastName; }
            set
            {
                _lastName = value;
                NotifyStaticPropertyChanged("lastName");
            }
        }


        public static string firstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
                NotifyStaticPropertyChanged("firstName");
            }
        }

        public static event EventHandler<PropertyChangedEventArgs> StaticPropertyChanged;
        private static void NotifyStaticPropertyChanged(string propertyName)
        {
            if (StaticPropertyChanged != null)
                StaticPropertyChanged(null, new PropertyChangedEventArgs(propertyName));
        }
    }
}
