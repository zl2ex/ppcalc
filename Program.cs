using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ppcalc
{
    class Program
    {
        static void printHelpMsg()
        {
            Console.Write("ppcalc 1v0\r\n");
            Console.Write("-f    \"Filename\"   -  full path to the pick and place file to edit\r\n");
        }

        static float getFloatInput(string inputMsg)
        {
            bool isNumber;
            do
            {
                Console.Write(inputMsg);
                string input = Console.ReadLine();
                float output;
                isNumber = float.TryParse(input, out output);
                if (isNumber)
                {
                    return output;
                }
                else
                {
                    Console.Write("\r\n");
                    Console.Write(input);
                    Console.Write(" is not a valid number\r\n");
                }
            }
            while (!isNumber);
            return 0; // should never happen , just to keep the compiler happy :-)
        }
        static void Main(string[] args)
        {
            if(args.Length == 2)
            {
                if (args[0] == "-f")
                {
                    string fileName = args[1];
                    if (!File.Exists(fileName))
                    {
                        Console.Write(fileName);
                        Console.Write(" Does not exist\r\n");
                        return;
                    }
                    else
                    {
                        Console.Write("All Entered Values should come from the Camera coorinates\r\n");
                        float botLeftFedX = getFloatInput("Enter Bottom left Feducal X :");
                        float botLeftFedy = getFloatInput("Enter Bottom left Feducal Y :");

                        float topRightFedX = getFloatInput("Enter Top Right Feducal X :");
                        float topRightFedY = getFloatInput("Enter Top Right Feducal Y :");

                        float knownCompPPX = getFloatInput("Enter Known Component From Pick place File X :");
                        float knownCompPPY = getFloatInput("Enter Known Component From Pick place File Y :");

                        int pcbNum = 0;
                        while(true)
                        {
                            float knownCompX = getFloatInput("Enter Known Component Actual X :");
                            float knownCompY = getFloatInput("Enter Known Component Actual Y :");

                            float mark_1_x = botLeftFedX - knownCompX + knownCompPPX;
                            float mark_1_y = botLeftFedy - knownCompY + knownCompPPY;
                            float mark_2_x = topRightFedX - knownCompX + knownCompPPX;
                            float mark_2_y = topRightFedY - knownCompY + knownCompPPY;


                            Console.Write("-------------------------\r\n");
                            Console.Write("PCB : " + pcbNum + "\r\n");
                            Console.Write("Mark 1 X : " + mark_1_x + " Mark 1 Y : " + mark_1_y + "\r\n");
                            Console.Write("Mark 2 X : " + mark_2_x + " Mark 2 Y : " + mark_2_y + "\r\n");
                            Console.Write("-------------------------\r\n");
                            pcbNum++;
                        }
                    }
                }
                else
                {
                    printHelpMsg();
                }
            }
            else
            {
                printHelpMsg();
            }
        }
    }
}
