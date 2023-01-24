
using System;
using System.Threading;
using System.Text.Json;
using System.Linq;
using System.Xml;


namespace Airport
{
    public class Program
    {
        readonly static string path = @"Json\";
        readonly static string jsonPath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, path);
        public static int id = 0;
        //Deserialize Flight
        readonly static string filenameFlights = $"{jsonPath}flights.json";
        readonly static string jsonTextFlights = File.ReadAllText(filenameFlights);
        readonly static List<Flights> flights = JsonSerializer.Deserialize<List<Flights>>(jsonTextFlights);
        //Deserialize Passenger
        readonly static string filePassengers = $"{jsonPath}passenger.json";
        readonly static string jsonTextPass = File.ReadAllText(filePassengers);
        readonly static List<Passengers> passengers = JsonSerializer.Deserialize<List<Passengers>>(jsonTextPass);
        //Deserialize AirCarrier
        readonly static string filename1 = $"{jsonPath}airCarriers.json";
        readonly static string jsonTextAir = File.ReadAllText(filename1);
        readonly static List<AirCarrier> airCarriers = JsonSerializer.Deserialize<List<AirCarrier>>(jsonTextAir);



        static void Main(string[] args)
        {
            try
            {
                InitialMenu();
            }
            catch (IndexOutOfRangeException ex)
            {
                ExceptionMethod(ex);
            }
            catch (FormatException ex)
            {
                ExceptionMethod(ex);
            }
        }

        public static void ExceptionMethod(Exception e)
        {
            Console.WriteLine(e.Message);
            Console.WriteLine(e.StackTrace);
        }

        public static void InitialMenu()
        {
            bool done = default;
            while (!done)
            {
                Console.Clear();
                WriteLogo();
                MenuItems(1, "Login");
                MenuItems(2, "Check buy a ticket");
                MenuItems(3, "Check booking status");
                MenuItems(4, "Logout");
                var optionInit = int.Parse(Console.ReadLine());
                switch (optionInit)
                {
                    case 1:
                        Login();
                        break;
                    case 2:
                        Buy();
                        break;
                    case 3:
                        CheckBookingStatus();
                        break;
                    case 4:
                        done = true;
                        break;
                    default:
                        Console.WriteLine("Enter valid option!");
                        Thread.Sleep(1000);
                        break;
                }
            }
        }

        public static void MainMenu()
        {
            Console.Clear();
            foreach (var item in airCarriers)
            {
                if (id == item.Id)
                {
                    Console.WriteLine(item.Name);
                }
            }
            MenuItems(1, "Flights");
            MenuItems(2, "Passengers");
            MenuItems(3, "Flight Editing");
            MenuItems(4, "Add Flight");
            MenuItems(5, "Report");
            MenuItems(6, "Exit");
            var option = int.Parse(Console.ReadLine());

            switch (option)
            {
                case 1:
                    ShowAllFlights();
                    break;
                case 2:
                    ShowAllPassengers();
                    break;
                case 3:
                    EditFlight();
                    break;
                case 4:
                    AddFlight();
                    break;
                case 5:
                    Report();
                    break;
                case 6:
                    InitialMenu();
                    break;
                default:
                    Console.WriteLine("Enter valid option!");
                    Thread.Sleep(1000);
                    break;
            }
            Console.ReadKey();
            MainMenu();
        }

        public static void Report()
        {
            var dates = new List<DateTime>();

            foreach (var item in flights)
            {
                DateTime dt = Convert.ToDateTime(item.Date);
                dates.Add(dt);
            }
            dates = dates.Distinct().ToList();
            Console.Write("                    ");
            foreach (var item in dates)
            {
                Console.Write($"{item.Month}/{item.Year} ");
            }
            Console.WriteLine("\n");

            for (int i = 0; i < passengers.Count; i++)
            {
                for (int j = 0; j < passengers[i].reservation.Count; j++)
                {
                    for (int k = 0; k < flights.Count; k++)
                    {
                        if (flights[k].FlightId == passengers[i].reservation[j].FlightId)
                        {
                            string cityCountry = $"{flights[k].City}/{flights[k].Country}";

                            Console.Write($"{cityCountry.PadLeft(17)}");

                            for (int l = 0; l < dates.Count; l++)
                            {
                                if (Convert.ToDateTime(flights[k].Date) == dates[l])
                                {
                                    int purchased = 25 - flights[k].NumberOfSeats;
                                    Console.Write($"{purchased}".PadLeft(7));
                                }
                                else { Console.Write("-".PadLeft(7)); }
                            }
                            Console.WriteLine();
                        }
                    }
                }
                continue;
            }
            Console.WriteLine("REPORT");

            int total = 0;
            for (int i = 0; i < passengers.Count; i++)
            {
                for (int j = 0; j < passengers[i].reservation.Count; j++)
                {
                    total += passengers[i].reservation.Count;
                    break;
                }
            }
            Console.WriteLine($"Total number of tickets purchased:{total}");
            double currentIncome = 0;
            double notSold = 0;
            for (int i = 0; i < passengers.Count; i++)
            {
                for (int j = 0; j < passengers[i].reservation.Count; j++)
                {
                    for (int k = 0; k < flights.Count; k++)
                    {
                        if (flights[k].FlightId == passengers[i].reservation[j].FlightId)
                        {
                            currentIncome += flights[k].Price;
                        }
                        else
                        {
                            notSold += flights[k].Price;
                        }
                    }
                }
            }
            Console.WriteLine($"Current Income: {currentIncome}$");
            Console.WriteLine($"Annual planned:{notSold + currentIncome}");
        }

