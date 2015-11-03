using System;
using System.Collections.Generic;

namespace RogueAPI
{
    public class ObjectChain<T> : IDisposable
    {
        protected internal ObjectLink<T> _top, _bottom;

        public ObjectLink<T> First { get { return _bottom; } }
        public ObjectLink<T> Last { get { return _top; } }

        public T Value { get { return _top.Value; } }

        public ObjectChain() { }

        public ObjectChain(T value)
        {
            Push(value);
        }

        public virtual ObjectLink<T> Push(T value)
        {
            var link = new ObjectLink<T>(this, value);
            Push(link);
            return link;
        }

        protected virtual void Push(ObjectLink<T> link)
        {
            if (_top != null)
                _top.Push(link);
            else
                _top = _bottom = link;
        }

        public virtual ObjectLink<T> Pop()
        {
            return _top.Pop();
        }

        public void Dispose()
        {
            while (_top != null)
                _top.Dispose();
        }
    }

    public class ObjectLink<T> : IDisposable
    {
        protected ObjectChain<T> _chain;
        protected ObjectLink<T> _prev, _next;

        public T Value { get; set; }

        public ObjectChain<T> Chain { get { return _chain; } }
        public ObjectLink<T> Previous { get { return _prev; } }
        public ObjectLink<T> Next { get { return _next; } }

        internal protected ObjectLink(ObjectChain<T> chain, T value)
        {
            _chain = chain;
            Value = value;
        }

        protected internal virtual void Push(ObjectLink<T> link)
        {
            link._prev = this;
            link._next = _next;

            if (_next != null)
                _next._prev = link;
            else
                _chain._top = link;

            _next = link;
        }

        public ObjectLink<T> Push(T value)
        {
            var link = new ObjectLink<T>(_chain, value);
            Push(link);
            return link;
        }

        public virtual ObjectLink<T> Pop()
        {
            if (_next != null)
                _next._prev = _prev;
            else
                _chain._top = _prev;

            if (_prev != null)
                _prev._next = _next;
            else
                _chain._bottom = _next;

            var prev = _prev;
            _prev = null;
            _next = null;
            _chain = null;
            return prev;
        }

        public void Dispose()
        {
            if (_chain != null)
                Pop();
        }
    }

    public class ObjectChain<TKey, TValue> : ObjectChain<TValue>
    {
        //protected internal ObjectLink<TKey, TValue> _top, _bottom;
        protected internal Dictionary<TKey, ObjectLink<TKey, TValue>> _lookup = new Dictionary<TKey, ObjectLink<TKey, TValue>>();

        public virtual ObjectLink<TKey, TValue> Push(TKey key, TValue value)
        {
            var link = new ObjectLink<TKey, TValue>(this, key, value);
            Push(link);
            return link;
        }

        public ObjectLink<TKey, TValue> this[TKey key]
        {
            get
            {
                ObjectLink<TKey, TValue> link;
                if (_lookup.TryGetValue(key, out link))
                    return link;
                return null;
            }
        }

        //public TValue Value { get { return _top.Value; } }

        //public ObjectChain() { }

        //public ObjectChain(TKey key = default(TKey), TValue value = default(TValue))
        //{
        //    Push(key, value);
        //}

        //public ObjectLink<TKey, TValue> Push(TKey key = default(TKey), TValue value = default(TValue))
        //{
        //    if (_top != null)
        //        return _top.Push(key, value);
        //    _top = _bottom = new ObjectLink<TKey, TValue>(this, key, value);
        //    return _top;
        //}

        //public ObjectLink<TKey, TValue> Pop()
        //{
        //    return _top.Pop();
        //}

        //public void Dispose()
        //{
        //    while (_top != null)
        //        _top.Dispose();
        //}
    }

    public class ObjectLink<TKey, TValue> : ObjectLink<TValue>
    {
        private TKey _key;
        public TKey Key { get; }


        //private ObjectChain<TKey, TValue> _chain;
        //private ObjectLink<TKey, TValue> _prev, _next;

        //public TValue Value { get; set; }

        //public ObjectChain<TKey, TValue> Chain { get { return _chain; } }
        //public ObjectLink<TKey, TValue> Previous { get { return _prev; } }
        //public ObjectLink<TKey, TValue> Next { get { return _next; } }


        internal protected ObjectLink(ObjectChain<TKey, TValue> chain, TKey key, TValue value)
            : base(chain, value)
        {
            _key = key;
            if (!key.Equals(null))
                chain._lookup.Add(key, this);
        }

        public ObjectLink<TKey, TValue> Push(TKey key, TValue value)
        {
            var link = new ObjectLink<TKey, TValue>(_chain as ObjectChain<TKey, TValue>, key, value);
            Push(link);
            return link;
        }

        public override ObjectLink<TValue> Pop()
        {
            if (!_key.Equals(null))
                ((ObjectChain<TKey, TValue>)_chain)._lookup.Remove(_key);

            return base.Pop();
        }

        //public ObjectLink<TKey, TValue> Pop()
        //{
        //    if (_next != null)
        //        _next._prev = _prev;
        //    else
        //        _chain._top = _prev;

        //    if (_prev != null)
        //        _prev._next = _next;
        //    else
        //        _chain._bottom = _next;

        //    var prev = _prev;
        //    _prev = null;
        //    _next = null;
        //    _chain = null;
        //    return prev;
        //}

        //public void Dispose()
        //{
        //    if (_chain != null)
        //        Pop();
        //}
    }


}
