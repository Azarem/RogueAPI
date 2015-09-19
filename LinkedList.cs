using System;
using System.Collections.Generic;
using System.Linq;

namespace RogueAPI
{
    public class LinkedList<TContainer, TList> : ICollection<TList>
        where TContainer : ILinkContainer<TContainer, TList>
        where TList : ILinkContainer<TList, TContainer>
    {
        internal readonly TContainer container;
        internal readonly HashSet<TList> list;

        public LinkedList(TContainer container)
        {
            if (container == null)
                throw new NullReferenceException("Container cannot be null");

            this.container = container;
            this.list = new HashSet<TList>();
        }

        public void Add(TList item)
        {
            if (item != null)
            {
                item.LinkedList.list.Add(container);
                list.Add(item);
            }
        }

        public void Clear()
        {
            foreach (var i in list)
                i.LinkedList.list.Remove(container);
            list.Clear();
        }

        public bool Contains(TList item) { return item != null && list.Contains(item); }
        public void CopyTo(TList[] array, int arrayIndex) { list.CopyTo(array, arrayIndex); }
        public int Count { get { return list.Count; } }
        public bool IsReadOnly { get { return false; } }
        public bool Remove(TList item) { return item != null && (item.LinkedList.list.Remove(container) | list.Remove(item)); }
        public IEnumerator<TList> GetEnumerator() { return list.GetEnumerator(); }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { return GetEnumerator(); }
    }

    public interface ILinkContainer<TContainer, TLink>
        where TContainer : ILinkContainer<TContainer, TLink>
        where TLink : ILinkContainer<TLink, TContainer>
    {
        LinkedList<TContainer, TLink> LinkedList { get; }
    }
}
