using System;

namespace ConsoleApp1
{
    class Product:IComparable
    {
        int code;
        string type;
        string name;
        string size;
        float price;
        public Product() { }
        public Product (int code_1, string type_1, string name_1, string size_1, float price_1)
        {
            code = code_1;
            type = type_1;
            name = name_1;
            size = size_1;
            price = price_1;
        }

        public override string ToString()
        {
            string line = String.Empty;
            line += ("|Код товара: " + code + "\t");
            line += ("Тип одежды: " + type + "\t");
            line += ("Фирма: " + name + "\t");
            line += ("Размер: " + size + "\t");
            line += ("Цена: " + price + "|\t");
            return line;
        }

        public int Code
        {
            get
            {
                return code;
            }
        }

        public string Type
        {
            get
            {
                return type;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }
        }

        public string Size
        {
            get
            {
                return size;
            }
        }

        public float Price
        {
            get
            {
                return price;
            }
        }

        public int CompareTo(object obj)
        {
            Product a = (Product)obj;
            if (this.Price == a.Price)
                return 0;
            else if (this.Price > a.Price)
                return 1;
            else
                return -1;
        }
    }
}
