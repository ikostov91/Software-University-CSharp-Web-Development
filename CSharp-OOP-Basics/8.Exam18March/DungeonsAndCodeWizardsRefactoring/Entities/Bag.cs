using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DungeonsAndCodeWizardsRefactoring.Static_Data;

namespace DungeonsAndCodeWizardsRefactoring.Entities
{
    abstract class Bag
    {
        private const int DefaultCapacity = 100;

        private int capacity;
        private readonly List<Item> items;

        public Bag(int capacity = DefaultCapacity)
        {
            this.Capacity = capacity;
            this.items = new List<Item>();
        }

        public int Capacity { get; set; }

        public int Load => this.items.Sum(i => i.Weight);

        public IReadOnlyCollection<Item> Items
        {
            get { return this.items.AsReadOnly(); }
        }

        public void AddItem(Item item)
        {
            if (this.Load + item.Weight > this.Capacity)
            {
                throw new InvalidOperationException(ErrorMessages.FullBag);
            }

            this.items.Add(item);
        }

        public Item GetItem(string name)
        {
            CheckIfItemExists(name);

            Item item = this.items.FirstOrDefault(x => x.GetType().Name == name);
            this.items.Remove(item);

            return item;
        }

        private void CheckIfItemExists(string name)
        {
            if (!this.items.Any())
            {
                throw new InvalidOperationException(ErrorMessages.EmptyBag);
            }

            bool itemExists = this.items.Any(x => x.GetType().Name == name);
            if (!itemExists)
            {
                throw new ArgumentException(ErrorMessages.NoSuchItemInBag);
            }
        }
    }
}
