using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Database
{
    public class Database
    {
        private const int ArrayCapacity = 16;

        private readonly int[] databaseItems;
        private int currentIndex;

        public Database(params int[] inputItems)
        {
            this.databaseItems = new int[ArrayCapacity];

            if (inputItems.Length > ArrayCapacity)
            {
                throw new InvalidOperationException("Input exceeds capacity");
            }

            this.currentIndex = 0;
            foreach (var item in inputItems)
            {
                this.databaseItems[currentIndex] = item;
                currentIndex++;
            }
        }

        public int this[int i]
        {
            get { return this.databaseItems[i]; }
        }

        public void Add(int item)
        {
            if (this.currentIndex == ArrayCapacity)
            {
                throw new InvalidOperationException("Database is full");
            }

            this.databaseItems[currentIndex] = item;
            currentIndex++;
        }

        public void Remove()
        {
            if (this.currentIndex == 0)
            {
                throw new InvalidOperationException("Database is empty");
            }

            currentIndex--;
            this.databaseItems[currentIndex] = 0;
        }

        public int[] Fetch()
        {
            List<int> fetchedItems = new List<int>();

            foreach (var item in this.databaseItems.Where(item => item != 0))
            {
                fetchedItems.Add(item);
            }

            return fetchedItems.ToArray();
        }
    }
}
