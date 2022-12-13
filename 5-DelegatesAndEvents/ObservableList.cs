namespace DelegatesAndEvents
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    /// <inheritdoc cref="IObservableList{T}" />
    public class ObservableList<TItem> : IObservableList<TItem>
    {
        private IList<TItem> list = new List<TItem>();
        /// <inheritdoc cref="IObservableList{T}.ElementInserted" />
        public event ListChangeCallback<TItem> ElementInserted;

        /// <inheritdoc cref="IObservableList{T}.ElementRemoved" />
        public event ListChangeCallback<TItem> ElementRemoved;

        /// <inheritdoc cref="IObservableList{T}.ElementChanged" />
        public event ListElementChangeCallback<TItem> ElementChanged;

        /// <inheritdoc cref="ICollection{T}.Count" />
        public int Count => list.Count;
        /*{
            get
            {
                throw new NotImplementedException();
            }
        }*/

        /// <inheritdoc cref="ICollection{T}.IsReadOnly" />
        public bool IsReadOnly => list.IsReadOnly;
        /*{
            get
            {
                return true; //TODO
            }
        }*/

        /// <inheritdoc cref="IList{T}.this" />
        public TItem this[int index]
        {
            get => list[index];
            //{ throw new System.NotImplementedException(); }
            set
            {
                ElementChanged.Invoke(this,value,list[index],index);
                list[index]=value;
            }
            //{ throw new System.NotImplementedException(); }
        }

        /// <inheritdoc cref="IEnumerable{T}.GetEnumerator" />
        public IEnumerator<TItem> GetEnumerator()
        {
            return list.GetEnumerator();
            //throw new System.NotImplementedException();
        }

        /// <inheritdoc cref="IEnumerable.GetEnumerator" />
        IEnumerator IEnumerable.GetEnumerator()
        {
            return list.GetEnumerator();
            //return this.GetEnumerator();
        }

        /// <inheritdoc cref="ICollection{T}.Add" />
        public void Add(TItem item)
        {
            list.Add(item);
            if(ElementInserted!=null) ElementInserted.Invoke(this, item, list.IndexOf(item));
            //throw new System.NotImplementedException();
        }

        /// <inheritdoc cref="ICollection{T}.Clear" />
        public void Clear()
        {
            foreach (TItem item in list)
            {
                this.Remove(item);
                //ElementRemoved.Invoke(this,item,myList.IndexOf(item));
                //myList.Remove(item);
            }
            //throw new System.NotImplementedException();
        }

        /// <inheritdoc cref="ICollection{T}.Contains" />
        public bool Contains(TItem item)
        {
            return list.Contains(item);
            //throw new System.NotImplementedException();
        }

        /// <inheritdoc cref="ICollection{T}.CopyTo" />
        public void CopyTo(TItem[] array, int arrayIndex)
        {
            this.Add(array[arrayIndex]);
        }

        /// <inheritdoc cref="ICollection{T}.Remove" />
        public bool Remove(TItem item)
        {
            ElementRemoved.Invoke(this,item,list.IndexOf(item));
            return list.Remove(item);
            //throw new System.NotImplementedException();
        }

        /// <inheritdoc cref="IList{T}.IndexOf" />
        public int IndexOf(TItem item)
        {
            return list.IndexOf(item);
            //throw new System.NotImplementedException();
        }

        /// <inheritdoc cref="IList{T}.RemoveAt" />
        public void Insert(int index, TItem item)
        {
            ElementChanged.Invoke(this,item,list[index],index);
            list[index] = item;
            //throw new System.NotImplementedException();
        }

        /// <inheritdoc cref="IList{T}.RemoveAt" />
        public void RemoveAt(int index)
        {
            ElementRemoved.Invoke(this,list[index],index);
            list.RemoveAt(index);
            //throw new System.NotImplementedException();
        }

        /// <inheritdoc cref="object.Equals(object?)" />
        public override bool Equals(object obj)
        {
            return list.Equals(obj);
            // TODO improve
            //return base.Equals(obj);
        }

        /// <inheritdoc cref="object.GetHashCode" />
        public override int GetHashCode()
        {
            return list.GetHashCode();
            // TODO improve
            //return base.GetHashCode();
        }

        /// <inheritdoc cref="object.ToString" />
        public override string ToString()
        {
            return list.ToString();
            // TODO improve
            //return base.ToString();
        }
    }
}
