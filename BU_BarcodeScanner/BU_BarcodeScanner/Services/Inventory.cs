using System;
using System.Collections.Generic;
using System.Text;
using BU_BarcodeScanner.Models;
using BU_BarcodeScanner.Services;

namespace BU_BarcodeScanner.Services
{
    class Inventory
    {
        public List<InventoryItem> Items = new List<InventoryItem>
        {
            new InventoryItem { SKUId = "705632441947", ProductName = "Cycling Gloves" },
            new InventoryItem { SKUId = "8906004863080", ProductName = "Origami Tissues" },
            new InventoryItem { SKUId = "4987176191359", ProductName = "Vicks Inhaler" },
            new InventoryItem { SKUId = "194632852486", ProductName = "Lenovo Backpack" },
            new InventoryItem { SKUId = "KDRMUQFL", ProductName = "Cycling Jersey" },
            new InventoryItem { SKUId = "N7HGPIIE", ProductName = "Bike Lock" },
            new InventoryItem { SKUId = "U3NQ9QA7", ProductName = "Chain Lubricant" },
            new InventoryItem { SKUId = "2JF3DS76", ProductName = "Helmet" },
            new InventoryItem { SKUId = "72ERARGQ", ProductName = "Bike Lock" },
            new InventoryItem { SKUId = "74C2IH3M", ProductName = "Road Bike" }
        };
    }


}
