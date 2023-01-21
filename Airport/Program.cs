
using System;
using System.Threading;
using System.Text.Json;
using System.Linq;
using System.Xml;

namespace Airport
{
    public class Program
    {
        const string jsonPath = "C:\\Users\\tolganay.muratova\\Projects\\Project1\\Airport\\Json\\";
        public static int id = 0;
        static void Main(string[] args)
        {
            InitialMenu();
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
                MenuItems(3, "Check flight status");
                MenuItems(4, "Check booking status");
                MenuItems(5, "Logout");
                var optionInit = int.Parse(Console.ReadLine());
                switch (optionInit)
                {
                    case 1:
                        Login();
                        break;
                    case 2:
                        Buy();
                        break;
                    case 23:
                        Console.WriteLine("fFF");
                        break;
                    case 4:
                        CheckBookingStatus();
                        break;
                    case 5:
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
            var filename1 = $"{jsonPath}airCarriers.json";
            var jsonTextAir = File.ReadAllText(filename1);
            var airCarriers = JsonSerializer.Deserialize<List<AirCarrier>>(jsonTextAir);
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
                    Console.WriteLine("fFF");
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




        public static void CheckBookingStatus()
        {
            var filename = $"{jsonPath}flights.json";
            var jsonText = File.ReadAllText(filename);
            var flights = JsonSerializer.Deserialize<List<Flights>>(jsonText);
            var filePassengers = $"{jsonPath}passenger.json";
            var jsonTextPass = File.ReadAllText(filePassengers);
            var passengers = JsonSerializer.Deserialize<List<Passengers>>(jsonTextPass);
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
                                        case 2: InitialMenu();
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
            var filename = $"{jsonPath}flights.json";
            var jsonText = File.ReadAllText(filename);
            var flights = JsonSerializer.Deserialize<List<Flights>>(jsonText);

            var filename1 = $"{jsonPath}airCarriers.json";
            var jsonTextAir = File.ReadAllText(filename1);
            var airCarriers = JsonSerializer.Deserialize<List<AirCarrier>>(jsonTextAir);

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
                    BuyTicket(flights, airCarriers);
                }

            }
            if (count == 0)
            {
                InitialMenu();
            }
            Console.ReadKey();

        }

