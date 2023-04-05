using WaterPark;

Turnstile turnstile = new Turnstile();

bool wantContinue = true;

do
{
    Console.WriteLine("Choose one of the options");
    Console.WriteLine("1 - Create a new random ticket");
    Console.WriteLine("2 - Create a new specific ticket");
    Console.WriteLine("3 - Show tickets");
    Console.WriteLine("4 - Delete a ticket");
    Console.WriteLine("5 - Convert to CSV");
    Console.WriteLine("6 - Delete all tickets");
    Console.WriteLine("7 - Sort the tickets");
    Console.WriteLine("8 - End program");

    int option = int.Parse(Console.ReadLine());

    int createTicket = 0;
    int deleteTicket = 0;

    switch (option)
    {
        case 1:
            turnstile.CreateTicket();
            Console.Clear();
            break;
        case 2:
            Console.WriteLine("Choose a number of the ticket you want to create:");

            try
            {
                createTicket = int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("You must input an integer.");
            }

            turnstile.CreateTicket(createTicket);
            Console.ReadKey();
            Console.Clear();
            break;

        case 3:
            turnstile.WriteOutTickets();
            Console.ReadKey();
            Console.Clear();
            break;

        case 4:
            Console.WriteLine("Choose a number of the ticket you want to delete");
            deleteTicket = int.Parse(Console.ReadLine());
            turnstile.DeleteTicket(deleteTicket);
            Console.ReadKey();
            Console.Clear();
            break;
        case 5:
            turnstile.ConvertToCSV();
            Console.ReadKey();
            Console.Clear();
            break;
        case 6:
            turnstile.DeleteTickets();
            Console.WriteLine("All tickets have been removed.");
            Console.ReadKey();
            Console.Clear();
            break;
        case 7:
            turnstile.OrderTickets();
            turnstile.WriteOutTickets();
            Console.ReadKey();
            Console.Clear();
            break;
        case 8:
            wantContinue = false;
            Console.ReadKey();
            Console.Clear();
            break;
        default:
            Console.WriteLine("Wrong option");
            break;
    }
} while (wantContinue == true);