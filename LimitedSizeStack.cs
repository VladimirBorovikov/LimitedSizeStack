using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApplication
{
    public class LimitedSizeStack<T>
    {
        public LinkedList<T> Items { get; }
        public int Limit;

        public LimitedSizeStack(int limit)
        {
            Items = new LinkedList<T>();
            Limit = limit;
        }

        public void Push(T item)
        {
            Items.AddFirst(item);
            if (Items.Count > Limit) Items.RemoveLast();
        }

        public T Pop()
        {
            if (Items.Count == 0) throw new InvalidOperationException();
            var result = Items.First();
            Items.RemoveFirst();
            return result;
        }

        public int Count
        {
            get
            {
                return Items.Count;
            }
        }
    }
}
