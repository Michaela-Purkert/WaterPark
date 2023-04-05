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


            Ticket ticket = new Ticket(randomId);
            listOfTickets.Add(ticket);
            return ticket.ID;
        }

        public int CreateTicket(int ticketId)
        {
            if (CheckOfExistingTickets(ticketId) == false)
            {
                Ticket ticket = new Ticket(ticketId);
                listOfTickets.Add(ticket);
                return ticket.ID;
            }

            else
            {
                Console.WriteLine("This ID is already in use.");
                return -1;
            }
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
        }

        public void DeleteTicket (int idTicket)
        {
            foreach (var item in listOfTickets)
            {
                if (item.ID == idTicket)
                {
                    listOfTickets.Remove(item);
                    break;
                }
            }
        }

        public void DeleteTickets()
        {
            listOfTickets.Clear();
        }

        public void ConvertToCSV()
        {
            try
            {
                var json = JsonSerializer.Serialize(listOfTickets);
                Console.WriteLine(json);
                Console.WriteLine("The process succeeded.");
            }
            catch (Exception e)
            {
                Console.WriteLine("Something went wrong. Error: " + e);
            }
        }

        public void OrderTickets()
        {
            var sortedList = listOfTickets.OrderBy(q => q.ID).ToList();
            listOfTickets = sortedList;
        }
    }
}
