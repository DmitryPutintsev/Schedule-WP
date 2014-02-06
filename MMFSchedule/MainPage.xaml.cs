using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using MMFSchedule.Resources;
using RestSharp;
using Newtonsoft.Json;
using MMFSchedule.Models;
using MMFSchedule.HelperClass;
using MMFSchedule.Engine;

namespace MMFSchedule
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            NetworkEngine ne = new NetworkEngine();
            ne.Callback += new NetworkEngine.CallbackEventHandler(neCallback);
            ne.GetSchedule();
        }

        void neCallback(List<Group<Lesson>> grLessons)
        {
            Dispatcher.BeginInvoke(() =>
            {
                ScheduleWeekList.ItemsSource = grLessons;
            });
        }

        // Sample code for building a localized ApplicationBar
        //private void BuildLocalizedApplicationBar()
        //{
        //    // Set the page's ApplicationBar to a new instance of ApplicationBar.
        //    ApplicationBar = new ApplicationBar();

        //    // Create a new button and set the text value to the localized string from AppResources.
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // Create a new menu item with the localized string from AppResources.
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}
    }
}