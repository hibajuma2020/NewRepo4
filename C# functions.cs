using System;
using System.Globalization;
using System.Linq;

namespace Practice1
{
    internal class Program
    {
        
        static string[] products = { "Laptop", "Phone", "Tablet", "Monitor", "Keyboard", "Mouse", "Headset", "Webcam", "Speaker", "Router" };
        static double[] prices = { 450, 180, 220, 310, 35, 25, 75, 55, 90, 65 };

        static void Main(string[] args)
        {
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("1.Today's Greeting");
                Console.WriteLine("2.Star Border");
                Console.WriteLine("3.Random Quote");
                Console.WriteLine("4.Invoice Header");
                Console.WriteLine("5.Number Pattern");
                Console.WriteLine("6.Word Stats");
                Console.WriteLine("7.Temperature Converter");
                Console.WriteLine("8.Password Strength");
                Console.WriteLine("9.Statistics");
                Console.WriteLine("10.Session Info");
                Console.WriteLine("11.Magic Number");
                Console.WriteLine("12.Day Message");
                Console.WriteLine("13.Discount");
                Console.WriteLine("14.Report Header");
                Console.WriteLine("15.Product Search");
                Console.WriteLine("0.Exit");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        PrintDailyGreeting();
                        break;

                    case 2:
                        PrintStarBorder();
                        break;

                    case 3:
                        PrintRandomQuote();
                        break;

                    case 4:
                        Console.Write("Enter name: ");
                        string name = Console.ReadLine();

                        Console.Write("Enter date: ");
                        string date = Console.ReadLine();

                        PrintInvoiceHeader(name, date);
                        break;

                    case 5:
                        PrintNumberPattern(4);
                        break;

                    case 6:
                        PrintWordStats("Hello world from C sharp");
                        break;

                    case 7:
                        Console.WriteLine(ConvertTemperature(30, "C", "F"));
                        break;

                    case 8:
                        Console.WriteLine(GetPasswordStrength("Abc@1234"));
                        break;

                    case 9:
                        Console.WriteLine(CalculateStats(new int[] { 1, 2, 3, 4, 5 }));
                        break;

                    case 10:
                        Console.WriteLine(GetSessionInfo());
                        break;

                    case 11:
                        Console.WriteLine(GenerateMagicNumber());
                        break;

                    case 12:
                        Console.WriteLine(GetDayMessage());
                        break;

                    case 13:
                        Console.WriteLine(CalculateDiscount(100, 10));
                        Console.WriteLine(CalculateDiscount(100, 10, 5));
                        break;

                    case 14:
                        PrintReportHeader("MONTHLY REPORT");
                        PrintReportHeader("CUSTOM", 60, '-');
                        break;

                    case 15:
                        SearchProducts("phone");
                        SearchProducts(50, 200);
                        SearchProducts("top", 300);
                        break;

                    case 16:
                        exit = true;
                        break;
                }
            }
        }

        // 1
        static void PrintDailyGreeting()
        {
            Console.WriteLine("Good morning, Trainee!");
            Console.WriteLine("Date: " + DateTime.Now.ToString("dd/MM/yyyy"));
            Console.WriteLine("Time: " + DateTime.Now.ToString("hh:mm tt"));
            Console.WriteLine("Let's code something great today!");
        }

        // 2
        static void PrintStarBorder()
        {
            for (int i = 0; i < 40; i++) Console.Write("*");
            Console.WriteLine();
            Console.WriteLine(" Welcome to C# Functions!");
            for (int i = 0; i < 40; i++) Console.Write("*");
            Console.WriteLine();
        }

        // 3
        static void PrintRandomQuote()
        {
            string[] quotes = { "Keep going", "Never quit", "Stay strong", "Code daily", "You can do it" };

            Random r = new Random();
            int index = r.Next(quotes.Length);

            Console.WriteLine("----------------");
            Console.WriteLine(quotes[index]);
            Console.WriteLine("----------------");
        }

        // 4
        static void PrintInvoiceHeader(string customerName, string invoiceDate)
        {
            TextInfo t = CultureInfo.CurrentCulture.TextInfo;
            customerName = t.ToTitleCase(customerName.ToLower());

            if (string.IsNullOrWhiteSpace(invoiceDate))
                invoiceDate = "Date not provided";

            Console.WriteLine("=====================");
            Console.WriteLine("INVOICE");
            Console.WriteLine("Customer: " + customerName);
            Console.WriteLine("Date: " + invoiceDate);
            Console.WriteLine("=====================");
        }

        // 5
        static void PrintNumberPattern(int rows)
        {
            if (rows < 1)
            {
                Console.WriteLine("Invalid input");
                return;
            }

            for (int i = 1; i <= rows; i++)
            {
                for (int j = 1; j <= i; j++)
                    Console.Write(j + " ");
                Console.WriteLine();
            }
        }

        // 6
        static void PrintWordStats(string s)
        {
            if (string.IsNullOrWhiteSpace(s))
            {
                Console.WriteLine("Empty");
                return;
            }

            string[] words = s.Split(' ');

            Console.WriteLine("Count: " + words.Length);

            string longest = words[0];
            string shortest = words[0];

            foreach (var w in words)
            {
                if (w.Length > longest.Length) longest = w;
                if (w.Length < shortest.Length) shortest = w;
            }

            Console.WriteLine("Longest: " + longest);
            Console.WriteLine("Shortest: " + shortest);

            Array.Reverse(words);
            Console.WriteLine(string.Join(" ", words));
        }

        // 7
        static double ConvertTemperature(double v, string from, string to)
        {
            double r;

            if (from == "C" && to == "F") r = (v * 9 / 5) + 32;
            else if (from == "C" && to == "K") r = v + 273.15;
            else if (from == "F" && to == "C") r = (v - 32) * 5 / 9;
            else if (from == "K" && to == "C") r = v - 273.15;
            else return -999;

            return Math.Round(r, 2);
        }

        // 8
        static string GetPasswordStrength(string p)
        {
            int score = 0;

            if (p.Length >= 8) score++;
            if (p.Any(char.IsUpper)) score++;
            if (p.Any(char.IsDigit)) score++;
            if (p.Any(c => "!@#$%^&*".Contains(c))) score++;

            if (score <= 1) return "Weak";
            else if (score <= 3) return "Moderate";
            else return "Strong";
        }

        // 9
        static string CalculateStats(int[] arr)
        {
            if (arr == null || arr.Length == 0)
                return "No data provided";

            return $"Min:{arr.Min()}, Max:{arr.Max()}, Sum:{arr.Sum()}, Avg:{Math.Round(arr.Average(), 2)}";
        }

        // 10
        static string GetSessionInfo()
        {
            DateTime now = DateTime.Now;

            string session = now.Hour < 12 ? "Morning" :
                             now.Hour <= 17 ? "Afternoon" : "Evening";

            return $"{now.DayOfWeek}, {now:MMMM dd, yyyy}, {session}";
        }

        // 11
        static int GenerateMagicNumber()
        {
            Random r = new Random();

            while (true)
            {
                int num = r.Next(1000, 9999);
                int sum = 0;
                int temp = num;

                while (temp > 0)
                {
                    sum += temp % 10;
                    temp /= 10;
                }

                if (IsPrime(sum))
                    return num;
            }
        }

        static bool IsPrime(int n)
        {
            if (n < 2) return false;

            for (int i = 2; i < n; i++)
                if (n % i == 0) return false;

            return true;
        }

        // 12
        static string GetDayMessage()
        {
            return DateTime.Now.DayOfWeek switch
            {
                DayOfWeek.Monday => "New week!",
                DayOfWeek.Tuesday => "Keep going!",
                DayOfWeek.Wednesday => "Halfway!",
                DayOfWeek.Thursday => "Almost!",
                DayOfWeek.Friday => "Last sprint!",
                _ => "Rest!"
            };
        }

        // 13
        static double CalculateDiscount(double price, double percent)
        {
            double d = price * percent / 100;
            return Math.Round(Math.Max(price - d, 0), 3);
        }

        static double CalculateDiscount(double price, double percent, double cap)
        {
            double d = price * percent / 100;
            d = Math.Min(d, cap);
            return Math.Round(Math.Max(price - d, 0), 3);
        }

        static double[] CalculateDiscount(double[] prices, double percent)
        {
            double[] result = new double[prices.Length];

            for (int i = 0; i < prices.Length; i++)
                result[i] = CalculateDiscount(prices[i], percent);

            return result;
        }

        // 14
        static void PrintReportHeader(string title, int width = 50, char c = '=')
        {
            string line = new string(c, width);
            Console.WriteLine(line);
            Console.WriteLine(title.PadLeft((width + title.Length) / 2));
            Console.WriteLine(line);
            Console.WriteLine("Generated on: " + DateTime.Now);
            Console.WriteLine(line);
        }

        // 15
        static void SearchProducts(string keyword)
        {
            for (int i = 0; i < products.Length; i++)
                if (products[i].ToLower().Contains(keyword.ToLower()))
                    Console.WriteLine(products[i] + " - " + prices[i] + " OMR");
        }

        static void SearchProducts(double min, double max)
        {
            for (int i = 0; i < products.Length; i++)
                if (prices[i] >= min && prices[i] <= max)
                    Console.WriteLine(products[i] + " - " + prices[i] + " OMR");
        }

        static void SearchProducts(string keyword, double max)
        {
            for (int i = 0; i < products.Length; i++)
                if (products[i].ToLower().Contains(keyword.ToLower()) && prices[i] <= max)
                    Console.WriteLine(products[i] + " - " + prices[i] + " OMR");
        }
    }
}