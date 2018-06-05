using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdamsBakeryWithClass
{
    class Program
    {
       /* 
        public struct Bakery
        {
            public string type;
            public double salePrice;
            public int quantity;
            public double cost;
            public double totalCost;
            public double totalPrice;
            public int itemNumber;
        }
        */


       
    
    
        static void Main(string[] args)
        {
            bool run = true;
            //int index = 0;
            //var bakery = new Bakery[100];
            var inventory = new Inventory();
            int index = 0;
            Console.WriteLine("Adam's Bakery");
            Console.WriteLine("-------------");

            while (run == true)
            {


                Console.WriteLine("\nN)ew Baked Good\nC)hange Quatity\nR)emove Item Completly\nL)ist\nQ)uit");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "n":
                    case "N":
                        {
                            Console.Write("Enter New Baked Good: ");
                            string bakedGood = Console.ReadLine();
                            int goodLength = bakedGood.Length;
                            if (goodLength > 20)  //checks to make sure that the bake good name will fit in the output display and if not prompts you to enter a new name
                            {
                                Console.WriteLine("Invalid Entry");
                                goto case "n";
                            }
                            bakery[index].type = bakedGood;

                            bool quantInput = true;
                            while (quantInput == true) //creates a loop that keeps asking for quantity until a valid entry is made
                            {
                                Console.Write("Unit Quantity: ");
                                string quantEntered = Console.ReadLine();
                                if (int.TryParse(quantEntered, out int quant)) //check to make sure that quantity entered is a int.
                                {
                                    bakery[index].quantity = quant;
                                    quantInput = false;
                                }
                                else
                                {
                                    Console.WriteLine("Invalid Entry");

                                }
                            }

                            bool costInput = true;
                            while (costInput == true)//loops until a valid cost double is entered
                            {
                                Console.Write("Unit Cost(0.00): ");
                                string costEnt = Console.ReadLine();
                                if (double.TryParse(costEnt, out double inputCost))
                                {
                                    bakery[index].cost = inputCost;
                                    costInput = false;
                                }
                                else
                                {
                                    Console.WriteLine("Invalid Entry.");
                                }
                            }

                            bool priceInput = true;
                            while (priceInput == true) //loops until a valid price is entered
                            {
                                Console.Write("Unit Sale Price(0.00): ");
                                string priceEnt = Console.ReadLine();
                                if (double.TryParse(priceEnt, out double entPrice))
                                {
                                    bakery[index].salePrice = entPrice;
                                    priceInput = false;
                                }
                                else
                                {
                                    Console.WriteLine("Invalid Entry.");
                                }
                            }

                            bakery[index].totalCost = bakery[index].cost * bakery[index].quantity;
                            bakery[index].totalPrice = bakery[index].salePrice * bakery[index].quantity;
                            index++;
                            inventory.index++;
                            index = 
                            break;
                        }
                    case "l":
                    case "L":
                        {
                            if ( Inventory.index == 0)
                            {
                                //Console.WriteLine("Inventory Empty\n");

                                
                            }

                            // Console.WriteLine("\nAdam's Bakery Inventory");
                            //Console.WriteLine("-----------------------");
                            //Console.WriteLine("Index     Item                Quantity     Cost     Sales Price     Total Cost     Total Sales Price");
                            //Console.WriteLine("----------------------------------------------------------------------------------------------------");
                            //for(int i = 0; i < index; i++)
                            //{
                            //  Console.WriteLine("{0,-10}{1, -20}{2, 8}{3, 9:c}{4, 16:c}{5, 15:c}{6, 22:c}", i + 1, bakery[i].type, bakery[i].quantity, bakery[i].cost, bakery[i].salePrice, bakery[i].totalCost, bakery[i].totalPrice);
                            //}
                            
                            break;
                        }
                    case "c":
                    case "C":
                        {
                            if (index == 0)
                            {
                                Console.WriteLine("Inventory Empty\n");
                                break;
                            }

                            Console.WriteLine("\nAdam's Bakery Inventory");
                            Console.WriteLine("-----------------------");
                            Console.WriteLine("Index     Item                Quantity     Cost     Sales Price     Total Cost     Total Sales Price");
                            Console.WriteLine("----------------------------------------------------------------------------------------------------");

                            for (int i = 0; i < index; i++)
                            {
                                Console.WriteLine("{0,-10}{1, -20}{2, 8}{3, 9:c}{4, 16:c}{5, 15:c}{6, 22:c}", i + 1, bakery[i].type, bakery[i].quantity, bakery[i].cost, bakery[i].salePrice, bakery[i].totalCost, bakery[i].totalPrice);
                            }

                            bool changeItem = true;
                            while (changeItem == true)//loops until a valid entry is made
                            {
                                Console.Write("\nEntere Item Number sold: ");
                                string toAdd = Console.ReadLine();
                                if (int.TryParse(toAdd, out int indexToChange))
                                {
                                    if (indexToChange > 0 && indexToChange - 1 < index)//checks to see if it is a valid choice
                                    {
                                        Console.Write("Enter ammount sold: ");
                                        string sold = Console.ReadLine();
                                        int amountSold = int.Parse(sold);
                                        if (amountSold > bakery[indexToChange - 1].quantity || amountSold < 0)
                                        {
                                            Console.WriteLine("Unable\n");
                                            goto case "c";
                                        }
                                        bakery[indexToChange - 1].quantity = bakery[indexToChange - 1].quantity - amountSold;
                                        bakery[indexToChange - 1].totalCost = bakery[indexToChange - 1].cost * bakery[indexToChange - 1].quantity;
                                        bakery[indexToChange - 1].totalPrice = bakery[indexToChange - 1].salePrice * bakery[indexToChange - 1].quantity;

                                        if (bakery[indexToChange - 1].quantity < 1) //checks to see if inventory is empty
                                        {
                                            for (int i = indexToChange - 1; i < index; i++) //colapses the array when inventory empty
                                            {
                                                bakery[i] = bakery[i + 1];

                                            }
                                            index--;
                                        }

                                        Console.WriteLine("\nIndex     Item                Quantity     Cost     Sales Price     Total Cost     Total Sales Price");
                                        Console.WriteLine("------------------------------------------------------------------------------------------------------");

                                        for (int i = 0; i < index; i++)
                                        {
                                            Console.WriteLine("{0,-10}{1, -20}{2, 8}{3, 9:c}{4, 16:c}{5, 15:c}{6, 22:c}", i + 1, bakery[i].type, bakery[i].quantity, bakery[i].cost, bakery[i].salePrice, bakery[i].totalCost, bakery[i].totalPrice);
                                        }
                                    }

                                    else
                                    {
                                        Console.WriteLine("Invalid Entry.");
                                        goto case "c";

                                    }
                                    changeItem = false;
                                }
                                else
                                {
                                    Console.WriteLine("Invalid Entry.");
                                }
                            }
                            break;

                        }
                    case "r":
                    case "R":
                        {
                            if (index == 0)
                            {
                                Console.WriteLine("Inventory Empty.");
                                break;
                            }
                            Console.WriteLine("Adam's Bakery Inventory");
                            Console.WriteLine("-----------------------");
                            Console.WriteLine("Index     Item                Quantity     Cost     Sales Price     Total Cost     Total Sales Price");
                            Console.WriteLine("----------------------------------------------------------------------------------------------------");

                            for (int i = 0; i < index; i++)
                            {
                                Console.WriteLine("{0,-10}{1, -20}{2, 8}{3, 9:c}{4, 16:c}{5, 15:c}{6, 22:c}", i + 1, bakery[i].type, bakery[i].quantity, bakery[i].cost, bakery[i].salePrice, bakery[i].totalCost, bakery[i].totalPrice);
                            }

                            bool itemRemove = true;
                            while (itemRemove == true)
                            {
                                Console.Write("\nPlease Select Item number to completly remove: ");
                                string toRemove = Console.ReadLine();
                                if (int.TryParse(toRemove, out int itemNumber))
                                {

                                    if (itemNumber < 1 || itemNumber > index + 1)
                                    {
                                        Console.WriteLine("Invalid Selection.");
                                        goto case "r";
                                    }
                                    for (var i = itemNumber - 1; i < index; i++)
                                    {
                                        bakery[i] = bakery[i + 1];
                                    }
                                    index--;

                                    Console.WriteLine("Index     Item                Quantity     Cost     Sales Price     Total Cost     Total Sales Price");
                                    Console.WriteLine("----------------------------------------------------------------------------------------------------");

                                    for (int i = 0; i < index; i++)
                                    {
                                        Console.WriteLine("{0,-10}{1, -20}{2, 8}{3, 9:c}{4, 16:c}{5, 15:c}{6, 22:c}", i + 1, bakery[i].type, bakery[i].quantity, bakery[i].cost, bakery[i].salePrice, bakery[i].totalCost, bakery[i].totalPrice);
                                    }
                                    itemRemove = false;
                                }
                                else
                                {
                                    Console.WriteLine("Invalid Entry.");
                                }
                            }
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