        public static void CheckBookingStatus()
        {
            Console.Clear();
            Console.WriteLine("CHECK BOOKING STATUS!");
            Console.WriteLine("Enter your booking number:");
            var bookingNum = int.Parse(Console.ReadLine());
            for (int i = 0; i < passengers.Count; i++)
            {
                for (int j = 0; j < passengers[i].reservation.Count; j++)
                    if (passengers[i].reservation[j].ReservationId.Equals(bookingNum))
                    {
                        for (int k = 0; k < flights.Count; k++)
                        {
                            if (flights[k].FlightId == passengers[i].reservation[j].FlightId)
                            {
                                Console.WriteLine($"{passengers[i].FirstName}-{passengers[i].LastName}");
                                Console.WriteLine($"{flights[k].City}-{flights[k].Country}-{flights[k].Date}-{flights[k].Time}-{flights[k].Price}-{flights[k].NumberOfSeats}");
                                Console.WriteLine("\nChoose:\n1.Cancel \n2.Exit");
                                var option = int.Parse(Console.ReadLine());
                                switch (option)
                                {
                                    case 1:
                                        {
                                            Console.WriteLine($"Reservation {passengers[i].reservation[j].ReservationId} successfully canceled");
                                            passengers[i].reservation.RemoveAt(j);
                                            string jsonStringg = JsonSerializer.Serialize(passengers);
                                            var fil = $"{jsonPath}passenger.json";
                                            File.WriteAllText(fil, jsonStringg);
                                            flights[k].NumberOfSeats++;
                                            flights[k].Price = flights[k].Price - flights[k].Price * 0.3;
                                            string jsonString = JsonSerializer.Serialize(flights);
                                            var fileName1 = $"{jsonPath}flights.json";
                                            File.WriteAllText(fileName1, jsonString);
                                            Console.ReadKey();
                                            InitialMenu();
                                        }
                                        break;
                                    case 2:
                                        InitialMenu();
                                        break;
                                    default:
                                        Console.WriteLine("Enter valid option!");
                                        break;
                                }
                            }
                        }
                    }
            }
            Console.ReadKey();
        }

        public static void Buy()
        {
            Console.Clear();
            Console.WriteLine("Write your date");
            var date = Console.ReadLine();
            Console.WriteLine("Write your city:");
            var city = Console.ReadLine();
            int count = 0;

            foreach (var item in flights)
            {
                if (item.Date == date && item.City == city)
                {
                    foreach (var items in airCarriers)
                    {
                        if (item.Id == items.Id)
                        {
                            Console.WriteLine($"{items.Name} - {item.FlightId}-{item.City}-{item.Country}-{item.Date}-{item.Time}-{item.Time}-{item.NumberOfSeats}");
                        }
                    }
                    count++;
                    BuyTicket();
                }
            }
            if (count == 0)
            {
                Console.WriteLine("No such flight available!");
                Console.ReadKey();
                InitialMenu();
            }
            Console.ReadKey();
        }

