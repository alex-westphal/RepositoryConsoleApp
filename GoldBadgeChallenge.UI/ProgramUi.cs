using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GoldBadgeChallenge.Repository;
using GoldBadgeChallenge.Data.Entities.Enums;
using GoldBadgeChallenge.Data.Entities;
using Microsoft.VisualBasic;
using System.Data.Common;

namespace GoldBadgeChallenge.UI
{
    public class ProgramUi
    {
        private readonly DeliveryRepository _repo = new DeliveryRepository();


        public void Run()
        {
            RunApplication();

        }
        private void RunApplication()
        {
            bool isRunning = true;

            while (isRunning)
            {
                Console.Clear();

                System.Console.WriteLine("Enter the number option you would like to select:\n" +
                                         "1. Create new Delivery\n" +
                                         "2. List all en route Deliveries\n" +
                                         "3. Update status of a Delivery\n" +
                                         "4. Cancel a Delivery\n" +
                                         "5. Exit app \n");
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        CreateNewDelivery();
                        break;
                    case "2":
                        ShowAllRoutesEr();
                        break;
                    case "3":
                        UpdateRouteStatus();
                        break;
                    case "4":
                        RemoveDeliveryFromList();
                        break;
                    case "5":
                        isRunning = CloseApplication();
                        break;
                    default:
                        System.Console.WriteLine("Invalid selection, try again");
                        break;
                }
            }
        }
        private void CreateNewDelivery()
        {
             Console.Clear();
             //I need to create a delivery object,
             // The idea is to treat this object like it is an empty form
             Delivery delivery = new Delivery();

            Console.WriteLine("Please put in an order date YYMMDD");
            delivery.OrderDate = DateTime.Parse(Console.ReadLine()!);

            Console.WriteLine("Please enter a delivery date YYMMDD");
            delivery.DeliveryDate = DateTime.Parse(Console.ReadLine()!);
        
            Console.WriteLine("Enter an Item Number");
            delivery.ItemNumber = int.Parse(Console.ReadLine()!);

            Console.WriteLine("Enter an Item Quantity");
            delivery.ItemQuantity = int.Parse(Console.ReadLine()!);

            Console.WriteLine("Please enter a customer Id number");
            delivery.CustomerId = int.Parse(Console.ReadLine()!);

            Console.WriteLine("Please enter an order status\n"+
                              "1. Scheduled\n"+
                              "2. Enroute\n"+
                              "3. Complete\n"+
                              "4. Cancelled\n");
            delivery.OrderStatus = (OrderStatus)int.Parse(Console.ReadLine()!);

            if (_repo.AddDelivery(delivery))
            {
                System.Console.WriteLine("Success!");
            }
            else
            {
                System.Console.WriteLine("Failure!");
            }
            Console.ReadKey();
        }


        private void ShowAllRoutesEr()
        {
            Console.Clear();
        Console.WriteLine("Please enter an order status\n"+
                              "1. Scheduled\n"+
                              "2. Enroute\n"+
                              "3. Complete\n"+
                              "4. Cancelled\n");
            OrderStatus userInput = (OrderStatus)int.Parse(Console.ReadLine()!);
            List<Delivery> orderStatusListing = _repo.GetDeliveriesByOrderStatus(userInput);       
            foreach (Delivery item in orderStatusListing)
            {
                System.Console.WriteLine($"{item.Id} - {item.OrderDate} -{item.DeliveryDate} - {item.CustomerId} - {item.ItemNumber} - {item.ItemQuantity} - {item.DeliveryDate}");
            }

            Console.ReadKey();
        }

        private void RemoveDeliveryFromList()
        {
             Console.Clear();
            //Access the database and find all of the deliveries
            foreach (Delivery item in _repo.GetDeliveries())
            {
                System.Console.WriteLine($"{item.Id} - {item.OrderDate}");
            }
            Console.WriteLine("Choose which delivery route to cancel");

            string userInput = Console.ReadLine()!;
            int userInputId = int.Parse(userInput);
            Delivery deliveryFromDb = _repo.GetDeliveryById(userInputId);
            if (_repo.RemoveDeliveryFromList(deliveryFromDb))
            {
                Console.WriteLine("Success!");
            }
            else
            {
                Console.WriteLine("Failure");
            }
            Console.ReadKey();
        }

        private bool CloseApplication()
        {
            
            return false;
        }

        private void UpdateRouteStatus()
        {
            Console.Clear();
            Console.WriteLine("Enter a route number you would like to update");

            string userInput = Console.ReadLine()!;

            Delivery delivery = _repo.GetDeliveryById(int.Parse(userInput));
            if (delivery != null)
            {
                System.Console.WriteLine("Please enter an order status\n" +
                                        "1. Scheduled\n" +
                                        "2. Enroute\n" +
                                        "3. Complete\n" +
                                        "4. Cancelled\n");

                userInput = Console.ReadLine()!;
                int inputValue = int.Parse(userInput);
                OrderStatus status = (OrderStatus)inputValue;

                if (_repo.UpdateRouteStatus(delivery.Id, status))
                {
                    Console.WriteLine("Success!");
                }
                else
                {
                    Console.WriteLine("Failure");
                }
            }
        }
       
    }
}

