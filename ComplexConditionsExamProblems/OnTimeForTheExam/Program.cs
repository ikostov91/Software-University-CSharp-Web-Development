using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTimeForTheExam
{
    class Program
    {
        static void Main(string[] args)
        {
            int examHour = int.Parse(Console.ReadLine());                   
            int examMinutes = int.Parse(Console.ReadLine());
            int arrivalHour = int.Parse(Console.ReadLine());
            int arrivalMinutes = int.Parse(Console.ReadLine());

            double examTime = (examHour * 60.0) + examMinutes;
            double arrivalTime = (arrivalHour * 60.0) + arrivalMinutes;
            double timeDifference = arrivalTime - examTime;

            if (timeDifference == 0)
            {
                Console.WriteLine("On Time");
            }
            else if (timeDifference > 0)
            {
                Console.WriteLine("Late");
                if (timeDifference < 60)
                {
                    
                    Console.WriteLine("{0} minutes after the start", timeDifference);
                }
                else
                {
                    int hours = (int)timeDifference / 60;
                    int minutes = (int)timeDifference % 60;
                    if (minutes < 10)
                    {
                        Console.WriteLine("{0}:0{1} hours after the start", hours, minutes);
                    }
                    else
                    {
                        Console.WriteLine("{0}:{1} hours after the start", hours, minutes);
                    }
                }
            }
            else if (timeDifference < 0)
            {
                if (timeDifference >= -30)
                {
                    Console.WriteLine("On time");
                    Console.WriteLine("{0} minutes before the start", Math.Abs(timeDifference));
                }
                else
                {
                    if (timeDifference > -60 )
                    {
                        Console.WriteLine("Early");
                        Console.WriteLine("{0} minutes before the start", Math.Abs(timeDifference));
                    }
                    else if (timeDifference <= -60)
                    {
                        Console.WriteLine("Early");
                        int hours = Math.Abs((int)timeDifference / 60);
                        int minutes = Math.Abs((int)timeDifference % 60);
                        if (minutes < 10)
                        {
                            Console.WriteLine("{0}:0{1} hours before the start", hours, minutes);
                        }
                        else
                        {
                            Console.WriteLine("{0}:{1} hours before the start", hours, minutes);
                        }
                    }               
                }
            }
        }
    }
}
