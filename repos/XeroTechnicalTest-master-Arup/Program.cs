/*
    Welcome to the Xero technical test!
    ---------------------------------------------------------------------------------
    The test consists of a small invoice application that has a number of issues.

    Your job is to fix them and make sure you can perform the functions in each method below.

    Note your first job is to get the solution compiling! 

    Rules
    ---------------------------------------------------------------------------------
    * The entire solution must be written in C# (any version)
    * You can modify any of the code in this solution, split out classes, add projects etc
    * You can modify Invoice and InvoiceLine, rename and add methods, change property types (hint) 
    * Feel free to use any libraries or frameworks you like as long as they are .net based
    * Feel free to write tests (hint) 
    * Show off your skills! 

    Good luck :) 

    When you have finished the solution please zip it up and email it to techtestmelb@xero.com
*/

/*
Comments by Arup
------------------------------------------------------------
I have made the code de-coupled upto some extent possible. 
Categorised different Invoice activities and implemented Strategy Pattern with method injection to handle the same.
Improved the menu option.
Used lambda expression to handle list data.
I have shifted all the data into one class file for sake of maintainability.
Deep cloning is achieved through extension methods using memory streams as Icloneable do not guarantee deep copy.
Written few test cases using MSTest
------------------------------------------------------------
 */

using System;
using System.Collections.Generic;

namespace XeroTechnicalTest
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Xero Tech Test!");
            DisplayMenu();

            InvoiceActivityStrategy iStrategy = new InvoiceActivityStrategy();
            char option = ' ';  

            do
            {
                option = Console.ReadKey().KeyChar;
                Console.WriteLine();

                if (option == '1')
                    iStrategy.SetInvoiceActivity(new CreateInvoiceWithOneItem());
                else if (option == '2')
                    iStrategy.SetInvoiceActivity(new CreateInvoiceWithMultipleItemsAndQuantities());
                else if (option == '3')
                    iStrategy.SetInvoiceActivity(new RemoveItem());
                else if (option == '4')
                    iStrategy.SetInvoiceActivity(new MergeInvoices());
                else if (option == '5')
                    iStrategy.SetInvoiceActivity(new CloneInvoice());
                else if (option == '6')
                    iStrategy.SetInvoiceActivity(new InvoiceToString());

                iStrategy.InitiateInvoiceActivity();

            } while (option != '7');
        }

        static public void DisplayMenu()
        {
            Console.WriteLine("Please select from the following options:");
            Console.WriteLine("1. Single Item Invoice");
            Console.WriteLine("2. Muliple Item Invoice");
            Console.WriteLine("3. Remove Invoice");
            Console.WriteLine("4. Merge Invoice");
            Console.WriteLine("5. Deep Clone Invoice");
            Console.WriteLine("6. Invoice to String");
            Console.WriteLine("7. Exit");
        }
    }
}
