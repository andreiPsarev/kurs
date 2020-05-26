using System;
using System.Collections.Generic;
using System.IO;
namespace ConsoleApp1
{
    class Store
    {
        string name;
        string address;
        string site;
        int start;
        int finish;
        double SumPrice = 0;
        int itemsInBasket;
        int free_del = 6000;
        int del = 2200;
        int cost_del = 50;
        List<Product> products = new List<Product>();
        List<Product> basket = new List<Product>();
        Customer customer = new Customer();

        public Store()
        {
            start = 10;
            finish = 20;
            name = "offroad boots";
            address = "vul. Sirko 23";
            site = "www.offroad_bots.ua";
        }

        //информация о магазине
        public void Info()
        {
            string line = String.Empty;
            line += "\t\t\t\t --------------------------------------------------\n";
            line += ("\t\t\t\t|Вас приветствует магазин кроссовок '" + name + "'|\n");
            line += ("\t\t\t\t|Сайт нашего магазина: " + site + "\t   |\n");
            line += ("\t\t\t\t|Наш адрес: " + address + "\t\t\t   |\n");
            line += ("\t\t\t\t|Время работы: с " + start + " по " + finish + "\t\t\t   |\n");
            line += "\t\t\t\t --------------------------------------------------\n";
            Console.WriteLine(line);
        }

