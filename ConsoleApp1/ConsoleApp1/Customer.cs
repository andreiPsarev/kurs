using System;

namespace ConsoleApp1
{
    class Customer
    {
        string surname;
        string name;
        string secondname;

        int b_day;
        int b_month;
        int b_year;

        string city;

        int buy_min;
        int buy_hour;
        int buy_day;
        int buy_month;

        public Customer() { }
        public Customer(string surname_1, string name_1, string secondname_1, int b_day_1, int b_month_1, int b_year_1, string city_1)
        {
            surname = surname_1;
            name = name_1;
            secondname = secondname_1;

            b_day = b_day_1;
            b_month = b_month_1;
            b_year = b_year_1;
            city = city_1;

            buy_hour = DateTime.Now.Hour;
            buy_min = DateTime.Now.Minute;
            buy_day = DateTime.Now.Day;
            buy_month = DateTime.Now.Month;
        }

        public override string ToString()
        {
            string line =String.Empty;

            line += (" ------------------------\n");
            line += ("|Вы вошли как:           |\n");
            line += ("|" + surname + " ");
            line += (name + " ");
            line += (secondname + " ");
            line += ("|\n|" + b_day + ".");
            line += (b_month + ".");
            line += (b_year + ".              |\n");
            line += ("|" + city + "                    |\n");
            line += (" ------------------------\n");
            if ((B_day >= Buy_day || B_day <= Buy_day) && B_month == Buy_month)
            {
                line += ("\t\t\t\t\tС Днем Рождения!!!\n \tВ честь вашего праздника, наш магазин предоставляет вам скидку 10% на сегодня и последующие три дня!");
            }
                return line;
        }

        public string City
        {
            get
            {
                return city;
            }
        }

        public int B_day
        {
            get
            {
                return b_day;
            }
        }

        public int B_month
        {
            get
            {
                return b_month;
            }
        }

        public int B_year
        {
            get
            {
                return b_year;
            }
        }

        public int Buy_min
        {
            get
            {
                return buy_min;
            }
        }

        public int Buy_hour
        {
            get
            {
                return buy_hour;
            }
        }

        public int Buy_day
        {
            get
            {
                return buy_day;
            }
        }

        public int Buy_month
        {
            get
            {
                return buy_month;
            }
        }
    }
}