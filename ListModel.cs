using System;
using System.Collections.Generic;

namespace TodoApplication
{
    public class ListModel<TItem>
    {
        public List<TItem> Items { get; }
        public int Limit;
        private LimitedSizeStack<TItem> _historyItems;
        private LimitedSizeStack<int> _historyIndex;
        private LimitedSizeStack<char> _historyOperations;

        public ListModel(int limit)
        {
            Items = new List<TItem>();
            Limit = limit;
            _historyItems = new LimitedSizeStack<TItem>(limit);
            _historyIndex = new LimitedSizeStack<int>(limit);
            _historyOperations = new LimitedSizeStack<char>(limit);
        }

        public void AddItem(TItem item)
        {
            Items.Add(item);
            _historyOperations.Push('+');
            _historyItems.Push(item);
            _historyIndex.Push(0);
        }

        public void RemoveItem(int index)
        {
            _historyOperations.Push('-');
            _historyItems.Push(Items[index]);
            _historyIndex.Push(index);
            Items.RemoveAt(index);            
        }

        public bool CanUndo()
        {
            if (_historyIndex.Count == 0) return false;
            else return true;
        }

        public void Undo()
        {
            if (CanUndo())
            {
                var operation = _historyOperations.Pop();
                var item = _historyItems.Pop();
                var index = _historyIndex.Pop();
                if (operation == '+')
                {
                    Items.RemoveAt(index);
                }
                if (operation == '-')
                {
                    Items.Insert(index, item);
                }
            }
            
            else throw new NotImplementedException();
        }
    }
           
}
