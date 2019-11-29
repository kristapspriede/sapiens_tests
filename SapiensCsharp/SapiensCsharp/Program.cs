using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Newtonsoft.Json;

namespace SapiensCsharp
{
    public class Program
    {
        public static bool IsValidPath(string path, bool exactPath = true)
        {
            bool isValid = true;

            try
            {
                string fullPath = Path.GetFullPath(path);

                if (exactPath)
                {
                    string root = Path.GetPathRoot(path);
                    isValid = string.IsNullOrEmpty(root.Trim(new char[] { '\\', '/' })) == false;
                }
                else
                {
                    isValid = Path.IsPathRooted(path);
                }
            }
            catch (Exception ex)
            {
                isValid = false;
            }

            return isValid;
        }

        public static void Main(string[] args)
        {
            string inputPath = string.Empty;
            string outputPath = string.Empty;
            do
            {
                Console.WriteLine("Please enter XML file path:");
                var path = Console.ReadLine();

                if (!IsValidPath(path))
                {
                    Console.WriteLine();
                    Console.WriteLine("Invalid path");
                    Console.WriteLine();
                }
                if (IsValidPath(path))
                {
                    inputPath = path;
                }

            } while (inputPath == string.Empty);
            do
            {
                Console.WriteLine("Please enter Json file path:");
                var path = Console.ReadLine();
                if (!IsValidPath(path))
                {
                    Console.WriteLine();
                    Console.WriteLine("Invalid path");
                    Console.WriteLine();
                }
                if (IsValidPath(path))
                {
                    outputPath = path;
                }

            } while (outputPath == string.Empty);

            //test input path: C:/Users/krist/OneDrive/Desktop/Sapiens tests/C#/input.xml
            //test output path: C:/Users/krist/OneDrive/Desktop/Sapiens tests/C#/test.txt
            double var1 = 0;
            double var2 = 0;

            var list = new List<Object>();
            using (XmlReader reader = XmlReader.Create(inputPath))
            {
                while (reader.Read())
                {
                    if (reader.IsStartElement())
                    {
                        switch (reader.Name)
                        {
                            case "variable1":
                                var1 = XmlConvert.ToInt32(reader.ReadInnerXml());
                                break;
                            case "variable2":
                                var2 = XmlConvert.ToInt32(reader.ReadInnerXml());
                                Object obj = new Object();
                                try
                                {
                                    obj.SafeDivision(var1, var2);
                                }
                                catch (DivideByZeroException)
                                {
                                    Console.WriteLine("Attempted divide by zero.");
                                }
                                obj.divided = obj.SafeDivision(var1, var2);
                                obj.multiplied = (int)obj.Multiplication(var1, var2);
                                list.Add(obj);
                                obj = new Object();
                                break;
                        }
                    }
                }

                if (File.Exists(outputPath))
                {
                    File.Delete(outputPath);
                }
                using (StreamWriter file = File.CreateText(outputPath))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Serialize(file, list);
                }
            }
            Console.ReadKey();

        }
    }
}
