using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Maps;


namespace homework5
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<MyPin> pickerLocations;

        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;
            pickerLocations = new ObservableCollection<MyPin>();
            

            //iron mountain hiking
            MyPin Pin1 = new MyPin
            {
                Label = "Iron Mountain Trail",
                Address = "Iron Mountain Trail, Poway CA",
                Type = PinType.Place,
                Position = new Position(32.978527, -116.972192)
            };
            //bear mountain snowboarding
            MyPin Pin2 = new MyPin
            {
                Label = "Bear Mountain Ski Resort",
                Address = "43101 Goldmine Dr, Big Bear Lake, CA 92315",
                Type = PinType.Place,
                Position = new Position(34.2277, -116.8608)
            };
            //epcot orlando
            MyPin Pin3 = new MyPin
            {
                Label = "Epcot",
                Address = "200 Epcot Center Dr, Orlando, FL 32821",
                Type = PinType.Place,
                Position = new Position(28.3747, -81.5494)
                
                
            };
            //universal stdios hollywood
            MyPin Pin4 = new MyPin
            {
                Label = "Universal Studios Hollywood",
                Address = "100 Universal City Plaza, Universal City, CA 91608",
                Type = PinType.Place,
                Position = new Position(34.1381, -118.3534)
            };

            //-------- Now...

            //Add Pins to Picker
            pickerLocations.Add(Pin1);
            pickerLocations.Add(Pin2);
            pickerLocations.Add(Pin3);
            pickerLocations.Add(Pin4);

            myPicker.ItemsSource = pickerLocations; //Set Item Source for myPicker

            //Add Pins to myMap
            myMap.Pins.Add(Pin1);
            myMap.Pins.Add(Pin2);
            myMap.Pins.Add(Pin3);
            myMap.Pins.Add(Pin4);

            


        }

        //When index changes , it will go to that location on the map
        void myPicker_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            MyPin pin = pickerLocations[((Picker)sender).SelectedIndex];
            myMap.MoveToRegion(MapSpan.FromCenterAndRadius(pin.Position, Distance.FromKilometers(5)));
        }

        //When Toggle Button is selected, It will change from Satellite to Street View
        void Button_Clicked(System.Object sender, System.EventArgs e)
        {

            if(myMap.MapType == MapType.Satellite)
            {
                myMap.MapType = MapType.Street;
            }
            else
            {
                myMap.MapType = MapType.Satellite;
            }
        }
    }

    //We Need to Override Class's ToString funtionality that way it will show the label in the PICKER...
    public class MyPin : Pin
    {
        public override string ToString()
        { 
            return Label;
        }
    }
}
