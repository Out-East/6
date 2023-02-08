using Newtonsoft.Json;
using System.Xml.Linq;
using System.Xml.Serialization;
using static System.Net.Mime.MediaTypeNames;
namespace Practical_6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            wwf Fruct = new wwf();
            Fruct.Name = "Ананас";
            Fruct.Height = 100;
            Fruct.Width = 100;
            wwf Fruct1 = new wwf();
            Fruct1.Name = "Киви";
            Fruct1.Height = 50;
            Fruct1.Width = 25;


            List<wwf> figure = new List<wwf>();
            figure.Add(Fruct);
            figure.Add(Fruct1);


            Console.WriteLine("Вставьте путь файла");
            Console.WriteLine("------------------------------------------------");
            string put = Console.ReadLine();

            if (File.Exists(put))
            {
                Console.Clear();


                string txt = File.ReadAllText(put);
                Console.WriteLine(txt);


                Console.WriteLine("Сохранить файл (xml, json, txt) - F1.Закрыть  - Escape.");


                ConsoleKeyInfo klav = Console.ReadKey();
                while (klav.Key != ConsoleKey.Escape)
                {
                    if (klav.Key == ConsoleKey.F1)
                    {
                        Console.Clear();
                        Console.WriteLine("Вставьте путь файла куда вы хотите его сохранить");
                        string path = Console.ReadLine();

                        if (path.Contains("json"))
                        {
                            if (put.Contains("txt"))
                            {
                                SerialandDeserial.JsonSerial(figure, path);
                            }
                            else
                            {
                                SerialandDeserial.JsonDeserial(path);
                            }
                        }
                        else if (path.Contains("xml"))
                        {
                            if (put.Contains("txt"))
                            {
                                SerialandDeserial.XmlSerial(figure, path);
                            }
                            else
                            {
                                SerialandDeserial.JsonDeserial(path);
                            }
                        }

                    }
                    else if (klav.Key == ConsoleKey.Escape)
                    {
                        break;
                    }
                    klav = Console.ReadKey();
                }
            }
        }
    }
}