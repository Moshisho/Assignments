using ShapesHandler;
using ShapesHandler.Utils;
using System;
using System.Collections.Generic;
using System.Threading;

namespace SelaShapesAssignment
{
    class Program
    {
        private static List<string> strings = new List<string>();
        private static ConsoleKey pressedKey;
        private static ShapesCollection shapes = new ShapesCollection();

        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Hello there!");
            PrintHelp();

            shapes.Added += Shapes_Added;

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

        private static void Shapes_Added(object sender, ShapeAddedEventArgs e)
        {
            Console.WriteLine(e.Prefix + sender.ToStringExtension() + "; Happened On: " + e.HappenedOn);
        }

        private static I2DShape AddNewShape()
        {
            I2DShape shape = null;

            PrintAddNewShapeHelp();

            while (shape == null)
            {
                
                pressedKey = Console.ReadKey().Key;
                Console.Write(Environment.NewLine);

                try
                {

                    switch (pressedKey)
                    {
                        case ConsoleKey.D1:
                            Console.WriteLine("Enter a side length:");
                            shape = new Square(GetNumFromConsoleAndVerifyIt());
                            break;
                        case ConsoleKey.D2:
                            Console.WriteLine("Enter a height length:");
                            double height = GetNumFromConsoleAndVerifyIt();
                            Console.WriteLine("Enter a width length:");
                            double width = GetNumFromConsoleAndVerifyIt();
                            shape = new Rectangle(height, width);
                            break;
                        case ConsoleKey.D3:
                            Console.WriteLine("Enter a radius length:");
                            shape = new Circle(GetNumFromConsoleAndVerifyIt());
                            break;
                        case ConsoleKey.D4:
                            Console.WriteLine("Enter a triangle height length:");
                            double triangleHeight = GetNumFromConsoleAndVerifyIt();
                            Console.WriteLine("Enter a triangle width length:");
                            double triangleWidth = GetNumFromConsoleAndVerifyIt();
                            shape = new RightTriangle(triangleHeight, triangleWidth);
                            break;
                        default:
                            throw new ArgumentException();
                    }
                }
                catch (ArgumentException)
                {
                    PrintAddNewShapeWarning();
                    PrintAddNewShapeHelp();
                }
            }

            return shape;
        }

        private static double GetNumFromConsoleAndVerifyIt()
        {
            string enteredKeys = Console.ReadLine();
            double num;
            if (Double.TryParse(enteredKeys, out num))
            {
                return num;
            }
            else
            {
                throw new ArgumentException();
            }
        }

        #region consolePrints

        private static void PrintAddNewShapeHelp()
        {
            Console.Write(@"Please enter a number for the required shape:
1.	Square
2.	Rectangle
3.	Circle 
4.	Right triangle" + Environment.NewLine);
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
