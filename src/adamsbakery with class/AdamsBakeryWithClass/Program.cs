﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdamsBakeryWithClass
{
    class Program
    {
        
        
        static void Main(string[] args)
        {
            bool run = true;
            var bakery = new Inventory();
            Console.WriteLine("Adam's Bakery");
            Console.WriteLine("-------------");

            void listInventory()
            {
                InventoryUtility.BakeryHeader();
                InventoryUtility.ListInventroy(bakery.items);
            }
            void newItemName()
            {
                bool nameEnter = true;
                while (nameEnter == true)
                {
                    Console.Write("Enter New Baked Good: ");
                    string bakedGood = Console.ReadLine();
                    if (int.TryParse(bakedGood, out int badName))
                    {
                        Console.WriteLine("Invalid Entry.");
                    }
                    else
                    {
                        int goodLength = bakedGood.Length;
                        if (goodLength > 20)  //checks to make sure that the bake good name will fit in the output display and if not prompts you to enter a new name
                        {
                            Console.WriteLine("Invalid Entry");
                        }
                        bakery.items[bakery.index].type = bakedGood;
                        nameEnter = false;
                    }
                }
            }
            void newItemQuant()
            {
                bool quantInput = true;
                while (quantInput == true) //creates a loop that keeps asking for quantity until a valid entry is made
                {
                    Console.Write("Unit Quantity: ");
                    string quantEntered = Console.ReadLine();
                    if (int.TryParse(quantEntered, out int quant)) //check to make sure that quantity entered is a int.
                    {
                        bakery.items[bakery.index].quantity = quant;
                        quantInput = false;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Entry");

                    }
                }
            }
            void newItemCost()
            {
                bool costInput = true;
                while (costInput == true)//loops until a valid cost double is entered
                {
                    Console.Write("Unit Cost(0.00): ");
                    string costEnt = Console.ReadLine();
                    if (double.TryParse(costEnt, out double inputCost))
                    {
                        bakery.items[bakery.index].cost = inputCost;
                        costInput = false;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Entry.");
                    }
                }
            }
            void newItemPrice()
            {
                bool priceInput = true;
                while (priceInput == true) //loops until a valid price is entered
                {
                    Console.Write("Unit Sale Price(0.00): ");
                    string priceEnt = Console.ReadLine();
                    if (double.TryParse(priceEnt, out double entPrice))
                    {
                        bakery.items[bakery.index].salePrice = entPrice;
                        priceInput = false;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Entry.");
                    }
                }
            }
            void newItemTotals()
            {
                bakery.items[bakery.index].totalCost = bakery.items[bakery.index].cost * bakery.items[bakery.index].quantity;
                bakery.items[bakery.index].totalPrice = bakery.items[bakery.index].salePrice * bakery.items[bakery.index].quantity;
                bakery.items[bakery.index].itemNumber = bakery.index + 1;
            }
            void itemRemoved()
            {
                InventoryUtility.BakeryHeader();
                InventoryUtility.ListInventroy(bakery.items);
                bool itemRemove = true;
                while (itemRemove == true)
                {
                    Console.Write("\nPlease Select Item number to completly remove: ");
                    string toRemove = Console.ReadLine();
                    if (int.TryParse(toRemove, out int itemNumber))
                    {

                        if (itemNumber < 1 || itemNumber > bakery.index + 1)
                        {
                            Console.WriteLine("Invalid Selection.");

                        }
                        for (var i = itemNumber - 1; i < bakery.index; i++)
                        {
                            bakery.items[i] = bakery.items[i + 1];
                            bakery.items[i].itemNumber--;
                        }
                        bakery.index--;
                        InventoryUtility.Count--;
                        InventoryUtility.BakeryHeader();
                        InventoryUtility.ListInventroy(bakery.items);
                        itemRemove = false;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Entry.");
                    }
                }
            }
            void itemSold()
            {
                bool changeItem = true;
                while (changeItem == true)//loops until a valid entry is made
                {
                    Console.Write("\nEntere Item Number sold: ");
                    string toAdd = Console.ReadLine();
                    if (int.TryParse(toAdd, out int indexToChange))
                    {
                        if (indexToChange > 0 && indexToChange - 1 < bakery.index)//checks to see if it is a valid choice
                        {
                            Console.Write("Enter ammount sold: ");
                            string sold = Console.ReadLine();
                            bool soldItem = true;
                            while (soldItem == true)
                            {
                                if (int.TryParse(sold, out int amountSold))
                                {
                                    if (amountSold > bakery.items[indexToChange - 1].quantity || amountSold < 0)
                                    {
                                        Console.WriteLine("Unable\n");
                                    }
                                    bakery.items[indexToChange - 1].quantity = bakery.items[indexToChange - 1].quantity - amountSold;
                                    bakery.items[indexToChange - 1].totalCost = bakery.items[indexToChange - 1].cost * bakery.items[indexToChange - 1].quantity;
                                    bakery.items[indexToChange - 1].totalPrice = bakery.items[indexToChange - 1].salePrice * bakery.items[indexToChange - 1].quantity;

                                    if (bakery.items[indexToChange - 1].quantity < 1) //checks to see if inventory is empty
                                    {
                                        for (int i = indexToChange - 1; i < bakery.index; i++) //colapses the array when inventory empty
                                        {
                                            bakery.items[i] = bakery.items[i + 1];

                                        }
                                        bakery.index--;
                                        InventoryUtility.Count--;
                                    }
                                    InventoryUtility.BakeryHeader();
                                    InventoryUtility.ListInventoryItem(bakery.items[indexToChange - 1]);
                                    soldItem = false;
                                }
                                else
                                {
                                    Console.WriteLine("Invalid Entry.");
                                }
                            }
                        }
                    }
                    
                    changeItem = false;
                }
            }
            while (run == true)
            {
                Console.WriteLine("\nN)ew Baked Good\nC)hange Quatity\nR)emove Item Completly\nL)ist\nQ)uit");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "n":
                    case "N":
                        {
                            newItemName();
                            newItemQuant();
                            newItemCost();
                            newItemPrice();
                            newItemTotals();
                            InventoryUtility.Count++;
                            bakery.index++;
                            break;
                        }
                    case "l":
                    case "L":
                        {
                            if (bakery.index == 0)
                            {
                                bakery.IsEmpty();
                                break;
                            }
                            listInventory();
                            break;
                        }
                    case "c":
                    case "C":
                        {
                            if (bakery.index == 0)
                            {
                                bakery.IsEmpty();
                                break;
                            }
                            listInventory();
                            itemSold();
                            break;
                        }
                    case "r":
                    case "R":
                        {
                            if (bakery.index == 0)
                            {
                                Console.WriteLine("Inventory Empty.");
                                break;
                            }
                            itemRemoved();                           
                            break;
                        }
                    case "q":
                    case "Q":
                        run = false;
                        break;
                    default:
                        Console.WriteLine("Invalid Selection.");
                        break;

                }
            }
        }
        
    }
}