        public static void BuyTicket(List<Flights> fly, List<AirCarrier> air)
        {
            Console.WriteLine("Enter the flight Id:");
            var flyId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the number of tickets:");
            var numOfTicket = int.Parse(Console.ReadLine());
            foreach (var item in fly)
            {
                if (item.FlightId == flyId)
                {
                    foreach (var items in air)
                    {
                        if (item.Id == items.Id)
                        {
                            Console.WriteLine($"{items.Id} - {items.Name}- {item.City}-{item.Country}-{item.Price + item.Price * items.MarkUp}");
                            Console.WriteLine(items.MarkUp);
                            Console.WriteLine("Bye? \n yes or no");
                            var answer = Console.ReadLine();
                            switch (answer)
                            {
                                case "yes":
                                    {
                                        var filePassengers = $"{jsonPath}passenger.json";
                                        var jsonTextPass = File.ReadAllText(filePassengers);
                                        var passengers = JsonSerializer.Deserialize<List<Passengers>>(jsonTextPass);
                                        Console.WriteLine("Firstname:");
                                        var name = Console.ReadLine();
                                        Console.WriteLine("LastName:");
                                        var lastName = Console.ReadLine();
                                        Random rnd = new Random();
                                        int reservId = rnd.Next(100, 200);
                                        var res = new Reservation { ReservationId = rnd.Next(100, 200), FlightId = flyId };
                                        passengers.Add(item: new Passengers { PassengerId = rnd.Next(7, 20), FirstName = name, LastName = lastName, reservation = { res } });


                                        // passengers.reservation.Add(res);
                                        string jsonStringg = JsonSerializer.Serialize(passengers);
                                        var fil = $"{jsonPath}passenger.json";
                                        File.WriteAllText(fil, jsonStringg);
                                        Console.WriteLine($"you have successfully purchased. Flight id: {flyId}|| Reservation number:{res.ReservationId}");
                                    }
                                    break;
                                case "no":
                                    InitialMenu();
                                    break;
                                default:
                                    Console.WriteLine("Answer is not valid");
                                    break;
                            }
                        }
                    }
                }
            }



        }
        public static void EditFlight()
        {
            var filename = $"{jsonPath}flights.json";
            var jsonText = File.ReadAllText(filename);
            var flights = JsonSerializer.Deserialize<List<Flights>>(jsonText);
            Console.WriteLine("Enter the flight id:");
            var changeFlightId = int.Parse(Console.ReadLine());
            int count = 0;
            foreach (var item in flights)
            {
                if (item.FlightId.Equals(changeFlightId)) { count++; };
            }
            if (count == 1)
            {
                Edit(flights, changeFlightId);
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

        public static void Edit(List<Flights> flight, int change)
        {
            foreach (var item in flight)
            {
                if (item.FlightId.Equals(change))
                {
                    Console.WriteLine($"{item.FlightId}-{item.City}-{item.Country}-{item.Date}-{item.Time}-{item.Price}-{item.NumberOfSeats}");
                    EditField(flight, change);
                }
            }
        }
        public static void EditField(List<Flights> flight, int change)
        {
            var filePassengers = $"{jsonPath}passenger.json";
            var jsonTextPass = File.ReadAllText(filePassengers);
            var passengers = JsonSerializer.Deserialize<List<Passengers>>(jsonTextPass);

            Console.WriteLine("Choose field to edit:\n 1.Price \n 2.Number of seats");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    {
                        Console.WriteLine("Enter you price:");
                        var ch = double.Parse(Console.ReadLine());
                        for (int i = 0; i < flight.Count; i++)
                        {
                            if (flight[i].FlightId.Equals(change))
                            {
                                flight[i].Price = ch;
                                string jsonString = JsonSerializer.Serialize(flight);
                                var fileName1 = $"{jsonPath}flights.json";
                                File.WriteAllText(fileName1, jsonString);
                                Console.WriteLine("You have successfully changes tge price:");
                            }
                        }
                        break;
                    }
                case "2":
                    Console.WriteLine("Enter your quantity");
                    var quantity = int.Parse(Console.ReadLine());
                    bool isNotReserved = default;

                    for (int i = 0; i < passengers.Count; i++)
                    {
                        for (int j = 0; j < passengers[i].reservation.Count; j++)
                        {
                            if (passengers[i].reservation[j].FlightId.Equals(change))
                            {
                                for (int k = 0; k < flight.Count; k++)
                                {
                                    if (flight[k].FlightId.Equals(change))
                                    {
                                        flight[k].NumberOfSeats = quantity;
                                        string jsonStri = JsonSerializer.Serialize(flight);
                                        var fileName1 = $"{jsonPath}flights.json";
                                        File.WriteAllText(fileName1, jsonStri);
                                        Console.WriteLine("You have successfully changed the quantity, the price is the same:");
                                    }
                                }
                            }
                        }
                    }
                    for (int k = 0; k < flight.Count; k++)
                    {
                        if (flight[k].FlightId.Equals(change))
                        {
                            if (flight[k].NumberOfSeats == quantity + 1)
                            {
                                flight[k].Price = flight[k].Price - flight[k].Price * 0.3;
                                string jsonStr = JsonSerializer.Serialize(flight);
                                var fileName1 = $"{jsonPath}flights.json";
                                File.WriteAllText(fileName1, jsonStr);
                                Console.WriteLine("You have successfully changed the quantity, the price has been changed");
                            }
                            else if ((flight[k].NumberOfSeats == quantity - 1))
                            {
                                flight[k].Price = flight[k].Price + flight[k].Price * 0.5;
                                string jsonSt = JsonSerializer.Serialize(flight);
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
            var filename = $"{jsonPath}flights.json";
            var jsonText = File.ReadAllText(filename);
            var flights = JsonSerializer.Deserialize<List<Flights>>(jsonText);
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
            var filename = $"{jsonPath}flights.json";
            var jsonText = File.ReadAllText(filename);
            var flights = JsonSerializer.Deserialize<List<Flights>>(jsonText);
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
            var filePassengers = $"{jsonPath}passenger.json";
            var jsonTextPass = File.ReadAllText(filePassengers);
            var passengers = JsonSerializer.Deserialize<List<Passengers>>(jsonTextPass);
            var filename = $"{jsonPath}flights.json";
            var jsonText = File.ReadAllText(filename);
            var flights = JsonSerializer.Deserialize<List<Flights>>(jsonText);
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
        public static void MenuItems(int prefix, string message)
        {
            Console.WriteLine($"[{prefix}] {message}");
        }

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