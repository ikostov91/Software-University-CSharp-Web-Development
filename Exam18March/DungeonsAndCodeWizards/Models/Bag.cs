using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace DungeonsAndCodeWizards
{
    public abstract class Bag
    {
        private int capacity;
        //private int load;
        private List<Item> items;

        protected Bag(int capacity)
        {
            this.Capacity = capacity;
            items = new List<Item>();
        }

        public int Capacity
        {
            get { return this.capacity; }
            private set { this.capacity = value; }
        }

        public int Load => this.items.Select(x => x.Weight).Sum();

        public List<Item> Items
        {
            get { return this.items; }
        }

        public void AddItem(Item item)
        {
            if (this.Load + item.Weight > this.Capacity)
            {
                throw new InvalidOperationException(ErrorMessages.FullBag);
            }
            else
            {
                this.items.Add(item);    
            }
        }

        public Item GetItem(string name)
        {
            if (this.items.Count == 0)
            {
                throw new InvalidOperationException(ErrorMessages.EmptyBag);
            }
            else if (!this.items.Any(x => x.GetType().Name == name))
            {
                //throw new ArgumentException($"No item with name {name} in bag!");
                throw new ArgumentException(string.Format(ErrorMessages.ItemNotInBag, name));
            }
            else
            {
                Item item = this.items.FirstOrDefault(x => x.GetType().Name == name);
                this.items.Remove(item);
                return item;
            }
        }
    }
}