        //считывание информации о товарах с файла и вывод на экран
        public void Input(string file)
        {
            string line;
            using (StreamReader MyFile = new StreamReader(file))
            {
                while ((line = MyFile.ReadLine()) != null)
                {
                    string[] data = line.Split(' ');
                    if (data.Length == 5)
                    {
                        Product NewProduct = new Product(int.Parse(data[0]), data[1], data[2], data[3], float.Parse(data[4]));
                        products.Add(NewProduct);
                    }
                }
            }

            if (products.Count == 0)
            {
                Console.WriteLine(" ---------------------");
                Console.WriteLine("|Нет товаров в наличии|");
                Console.WriteLine(" ---------------------");
            }
            else
            {
                Console.WriteLine(" -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
                for (int i = 0; i < products.Count; i++)
                {
                    Console.WriteLine(products[i] + "\n");
                }
                Console.WriteLine(" -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
            }
        }

        //Добавление товара в корзину
        public void AddProduct()
        {
            string continueBuying;
            while(true)
            {
                Console.WriteLine("Введите код товара для добавления товара в вашу корзину:");
                int code_1 = int.Parse(Console.ReadLine());
                int t = 0;
                for (int i = 0; i < products.Count; i++)
                {
                    if (products[i].Code == code_1)
                    {
                        basket.Add(products[i]);
                        t++;
                        SumPrice += products[i].Price;
                        Console.WriteLine("Товар с кодом {0} добавлен в вашу корзину!", products[i].Code);
                    }
                }
                if (t == 0)
                {
                    Console.WriteLine("Товара с таким кодом не существует");
                }

                itemsInBasket = basket.Count;

                Console.WriteLine("Желаете продолжить покупки?");
                Console.WriteLine("(да/нет)");
                continueBuying = Console.ReadLine();

                if (String.Equals(continueBuying, "да"))
                    continue;
                else
                {
                    if (String.Equals(continueBuying, "нет"))
                    {
                        ShowBasket();
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Данная операция не поддерживается. Выберите одну из предложенных выше.");
                        break;
                    }
                }
            }
        }

        //Показать выбранный товар
        public void ShowBasket()
        {
            Console.WriteLine("Товары в вашей корзине:");
            if (basket.Count != 0)
            {
                Console.WriteLine(" -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
                for (int i = 0; i < basket.Count; i++)
                {
                    Console.WriteLine(basket[i] + "\n");
                }
                Console.WriteLine(" -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
            }
            else
                Console.WriteLine("Ваша корзина пока пуста. Выберите товар чтобы добавить его в корзину.");
            Console.WriteLine("Сумма вашего заказа равна {0}", SumPrice);

            Console.WriteLine("");
        }

        //Удаление товара
        public void DeleteProduct()
        {
            string continueCleaning;

            while (true)
            {
                int t = 0;
                Console.WriteLine("Введите код товара для удаления из вашей корзины:");
                int code_1 = int.Parse(Console.ReadLine());
                if (basket.Count != 0)
                {
                    for (int i = 0; i < basket.Count; i++)
                    {
                        if (basket[i].Code == code_1)
                        {
                            SumPrice -= basket[i].Price;
                            basket.Remove(basket[i]);
                            itemsInBasket--;
                            Console.WriteLine("Товар удалён из вашей корзины!");
                            t++;
                        }
                    }
                    if (t == 0)
                    {
                        Console.WriteLine("В вашей корзине нет товара с таким кодом");

                    }
                    Console.WriteLine("Желаете продолжить очистку вашей корзины?");
                    Console.WriteLine("(да/нет)");
                    continueCleaning = Console.ReadLine();

                    if (String.Equals(continueCleaning, "да"))
                        continue;
                    else
                    {
                        if (String.Equals(continueCleaning, "нет"))
                        {
                            ShowBasket();
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Данная операция не поддерживается");
                            break;
                        }
                    }

                }
                else
                {
                    Console.WriteLine("Ваша корзина пуста, для начала добавьте товар, чтобы удалить его");
                }
            }
        }

        //Сортировка товара по возрастанию/убыванию цены
        public void SortProduct()
        {
            Console.WriteLine("Выберите тип сортировки: по возастанию цены(>), или по убыванию(<)");
            string tSort = Console.ReadLine();
            switch(tSort)
            {
                case (">"):
                    Console.WriteLine("Товар отсортирован по возрастанию цены.");
                    Console.WriteLine(" -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
                    products.Sort();
                    for (int i = 0; i < products.Count; i++)
                    {
                        Console.WriteLine(products[i] + "\n");
                    }
                    Console.WriteLine(" -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
                    break;

                case ("<"):
                    Console.WriteLine("Товар отсортирован по убыванию цены.");
                    Console.WriteLine(" -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
                    products.Sort();
                    products.Reverse();
                    for (int i = 0; i < products.Count; i++)
                    {
                        Console.WriteLine(products[i] + "\n");
                    }
                    Console.WriteLine(" -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
                    break;
                default:
                    Console.WriteLine("Недопустимая операция.");
                    break;
            }
            
        }

        //поиск по критерию на выбор
        public void Search()
        {
            Console.WriteLine("Введите критерий для поиска:\n1 - по коду, 2 - по типу, 3 - по фирме, 4 - по размеру, 5 - по цене");
            string temp = Console.ReadLine();
            switch(temp)
            {
                case ("1"):
                    int c = 0;
                    Console.WriteLine("Введите код товара для поиска");
                    int need_code = int.Parse(Console.ReadLine());
                    Console.WriteLine("Список товаров подходящих под ваш запрос:");
                    Console.WriteLine(" =================================================================================");
                    for (int i = 0; i < products.Count; i++)
                    {
                        if (String.Equals(products[i].Code, need_code))
                        {
                            Console.WriteLine(products[i] + "\n");
                            c++;
                        }
                    }
                    Console.WriteLine(" =================================================================================");
                    if (c == 0)
                    {
                        Console.WriteLine("В нашем магазине нет товаров с таким кодом.");
                    }
                    break;

                case ("2"):
                    int t = 0;
                    Console.WriteLine("Введите тип товара для поиска");
                    string need_type = Console.ReadLine();
                    Console.WriteLine("Список товаров подходящих под ваш запрос:");
                    Console.WriteLine(" =================================================================================");
                    for (int i = 0; i < products.Count; i++)
                    {
                        if (String.Equals(products[i].Type, need_type))
                        {
                            Console.WriteLine(products[i] + "\n");
                            t++;
                        }
                    }
                    Console.WriteLine(" =================================================================================");
                    if (t == 0)
                    {
                        Console.WriteLine("В нашем магазине нет товаров такого типа.");
                    }
                    break;

                case ("3"):
                    int f = 0;
                    Console.WriteLine("Введите название фирмы для поиска");
                    string need_name = Console.ReadLine();
                    Console.WriteLine("Список товаров подходящих под ваш запрос:");
                    Console.WriteLine(" =================================================================================");
                    for (int i = 0; i < products.Count; i++)
                    {
                        if (String.Equals(products[i].Name, need_name))
                        {
                            Console.WriteLine(products[i] + "\n");
                            f++;
                        }
                    }
                    Console.WriteLine(" =================================================================================");
                    if (f == 0)
                    {
                        Console.WriteLine("В нашем магазине нет товаров данной фирмы.");
                    }
                    break;

                case ("4"):
                    int s = 0;
                    Console.WriteLine("Введите размер для поиска");
                    string need_size = Console.ReadLine();
                    Console.WriteLine("Список товаров подходящих под ваш запрос:");
                    Console.WriteLine(" =================================================================================");
                    for (int i = 0; i < products.Count; i++)
                    {
                        if (String.Equals(products[i].Size, need_size))
                        {
                            Console.WriteLine(products[i] + "\n");
                            s++;
                        }
                    }
                    Console.WriteLine(" =================================================================================");
                    if (s == 0)
                    {
                        Console.WriteLine("В нашем магазине нет товаров данного размера.");
                    }
                    break;
                case ("5"):
                    int p = 0;
                    Console.WriteLine("Введите точную цену для поиска");
                    float need_price = float.Parse(Console.ReadLine());
                    Console.WriteLine("Список товаров подходящих под ваш запрос:");
                    Console.WriteLine(" =================================================================================");
                    for (int i = 0; i < products.Count; i++)
                    {
                        if (String.Equals(products[i].Price, need_price))
                        {
                            Console.WriteLine(products[i] + "\n");
                            p++;
                        }
                    }
                    Console.WriteLine(" =================================================================================");
                    if (p == 0)
                    {
                        Console.WriteLine("В нашем магазине нет товаров по такой цене.");
                    }
                    break;
            }
        }

        //Скидка в день рождения
        public void Birthday()
        {
            if((customer.B_day >= customer.Buy_day || customer.B_day <= customer.Buy_day) && customer.B_month == customer.Buy_month)
            {
                Console.WriteLine("С Днём Рождения!\nВ честь вашего праздника, наш магазин предоставляет вам скидку в 10% и бесплатную доставку.");
                SumPrice = SumPrice * 0.9;
            }
        }

        //Подтвердить заказ
        public void Accept()
        {
            if (basket.Count == 0)
            {
                Console.WriteLine("Ваша корзина пуста. Для подтверждения заказа, выберите хотя бы один товар.");
            }
            else
            {
                if (customer.Buy_hour < start || customer.Buy_hour > finish)
                {
                    Console.WriteLine("Мы обрабатываем заказы с {0} до {1} каждый день. Повторите свой заказ в указанный временной промежуток", start, finish);
                }       

                if(((customer.B_day >= customer.Buy_day || customer.B_day <= customer.Buy_day) && customer.B_month == customer.Buy_month))
                {
                    Birthday();
                    Console.WriteLine("Сумма вашей покупки с учетом скидки:{0}", SumPrice);
                }
                else
                {
                    if (SumPrice >= free_del)
                    {
                        SumPrice = SumPrice * 0.93;
                        Console.WriteLine("Сумма вашего заказа составляет Больше 6а000 грн, вам предоставлена скидка 7% и бесплатная доставка\n" +
                            "Сумма вашей покупки с учетом скидки:{0}", SumPrice);
                    }
                    else
                    {
                        if (SumPrice >= del)
                        {
                            SumPrice = SumPrice * 0.95;
                            double PriceDelivery = SumPrice + cost_del;
                            Console.WriteLine("Сумма покупки вашего заказа со скидкой 5% = {0}\n" +
                                "Стоимость доставки = {1}\nОбщая сумма вашей покупки с доставкой = {2}", SumPrice, cost_del, PriceDelivery);
                        }
                        else
                        {
                            double PriceDelivery = SumPrice + cost_del;
                            Console.WriteLine("Сумма вашего заказа = {0}\nСтоимость доставки = {1}\n" +
                                "Общая сумма вашей покупки с доставкой = {2}", SumPrice, cost_del, PriceDelivery);
                        }
                    }
                }       
                Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\tДата и время заказа\n\t\t\t\t\t\t\t\t\t\t\t\t{0}.{1}   {2}:{3}", customer.Buy_day, customer.Buy_month, customer.Buy_hour, customer.Buy_min);
            }         
        }

        //Информация о покупателе
        public void CustomerInfo(string file)
        {
            Console.WriteLine("Перед началом покупок необходимо авторизоваться.\nВведите свои данные в файл 'file2.txt' в формате " +
                "(ФИО, дата рождения, город)\nПосле ввода нажмите Enter.");
            Console.ReadKey();
            using (StreamReader MyFile = new StreamReader(file))
            {
                string line;
                while((line = MyFile.ReadLine()) != null)
                {
                    string[] data = line.Split(' ');
                    if(data.Length == 7)
                    {
                        customer = new Customer(data[0], data[1], data[2], int.Parse(data[3]), int.Parse(data[4]), int.Parse(data[5]), data[6]);
                    }
                }
            }
            Console.WriteLine(customer);

            if (String.Equals(customer.City, ("Kiev")) || String.Equals(customer.City, ("Lvov")))
            {
                Console.WriteLine("В ваш город возможна отправка только Новой Почтой");
            }
            else
            {
                Console.WriteLine("В ваш город возможна доставка Новой Почтой и Укрпочтой");
            }
        }

        //меню с возможными операциями
        public void Operations()
        {
            Store menu = new Store();
            Console.WriteLine();
            Console.WriteLine("\t\t\t\t\t\tВведите операцию:\n " +
                "\t\t1- Поиск товара по фирме  \t\t\t2- Сортировка по цене\n\n" +
                "\t\t3- Добавить товар в корзину  \t\t\t4- Удалить товар из корзины\n\n" +
                "\t\t5- Показать содержимое корзины  \t\t6- Подтвертить заказ");
            string operation = Console.ReadLine();
            switch (operation)
            {
                case ("1"):
                    Search();
                    Operations();
                    break;

                case ("2"):
                    SortProduct();
                    Operations();
                    break;

                case ("3"):
                    AddProduct();
                    Operations();
                    break;

                case ("4"):
                    DeleteProduct();
                    Operations();
                    break;

                case ("5"):
                    ShowBasket();
                    Operations();
                    break;

                case ("6"):
                    Accept();
                    break;

                default:
                    Console.WriteLine("Операция не существует");
                    break;
            }
        }
    }
}