        public static void BuyTicket()
        {
            Console.WriteLine("Enter the flight Id:");
            var flyId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the number of tickets:");
            var numOfTicket = int.Parse(Console.ReadLine());
            foreach (var item in flights)
            {
                if (item.FlightId == flyId)
                {
                    foreach (var items in airCarriers)
                    {
                        if (item.Id == items.Id)
                        {
                            Console.WriteLine($"{items.Id} - {items.Name}- {item.City}-{item.Country}-{item.Price + item.Price * items.MarkUp}");
                            Console.WriteLine("Bye? \n yes or no");
                            var answer = Console.ReadLine();
                            switch (answer)
                            {
                                case "yes":
                                    {
                                        Console.WriteLine("Firstname:");
                                        var name = Console.ReadLine();
                                        Console.WriteLine("LastName:");
                                        var lastName = Console.ReadLine();
                                        Random rnd = new Random();
                                        int reservId = rnd.Next(100, 200);
                                        var res = new Reservation { ReservationId = rnd.Next(100, 200), FlightId = flyId };
                                        passengers.Add(item: new Passengers { PassengerId = rnd.Next(7, 20), FirstName = name, LastName = lastName, reservation = { res } });
                                        string jsonStringg = JsonSerializer.Serialize(passengers);
                                        var fil = $"{jsonPath}passenger.json";
                                        File.WriteAllText(fil, jsonStringg);
                                        Console.WriteLine($"you have successfully purchased. Flight id: {flyId}|| Reservation number:{res.ReservationId}");
                                        for (int k = 0; k < flights.Count; k++)
                                        {
                                            if (flights[k].FlightId == flyId)
                                            {
                                                flights[k].NumberOfSeats -=numOfTicket;
                                                flights[k].Price = flights[k].Price + flights[k].Price * 0.5;
                                                string jsonString = JsonSerializer.Serialize(flights);
                                                var fileName1 = $"{jsonPath}flights.json";
                                                File.WriteAllText(fileName1, jsonString);
                                            }
                                        }
                                    }
                                    break;
                                case "no":
                                    InitialMenu();
                                    break;
                                default:
                                    Console.WriteLine("Option is not valid");
                                    break;
                            }
                        }
                    }
                }
            }
        }

        public static void EditFlight()
        {
            Console.WriteLine("Enter the flight id:");
            var changeFlightId = int.Parse(Console.ReadLine());
            int count = 0;
            foreach (var item in flights)
            {
                if (item.FlightId.Equals(changeFlightId)) { count++; };
            }
            if (count == 1)
            {
                Edit(changeFlightId);
            }
            else
            {
                Console.WriteLine("Flight id does not exist- \n Do you want to enter again? type yes or no");
                var yesOrNo = Console.ReadLine();
                switch (yesOrNo)
                {
                    case "yes": EditFlight(); break;
                    case "no": MainMenu(); break;
                    default: Console.WriteLine("Answer is not valid"); break;
                }
            }
        }

