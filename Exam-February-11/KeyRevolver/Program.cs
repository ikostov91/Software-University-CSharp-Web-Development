using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;

namespace KeyRevolver
{
    class Program
    {
        static void Main(string[] args)
        {
            int bulletPrice = int.Parse(Console.ReadLine());
            int gunBarrelSize = int.Parse(Console.ReadLine());
            Stack<int> bullets = new Stack<int>(Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());
            Queue<int> locks = new Queue<int>(Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList());
            int intelligence = int.Parse(Console.ReadLine());

            int moneyToDeduct = 0;
            bool allLocksShot = false;

            while (true)
            {
                for (int i = 0; i < gunBarrelSize; i++)
                {
                    if (bullets.Count == 0 && locks.Count > 0)
                    {
                        Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
                        return;
                    }

                    if (locks.Count == 0)
                    {
                        allLocksShot = true;
                        break;
                    }

                    int currentBullet = bullets.Pop();
                    int currentLock = locks.Peek();

                    if (currentBullet <= currentLock)
                    {
                        Console.WriteLine("Bang!");
                        locks.Dequeue();
                    }
                    else
                    {
                        Console.WriteLine("Ping!");
                    }

                    moneyToDeduct += bulletPrice;
                }

                if (allLocksShot)
                {
                    break;
                }

                if (bullets.Count > 0)
                {
                    Console.WriteLine("Reloading!");
                }
            }

            Console.WriteLine($"{bullets.Count} bullets left. Earned ${intelligence - moneyToDeduct}");
        }
    }
}
