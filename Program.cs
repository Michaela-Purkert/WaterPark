using ConsoleTools;
using WaterPark;

Turnstile turnstile = new Turnstile();

void DeleteCertainTicket()
{
    int deleteTicket = 0;

    Console.WriteLine("Choose a number of the ticket you want to remove:");
    deleteTicket = int.Parse(Console.ReadLine());
    
    turnstile.DeleteTicket(deleteTicket);
}



var subMenu = new ConsoleMenu(args, level: 1)
.Add("Delete a ticket", () => DeleteCertainTicket())
.Add("Delete all tickets", () => turnstile.DeleteTickets())
.Add("Close 'Deletion options'", ConsoleMenu.Close)
.Configure(config =>
{
    config.Selector = "--> ";
    //config.EnableFilter = true;
    config.Title = "Deletion options";
    config.EnableBreadcrumb = true;
    config.WriteBreadcrumbAction = titles => Console.WriteLine(string.Join(" / ", titles));
});



var menu = new ConsoleMenu(args, level: 0)
  .Add("Create a new random ticket", () => turnstile.CreateTicket())
  .Add("Create a new specific ticket", () => turnstile.CreateCertainTicket())
  .Add("Show tickets", () => turnstile.WriteOutTickets())
  .Add("Sort the tickets", () => turnstile.OrderTickets())
  .Add("Convert tickets to CSV", () => turnstile.ConvertToCSV())
  .Add("Ticket deletion options", subMenu.Show)
  .Add("Close", ConsoleMenu.Close)
  .Configure(config =>
  {
      config.Selector = "--> ";
      //config.EnableFilter = true;
      config.Title = "Water park";
      config.EnableWriteTitle = true;
      config.EnableBreadcrumb = true;
  });

menu.Show();

