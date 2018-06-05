using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdamsBakeryWithClass
{
    public struct BakeryItem
    {
        public string type;
        public double salePrice;
        public int quantity;
        public double cost;
        public double totalCost;
        public double totalPrice;
        public int itemNumber;
    }

    static class InventoryUtility   
    {
        
        static void ListInventoryItem(BakeryItem bakeryItem)
        {
            //Console.WriteLine("\nAdam's Bakery Inventory");
            //Console.WriteLine("-----------------------");
           // Console.WriteLine("Index     Item                Quantity     Cost     Sales Price     Total Cost     Total Sales Price");
           // Console.WriteLine("----------------------------------------------------------------------------------------------------");
            Console.WriteLine("{0,-10}{1, -20}{2, 8}{3, 9:c}{4, 16:c}{5, 15:c}{6, 22:c}", bakeryItem.itemNumber, bakeryItem.type, bakeryItem.quantity, bakeryItem.cost, bakeryItem.salePrice, bakeryItem.totalCost, bakeryItem.totalPrice);
        }
        static void ListInventroy(BakeryItem[] bakery)
        {
            Console.WriteLine("\nAdam's Bakery Inventory");
            Console.WriteLine("-----------------------");
            Console.WriteLine("Index     Item                Quantity     Cost     Sales Price     Total Cost     Total Sales Price");
            Console.WriteLine("----------------------------------------------------------------------------------------------------");
            foreach(var item in bakery)
            {
                ListInventoryItem(item);
            }
        }
    }

    public class Inventory
    {
        public int index;

        public Inventory()
        {
            index = 0;
        }

        public void isEmpty()
        {
            Console.WriteLine("Inventory Empty.");
        }

        public BakeryItem[] items = new BakeryItem[100];
    }

}
