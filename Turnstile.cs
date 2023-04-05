using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WaterPark
{
    internal class Turnstile
    {
        public List<Ticket> listOfTickets;
        public int ticketId;
        public Turnstile()
        {
            ticketId = 1;
            listOfTickets = new List<Ticket>();
        }

        public int CreateTicket()
        {
            bool check  = true;
            Random rndTicket = new Random();
            int randomId = 0;

            do
            {
                randomId = rndTicket.Next(1,10);
                check = CheckOfExistingTickets(randomId);

            } while (check == true);

            Console.WriteLine("Ticket with number {0} has been created.", randomId);
            Ticket ticket = new Ticket(randomId);
            listOfTickets.Add(ticket);
            Console.ReadKey();
            return ticket.ID;
        }

        private int CreateTicket(int ticketId)
        {
            if (CheckOfExistingTickets(ticketId) == false)
            {
                Ticket ticket = new Ticket(ticketId);
                listOfTickets.Add(ticket);
                Console.ReadKey();
                return ticket.ID;
            }

            else
            {
                Console.WriteLine("This ID is already in use.");
                Console.ReadKey();
                return -1;
            }
        }

        public void CreateCertainTicket()
        {
            int createTicket = 0;
            Console.WriteLine("Choose a number of the ticket you want to create:");

            try
            {
                createTicket = int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("You must input an integer.");
                Console.ReadKey();
            }
            CreateTicket(createTicket);

        }

        private bool CheckOfExistingTickets(int ticketId)
        {
            foreach (var item in listOfTickets)
            {
                if (item.ID == ticketId)
                    return true;
            }
            return false;
        }

        public void WriteOutTickets()
        {
            foreach (var item in listOfTickets)
                Console.WriteLine("Ticket number is: " + item.ID);
            Console.ReadKey();
        }

        public void DeleteTicket (int idTicket)
        {
            bool check = false;

            foreach (var item in listOfTickets)
            {
                if (item.ID == idTicket)
                {
                    listOfTickets.Remove(item);
                    check = true;
                    Console.WriteLine("Ticket with number {0} has been removed.", idTicket);
                    Console.ReadKey();
                    break;
                }
            }

            if (check == false)
            {
                Console.WriteLine("You must choose an existing ticket number");
                Console.ReadKey();
            }

        }

        public void DeleteTickets()
        {
            listOfTickets.Clear();
            Console.WriteLine("All tickets have been removed.");
            Console.ReadKey();
        }

        public void ConvertToCSV()
        {
            try
            {
                var json = JsonSerializer.Serialize(listOfTickets);
                Console.WriteLine(json);
                Console.WriteLine("The process succeeded.");
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine("Something went wrong. Error: " + e);
                Console.ReadKey();
            }
        }

        public void OrderTickets()
        {
            var sortedList = listOfTickets.OrderBy(q => q.ID).ToList();
            listOfTickets = sortedList;
            Console.ReadKey();
        }
    }
}
