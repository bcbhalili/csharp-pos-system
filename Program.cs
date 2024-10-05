namespace POSConsoleApp
{
    internal class Program
    {
        const int MAX_COFFEE_SIZE = 3;
        const int MAX_LINE_LENGTH = 120;
        static string clearScreen = new string('\n', 30);
        static string borderLine = new string('-', MAX_LINE_LENGTH);
        static string lineSpace = "| " + new string(' ', MAX_LINE_LENGTH - 4) + " |";

        static void Main(string[] args)
        {
            PrintWelcomeScreen();   // This is an example of a function call
            int userChoice = GetUserChoice();
            // Two problems in our userChoice input
            // 1. The code accepts any number.
            //        Problem Statement:
            //            Create a condition that when used in an if statement, the condition should only be true if it is 1 or 0.
            // 2. Exception occured when the user typed a character or a string
            //        Problem Statement:
            //            Create an exception hanlder code to address character and string inputs for variable userChoice.

            // Solution for Problem #1
            // Condition Parts
            // Example: "a == b"
            // a and b are called operands
            // a and b can be in a form of a variable/literal
            // == is called an operator
            if (userChoice == 0)        // First condition.
            {
                // Positive outcome - userChoice == 0
                Console.WriteLine("Goodbye, user!");
            }
            else if (userChoice == 1)   // Second condition.
            {
                // Create an array for the coffee variants
                Coffee[] coffeeArray = new Coffee[MAX_COFFEE_SIZE] 
                {
                    new Coffee("Barako", 190.00, "Gives strong taste and flavor with a distinctively pungent aroma."),
                    new Coffee("Hazelnut", 200.00, "Rich, nutty, and slightly sweet."),
                    new Coffee("Arabika", 220.00, "Slightly sweet flavour accompanied by hints of chocolate, caramel and nuts.")
                }; 
                PrintLandingPage(coffeeArray);
                userChoice = GetUserChoice();
                while (userChoice != 5)
                {
                    switch (userChoice)
                    {
                        case 1:
                            // This case is for Adding to Cart.
                            // Simulate Clear Screen.
                            Console.WriteLine(clearScreen);
                            Console.WriteLine(borderLine);
                            Console.WriteLine(GetTextWithBorders("ADD TO CART"));
                            Console.WriteLine(GetTextWithBorders("Press 1 to Add Barako."));
                            Console.WriteLine(GetTextWithBorders("Press 2 to Add Hazelnut."));
                            Console.WriteLine(GetTextWithBorders("Press 3 to Add Arabika."));
                            Console.WriteLine(borderLine);
                            // Prompt Part
                            userChoice = GetUserChoice() - 1;
                            try
                            {
                                Console.Write("How many " + coffeeArray[userChoice].Flavor + " packs? Quantity: ");
                                int quantity = int.Parse(Console.ReadLine());

                                if (quantity > 0)
                                {
                                    coffeeArray[userChoice].Quantity += quantity;
                                    Console.WriteLine("Add to cart successful.");
                                }
                                else
                                {
                                    Console.WriteLine("Add to cart unsuccessful.");
                                }
                            }
                            catch (IndexOutOfRangeException)
                            {
                                Console.WriteLine("Invalid input! Only pick from 1 to 3.");
                            }

                            Console.Write("Add to Cart done. Please press ENTER.");
                            Console.ReadLine();
                            break;
                        case 2:
                            // Simulate Clear Screen.
                            Console.WriteLine(clearScreen);
                            Console.WriteLine(borderLine);
                            Console.WriteLine(GetTextWithBorders("EDIT CART"));
                            Console.WriteLine(GetTextWithBorders("Press 1 for Barako."));
                            Console.WriteLine(GetTextWithBorders("Press 2 for Hazelnut."));
                            Console.WriteLine(GetTextWithBorders("Press 3 for Arabika."));
                            Console.WriteLine(borderLine);

                            // Prompt Part
                            userChoice = GetUserChoice() - 1;
                            try
                            {
                                Console.WriteLine("Increase or Decrease " + coffeeArray[userChoice].Flavor + " Quantity?");
                                Console.WriteLine("Press 1 to increase quantity.");
                                Console.WriteLine("Press 2 to decrease quantity.");
                                Console.Write("Choice: ");
                                int quantityChoice = int.Parse(Console.ReadLine());
                                int quantity;
                                switch (quantityChoice)
                                {
                                    case 1:
                                        Console.Write("How many " + coffeeArray[userChoice].Flavor + " packs to increase? Quantity: ");
                                        quantity = int.Parse(Console.ReadLine());

                                        if (quantity > 0)
                                        {
                                            coffeeArray[userChoice].Quantity += quantity;
                                            Console.WriteLine("Increase quantity to cart successful.");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Increase quantity to cart unsuccessful.");
                                        }
                                        break;
                                    case 2:
                                        Console.Write("How many " + coffeeArray[userChoice].Flavor + " packs to decrease? Quantity: ");
                                        quantity = int.Parse(Console.ReadLine());

                                        if (quantity <= coffeeArray[userChoice].Quantity)
                                        {
                                            coffeeArray[userChoice].Quantity -= quantity;
                                            Console.WriteLine("Decrease quantity to cart successful.");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Decrease quantity to cart unsuccessful.");
                                        }
                                        break;
                                    default: 
                                        Console.WriteLine("Must only type 1 or 2.");
                                        break;
                                }
                            }
                            catch (IndexOutOfRangeException)
                            {
                                Console.WriteLine("Invalid input! Only pick from 1 to 3.");
                            }

                            Console.Write("Edit Cart done. Please press ENTER.");
                            Console.ReadLine();
                            break;
                        case 3:
                            // This case is for Delete from Cart.
                            // Simulate Clear Screen.
                            Console.WriteLine(clearScreen);
                            Console.WriteLine(borderLine);
                            Console.WriteLine(GetTextWithBorders("DELETE FROM CART"));
                            Console.WriteLine(GetTextWithBorders("Press 1 to Add Barako."));
                            Console.WriteLine(GetTextWithBorders("Press 2 to Add Hazelnut."));
                            Console.WriteLine(GetTextWithBorders("Press 3 to Add Arabika."));
                            Console.WriteLine(borderLine);

                            // Prompt Part
                            userChoice = GetUserChoice() - 1;

                            try
                            {
                                if (coffeeArray[userChoice].Quantity == 0)
                                {
                                    Console.WriteLine("Did not order " + coffeeArray[userChoice].Flavor + ".");
                                }
                                else
                                {
                                    coffeeArray[userChoice].Quantity = 0;
                                }
                            }
                            catch (IndexOutOfRangeException)
                            {
                                Console.WriteLine("Invalid input! Only pick from 1 to 3.");
                            }

                            Console.Write("Delete from Cart done. Please press ENTER.");
                            Console.ReadLine();
                            break;
                        case 4:
                            // This case is Finalizing Cart.
                            // Simulate Clear Screen.
                            double currentTotal = 0;

                            foreach (Coffee coffee in coffeeArray)
                            {
                                currentTotal += coffee.CalculateBreakdownAmount();  // Compute for the item total before tax
                            }

                            Console.WriteLine(clearScreen);
                            Console.WriteLine(borderLine);
                            Console.WriteLine(GetTextWithBorders("Checkout"));
                            Console.WriteLine(GetTextWithBorders("Total in php (before tax): " + currentTotal));
                            Console.WriteLine(GetTextWithBorders("Tax amount in php (12%): " + currentTotal * 0.12));
                            Console.WriteLine(GetTextWithBorders("Grand Total: " + currentTotal * 1.12));  // After tax amount = currentTotal + currentTotal*0.12
                                                                                                           //                  = currentTotal (1 + 0.12)
                                                                                                           // After tax amount = currentTotal * 1.12
                            Console.WriteLine(borderLine);
                            Console.Write("Press ENTER to Finalize Order.");
                            Console.ReadLine();
                            Console.Write("Thank you for your transaction.");
                            Console.Read();

                            foreach (Coffee coffee in coffeeArray)
                            {
                                coffee.Quantity = 0;
                            }
                            break;
                        default:
                            Console.WriteLine("Invalid input! Please try again!");
                            break;
                    }

                    PrintLandingPage(coffeeArray);
                    userChoice = GetUserChoice();
                }
            }
            else if (userChoice == -1)
            {
                // Positive outcome - userChoice == -1
                Console.WriteLine("Choice must be 1 and 0 only.");
            }
            else
            {
                // Negative outcome
                Console.WriteLine("Choice must be 1 and 0 only.");
            }

            Console.Write("POS System Shutting Down. Press ENTER to terminate.");
            Console.Read();
        }
        
        private static void PrintWelcomeScreen()
        {
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("| Welcome to POS System!                   |");
            Console.WriteLine("|                                          |");
            Console.WriteLine("| Press 1 to Proceed with the Main Screen. |");
            Console.WriteLine("| Press 0 to Exit.                         |");
            Console.WriteLine("--------------------------------------------");
        }
        private static void PrintLandingPage(Coffee[] coffeeArray)
        {
            double currentTotal = 0;
            string headerFormat = $"| {"Flavor",-15} | {"Price (php)",-15} | {"Description",-80} |";
            string checkoutLine = $"| {"Flavor",-15} | {"Price (php)",-15} | {"Quantity",-80} |";
            string currentTotalLine;

            // Simulate Clear Screen
            Console.WriteLine(clearScreen);
            // Top Border 
            Console.WriteLine(borderLine);
            // First Box: Welcome and Menu
            Console.WriteLine(GetTextWithBorders("Welcome, user!"));
            Console.WriteLine(lineSpace);
            Console.WriteLine(GetTextWithBorders("Coffee Drip Bags for sale:"));
            Console.WriteLine(borderLine);
            // Second Box: Catalog
            Console.WriteLine(headerFormat);
            foreach (Coffee coffee in coffeeArray)
            {
                Console.WriteLine(GetCoffeeProperties(coffee));
            }
            Console.WriteLine(borderLine);
            // Third Box: Cart Details
            Console.WriteLine(borderLine);
            foreach (Coffee coffee in coffeeArray)
            {
                currentTotal += coffee.CalculateBreakdownAmount();  // Compute for the running total
            }
            // To update the current total, the currentTotalLine variable must now be interpolated.
            currentTotalLine = GetTextWithBorders("Current total (php) --- " + Math.Round(currentTotal, 2));
            Console.WriteLine(currentTotalLine);
            Console.WriteLine(checkoutLine);
            foreach (Coffee coffee in coffeeArray)
            {
                Console.WriteLine(GetBreakdownAmountAndQuantity(coffee));
            }
            Console.WriteLine(borderLine);
            // Fourth Box: Prompts
            Console.WriteLine(GetTextWithBorders("Choices:"));
            Console.WriteLine(GetTextWithBorders("1 --- Add to Cart"));
            Console.WriteLine(GetTextWithBorders("2 --- Edit Cart"));
            Console.WriteLine(GetTextWithBorders("3 --- Delete Item from Cart"));
            Console.WriteLine(GetTextWithBorders("4 --- Finalize"));
            Console.WriteLine(GetTextWithBorders("5 --- Cancel Transaction"));
            Console.WriteLine(borderLine);
        }
        private static int GetUserChoice()
        {
            Console.Write("Please enter your choice: ");
            // Solution for Problem #2
            try
            {
                int choice = int.Parse(Console.ReadLine());

                return choice;
            }
            catch (FormatException)
            {
                return -1;
            }
        }
        private static string GetCoffeeProperties(Coffee coffee)
        {
            return $"| {coffee.Flavor,-15} | {coffee.Price,-15} | {coffee.Description,-80} |"; 
        }
        private static string GetBreakdownAmountAndQuantity(Coffee coffee)
        {
            return $"| {coffee.Flavor,-15} | {coffee.CalculateBreakdownAmount(), -15} | {coffee.Quantity, -80} |";
        }
        private static string GetTextWithBorders(string text)
        {
            return $"| {text,-MAX_LINE_LENGTH + 4} |";
        }
    }
}