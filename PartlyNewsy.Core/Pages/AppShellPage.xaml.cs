using System;
using System.Collections.Generic;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace PartlyNewsy.Core
{
    public partial class AppShellPage : Shell
    {
        public AppShellPage()
        {
            InitializeComponent();

            MessagingCenter.Subscribe<AddInterestTabMessage>(this,
                AddInterestTabMessage.AddTabMessage,
                (msg) => AddNewsTab(msg)                
           );
        }

        void AddNewsTab(AddInterestTabMessage msg)
        {
            MainThread.BeginInvokeOnMainThread(() => {
                newsTab.Items.Add(new ShellContent
                {
                    Content = new NewsCollectionPage{ CategoryName = msg.InterestInfo.Category },
                    Title = msg.InterestInfo.Title
                });
            });
        }
    }
}