        public static void Edit(int change)
        {
            foreach (var item in flights)
            {
                if (item.FlightId.Equals(change))
                {
                    Console.WriteLine($"{item.FlightId}-{item.City}-{item.Country}-{item.Date}-{item.Time}-{item.Price}-{item.NumberOfSeats}");
                    EditField(change);
                }
            }
        }
        public static void EditField(int change)
        {
            Console.WriteLine("Choose field to edit:\n 1.Price \n 2.Number of seats");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    {
                        Console.WriteLine("Enter you price:");
                        var ch = double.Parse(Console.ReadLine());
                        for (int i = 0; i < flights.Count; i++)
                        {
                            if (flights[i].FlightId.Equals(change))
                            {
                                flights[i].Price = ch;
                                string jsonString = JsonSerializer.Serialize(flights);
                                var fileName1 = $"{jsonPath}flights.json";
                                File.WriteAllText(fileName1, jsonString);
                                Console.WriteLine("You have successfully changes tge price:");
                            }
                        }
                        break;
                    }
                case "2":
                    Console.WriteLine("Enter available number of seats");
                    var quantity = int.Parse(Console.ReadLine());
                    for (int i = 0; i < passengers.Count; i++)
                    {
                        for (int j = 0; j < passengers[i].reservation.Count; j++)
                        {
                            if (passengers[i].reservation[j].FlightId.Equals(change))
                            {
                                for (int k = 0; k < flights.Count; k++)
                                {
                                    if (flights[k].FlightId.Equals(change))
                                    {
                                        flights[k].NumberOfSeats = quantity;
                                        string jsonStri = JsonSerializer.Serialize(flights);
                                        var fileName1 = $"{jsonPath}flights.json";
                                        File.WriteAllText(fileName1, jsonStri);
                                        Console.WriteLine("You have successfully changed the quantity, the price is the same:");
                                    }
                                }
                            }
                        }
                    }
                    for (int k = 0; k < flights.Count; k++)
                    {
                        if (flights[k].FlightId.Equals(change))
                        {
                            if (flights[k].NumberOfSeats > quantity)
                            {
                                flights[k].Price = flights[k].Price - flights[k].Price * 0.3;
                                flights[k].NumberOfSeats = quantity;
                                string jsonStr = JsonSerializer.Serialize(flights);
                                var fileName1 = $"{jsonPath}flights.json";
                                File.WriteAllText(fileName1, jsonStr);
                                Console.WriteLine("You have successfully changed the quantity, the price has been changed");
                            }
                            else if ((flights[k].NumberOfSeats < quantity))
                            {
                                flights[k].Price = flights[k].Price + flights[k].Price * 0.5;
                                flights[k].NumberOfSeats = quantity;
                                string jsonSt = JsonSerializer.Serialize(flights);
                                var fileName1 = $"{jsonPath}flights.json";
                                File.WriteAllText(fileName1, jsonSt);
                                Console.WriteLine("You have successfully changed the quantity, the price has been changed");
                            }
                        }
                    }

                    break;
            }
        }

        public static void AddFlight()
        {
            Random rnd = new Random();
            Console.WriteLine("Type city name:");
            var city = Console.ReadLine();
            Console.WriteLine("Type county name:");
            var country = Console.ReadLine();
            Console.WriteLine("Type date:");
            var date = Console.ReadLine();
            Console.WriteLine("Type time:");
            var time = Console.ReadLine();
            Console.WriteLine("Type price:");
            var price = double.Parse(Console.ReadLine());
            Console.WriteLine("Type number of seats:");
            var quantity = int.Parse(Console.ReadLine());
            flights.Add(new Flights { Id = id, FlightId = rnd.Next(20, 30), City = city, Country = country, Date = date, Time = time, Price = price, NumberOfSeats = quantity });
            string json = JsonSerializer.Serialize(flights);
            var fileName1 = $"{jsonPath}flights.json";
            File.WriteAllText(fileName1, json);
            Console.WriteLine("Flight has been succefully added!");
        }
        public static void ShowAllFlights()
        {
            Console.WriteLine("--------------------------------------------------------");
            foreach (var item in flights)
            {
                if (id == item.Id)
                {
                    Console.WriteLine($"|{item.FlightId} | {item.City} | {item.Country} | {item.Date} | {item.Time} | {item.Price} | {item.NumberOfSeats}|");
                }
            }
            Console.WriteLine("--------------------------------------------------------");
        }

        public static void ShowAllPassengers()
        {
            Console.WriteLine("--------------------------------------------------------");
            int count = 0;
            for (int i = 0; i < passengers.Count; i++)
            {
                for (int j = 0; j < passengers[i].reservation.Count; j++)
                {
                    for (int k = 0; k < flights.Count; k++)
                    {
                        if (id == flights[k].Id && flights[k].FlightId == passengers[i].reservation[j].FlightId)
                        {
                            if (count > 1)
                            {
                                Console.WriteLine($"{passengers[i].reservation[j].ReservationId}-{flights[k].City}-{flights[k].Country}-{flights[k].Date}");
                                Console.WriteLine("****************************");
                            }
                            else
                            {
                                Console.WriteLine($"{passengers[i].PassengerId}-{passengers[i].FirstName}-{passengers[i].LastName}");
                                Console.WriteLine("****************************");
                                Console.WriteLine($"{passengers[i].reservation[j].ReservationId}-{flights[k].City}-{flights[k].Country}-{flights[k].Date}");
                                count++;
                            }
                        }
                    }
                }
            }
            Console.WriteLine("--------------------------------------------------------");
        }

        public static void Login()
        {
            Console.Clear();
            Console.WriteLine("Enter your username:");
            var username = Console.ReadLine();
            Console.WriteLine("Enter your password");
            var password = Console.ReadLine();
            var filename = $"{jsonPath}airCarriersCredentials.json";
            var jsonText = File.ReadAllText(filename);
            var login = JsonSerializer.Deserialize<List<Login>>(jsonText);
            bool correct = default;
            foreach (var auth in login)
            {
                if (username == auth.Username && password == auth.Password)
                {
                    id = auth.Id;
                    correct = true;
                    break;
                }
            }
            if (correct)
            {
                MainMenu();
            }
            else
            {
                Console.WriteLine("Incorrect");
                Console.ReadKey();
            }
        }
        public static void MenuItems(int prefix, string message) => Console.WriteLine($"[{prefix}] {message}");

        public static void WriteLogo()
        {
            string logo = @"  _____  .__                             __   
  /  _  \ |__|____________   ____________/  |_ 
 /  /_\  \|  \_  __ \____ \ /  _ \_  __ \   __\
/    |    \  ||  | \/  |_> >  <_> )  | \/|  |  
\____|__  /__||__|  |   __/ \____/|__|   |__|  
        \/          |__|                       ";

            Console.WriteLine(logo);
        }
    }
}