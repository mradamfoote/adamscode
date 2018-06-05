﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdamsBakeryWithClass
{
    static class Inventory
    {
        static int index;

        static Inventory()
        {
            index = 0;
        }

         
        static void ListInventory(Program.Bakery bakeryItem)
        {
            //Console.WriteLine("\nAdam's Bakery Inventory");
            //Console.WriteLine("-----------------------");
            Console.WriteLine("Index     Item                Quantity     Cost     Sales Price     Total Cost     Total Sales Price");
            Console.WriteLine("----------------------------------------------------------------------------------------------------");
            Console.WriteLine("{0,-10}{1, -20}{2, 8}{3, 9:c}{4, 16:c}{5, 15:c}{6, 22:c}", bakeryItem.itemNumber, bakeryItem.type, bakeryItem.quantity, bakeryItem.cost, bakeryItem.salePrice, bakeryItem.totalCost, bakeryItem.totalPrice);
        }
    }
}