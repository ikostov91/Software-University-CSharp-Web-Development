using System;
using System.Collections.Generic;
using System.Text;

namespace ListIterator
{
    public class ListIterator
    {
        private IList<string> stringsList;
        private int currentIndex;

        public ListIterator(params string[] input)
        {
            if (input == null)
            {
                throw new ArgumentNullException("Input cannot be null");
            }

            this.stringsList = input;
            this.currentIndex = 0;
        }

        public bool Move()
        {
            if (this.currentIndex == (this.stringsList.Count - 1) || this.stringsList.Count == 0)
            {
                return false;
            }
            else
            {
                this.currentIndex++;
                return true;
            }   
        }

        public bool HasNext()
        {
            if (!(this.currentIndex < (this.stringsList.Count - 1)) || this.stringsList.Count == 0)
            {
                return false; 
            }
            else
            {
                return true;
            }
        }

        public string Print()
        {
            if (this.stringsList.Count == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }

            return $"{this.stringsList[currentIndex]}";
        }
    }
}
