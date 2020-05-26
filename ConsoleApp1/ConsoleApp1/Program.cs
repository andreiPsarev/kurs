using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Store shop = new Store();
                shop.Info();
                shop.CustomerInfo("file2.txt");
                shop.Input("file1.txt");
                shop.Operations();
                Console.ReadKey();
            }
            catch (FormatException)
            {
                Console.WriteLine("Неверный формат ввода данных");
                Console.ReadKey();
            }
            catch (OverflowException)
            {
                Console.WriteLine("Переполнение массива");
                Console.ReadKey();
            }
            catch (OutOfMemoryException)
            {
                Console.WriteLine("Недостаточно памяти");
                Console.ReadKey();
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Данный файл не существует");
                Console.ReadKey();
            }
            catch (System.Threading.ThreadAbortException)
            {
                Console.WriteLine("Ожидайте добавление товара");
                Console.ReadKey();
            }
        }
    }
}