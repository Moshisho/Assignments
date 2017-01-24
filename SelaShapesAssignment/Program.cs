using ShapesHandler;
using ShapesHandler.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;

namespace SelaShapesAssignment
{
    class Program
    {
        private static ConsoleKey pressedKey;
        private static ShapesCollection shapes = new ShapesCollection();
        private static IEnumerable<Type> shapeTypes = GetI2DShapeImplementationsWithoutAbstract();

        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Hello there!");
            PrintHelp();

            do
            {
                pressedKey = Console.ReadKey().Key;
                Console.Write(Environment.NewLine);

                switch (pressedKey)
                {
                    case ConsoleKey.D1:
                        shapes.Add(AddNewShape());
                        break;
                    case ConsoleKey.D2:
                        ListAllShapes();
                        break;
                    case ConsoleKey.D3:
                        SumAllCircumferences();
                        break;
                    case ConsoleKey.D4:
                        SumAllArea();
                        break;
                    case ConsoleKey.D5:
                        FindBiggestCircumference();
                        break;
                    case ConsoleKey.D6:
                        FindBiggestArea();
                        break;
                    case ConsoleKey.D7:
                        Console.WriteLine("Exiting...");
                        Thread.Sleep(2 * 1000);
                        break;
                    default:
                        Console.WriteLine("Option not implemented!");
                        PrintHelp();
                        break;
                }

            } while (pressedKey != ConsoleKey.D7);

            Environment.Exit(0);
        }

        private static I2DShape AddNewShape()
        {
            I2DShape shape = null;

            PrintAddNewShapeHelp();

            while (shape == null)
            {
                string shapeNameEntered = Console.ReadLine();
                Console.Write(Environment.NewLine);

                try
                {
                    // Use reflection to get the type and it's required params:
                    Type shapeType = shapeTypes.Where(t => t.FullName.ToLower().Contains(shapeNameEntered.ToLower())).First();
                    var ctors = shapeType.GetConstructors();
                    var ctor = ctors[0];
                    
                    List<object> sides = new List<object>();
                    foreach (ParameterInfo pi in ctor.GetParameters())
                    {
                        sides.Add(GetNumFromConsole(pi.Name));
                    }
                    shape = (I2DShape)ctor.Invoke(sides.ToArray());
                }
                catch (FormatException)
                {
                    PrintAddNewShapeWarning();
                    PrintAddNewShapeHelp();
                }
            }

            Console.WriteLine("Added: " + shape.ToStringExtension());

            return shape;
        }

        private static IEnumerable<Type> GetI2DShapeImplementationsWithoutAbstract()
        {
            Type type = typeof(I2DShape);
            return AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => type.IsAssignableFrom(p) && !p.IsAbstract && p.IsClass);
        }

        private static double GetNumFromConsole(string nameOfParam)
        {
            Console.WriteLine("Please enter a length parameter for " + nameOfParam);
            return Double.Parse(Console.ReadLine());
        }

        #region consolePrints

        private static void PrintAddNewShapeHelp()
        {
            Console.WriteLine(@"Please enter the name of the required shape:");
            Console.Write(String.Join(Environment.NewLine, shapeTypes.Select(s => s.Name)));
            Console.WriteLine();
        }

        private static void PrintHelp()
        {
            Console.Write(@"Please select an action by entering a number from the list:
1.	Add new shape
2.	List all shapes
3.	Sum all circumferences
4.	Sum all areas
5.	Find biggest circumference
6.	Find biggest area
7.	Exit" + Environment.NewLine);
        }

        private static void PrintAddNewShapeWarning()
        {
            Console.WriteLine("You must enter a valid number!");
        }

        private static void ListAllShapes()
        {
            if (shapes.Count == 0)
                Console.WriteLine("No Items yet...");

            shapes.ForEach(shape => Console.WriteLine(shape.ToStringExtension()));
        }

        private static void SumAllCircumferences()
        {
            Console.WriteLine("Circumferences Sum = " + shapes.CircumferencesSum);
        }

        private static void SumAllArea()
        {
            Console.WriteLine("Areas Sum = " + shapes.AreasSum);
        }

        private static void FindBiggestCircumference()
        {
            if (shapes.Count == 0)
            {
                Console.WriteLine("No Items yet...");
                return;
            }
            Console.WriteLine("Biggest Circumferences = " + shapes.BiggestCircumference);
        }

        private static void FindBiggestArea()
        {
            if (shapes.Count == 0)
            {
                Console.WriteLine("No Items yet...");
                return;
            }
            Console.WriteLine("Biggest Area = " + shapes.BiggestArea);
        }

        #endregion


    }
}
