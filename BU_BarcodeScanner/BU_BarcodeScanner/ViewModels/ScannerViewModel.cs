﻿using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Input;
using BU_BarcodeScanner.Models;
using BU_BarcodeScanner.Services;
using Xamarin.Essentials;
using Xamarin.Forms;
using ZXing.Net.Mobile.Forms;

namespace BU_BarcodeScanner.ViewModels
{
    public class ScannerViewModel : BaseViewModel
    {
        private readonly IDataStore<Item> dataStore;
        private readonly Inventory inventory;
        public ScannerViewModel()
        {
            Title = "Item Scanner";
            OpenScannerCommand = new Command(OpenScannerFunction);
            LogoutCommand = new Command(Logout);
            dataStore = DependencyService.Get<IDataStore<Item>>();
            inventory = DependencyService.Get<Inventory>();

        }



        public ICommand OpenScannerCommand { get; }
        public ICommand LogoutCommand { get; }
        public async void OpenScannerFunction()
        {
            #if __ANDROID__
	            // Initialize the scanner first so it can track the current context
	            MobileBarcodeScanner.Initialize (Application);
            #endif

            var scanner = new ZXing.Mobile.MobileBarcodeScanner();
            var result = await scanner.Scan();
            if (result != null)
            {
                InventoryItem scannedItem = inventory.Items.Find(item => item.SKUId == result.Text);;
                if (scannedItem != null)
                {
                    await dataStore.AddItemAsync(new Models.Item
                    {
                        SKUId = scannedItem.SKUId,
                        ProductName = scannedItem.ProductName
                    });

                    await Shell.Current.GoToAsync("//ItemsPage");
                    
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Invalid Item!", "Please scan a valid item.", "Ok");
                }

            }
        }

        public async void Logout()
        {
            Preferences.Set("isLoggedIn", false);
            await Shell.Current.GoToAsync("//LoginPage");
        }



    }
}