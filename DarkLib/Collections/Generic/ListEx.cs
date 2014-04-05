//-----------------------------------------------------------------------
// <copyright file="ListEx.cs" company="DarkInc">
//     Copyright (c) DarkInc, WiiPlayer2 (Waldemar Tomme). All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
using System;
using System.Collections.ObjectModel;

namespace System.Collections.Generic
{
    /// <summary>
    /// Implementation of a <see cref="System.Collections.Generic.List{T}" /> with overidable methods.
    /// </summary>
    /// <typeparam name="T">Containing type.</typeparam>
    public class ListEx<T> : IList<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ListEx{T}" /> class.
        /// </summary>
        public ListEx()
        {
            this.InternalList = new List<T>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ListEx{T}" /> class.
        /// </summary>
        /// <param name="collection">The collection.</param>
        public ListEx(IEnumerable<T> collection)
        {
            this.InternalList = new List<T>(collection);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ListEx{T}" /> class.
        /// </summary>
        /// <param name="capacity">The capacity.</param>
        public ListEx(int capacity)
        {
            this.InternalList = new List<T>(capacity);
        }

        /// <summary>
        /// Gets the count.
        /// </summary>
        /// <value>The count.</value>
        public virtual int Count
        {
            get { return this.InternalList.Count; }
        }

        /// <summary>
        /// Gets a value indicating whether this instance is read only.
        /// </summary>
        /// <value><c>true</c> if this instance is read only; otherwise, <c>false</c>.</value>
        public virtual bool IsReadOnly
        {
            get { return false; }
        }

        /// <summary>
        /// Gets or sets the internal list.
        /// </summary>
        /// <value>The internal list.</value>
        protected List<T> InternalList { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="T" /> at the specified index.
        /// </summary>
        /// <value>The <see cref="T" />.</value>
        /// <param name="index">The index.</param>
        /// <returns>The value.</returns>
        public virtual T this[int index]
        {
            get
            {
                return this.InternalList[index];
            }

            set
            {
                this.InternalList[index] = value;
            }
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="ListEx{T}" /> to <see cref="List{T}" />.
        /// </summary>
        /// <param name="list">The list.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator List<T>(ListEx<T> list)
        {
            return new List<T>(list);
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="List{T}" /> to <see cref="ListEx{T}" />.
        /// </summary>
        /// <param name="list">The list.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator ListEx<T>(List<T> list)
        {
            return new ListEx<T>(list);
        }

        /// <summary>
        /// Adds the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        public virtual void Add(T item)
        {
            this.InternalList.Add(item);
        }

        /// <summary>
        /// Adds the range.
        /// </summary>
        /// <param name="collection">The collection.</param>
        public virtual void AddRange(IEnumerable<T> collection)
        {
            this.InternalList.AddRange(collection);
        }

        /// <summary>
        /// Converts to read only.
        /// </summary>
        /// <returns>The read only collection.</returns>
        public ReadOnlyCollection<T> AsReadOnly()
        {
            return this.InternalList.AsReadOnly();
        }

        /// <summary>
        /// Binaries the search.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>The index.</returns>
        public int BinarySearch(T item)
        {
            return this.InternalList.BinarySearch(item);
        }

        /// <summary>
        /// Binaries the search.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="comparer">The comparer.</param>
        /// <returns>The index.</returns>
        public int BinarySearch(T item, IComparer<T> comparer)
        {
            return this.InternalList.BinarySearch(item, comparer);
        }

        /// <summary>
        /// Binaries the search.
        /// </summary>
        /// <param name="index">The start index.</param>
        /// <param name="count">The count.</param>
        /// <param name="item">The item.</param>
        /// <param name="comparer">The comparer.</param>
        /// <returns>The index.</returns>
        public int BinarySearch(int index, int count, T item, IComparer<T> comparer)
        {
            return this.InternalList.BinarySearch(index, count, item, comparer);
        }

        /// <summary>
        /// Clears this instance.
        /// </summary>
        public virtual void Clear()
        {
            this.InternalList.Clear();
        }

        /// <summary>
        /// Determines whether [contains] [the specified item].
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>Whether the list contains the item.</returns>
        public virtual bool Contains(T item)
        {
            return this.InternalList.Contains(item);
        }

        /// <summary>
        /// Converts all.
        /// </summary>
        /// <typeparam name="TOutput">The type of the output.</typeparam>
        /// <param name="converter">The converter.</param>
        /// <returns>The converted list.</returns>
        public virtual ListEx<TOutput> ConvertAll<TOutput>(Converter<T, TOutput> converter)
        {
            return this.InternalList.ConvertAll<TOutput>(converter);
        }

        /// <summary>
        /// Copies to.
        /// </summary>
        /// <param name="array">The array.</param>
        public virtual void CopyTo(T[] array)
        {
            this.InternalList.CopyTo(array);
        }

        /// <summary>
        /// Copies to.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <param name="arrayIndex">Index of the array.</param>
        public virtual void CopyTo(T[] array, int arrayIndex)
        {
            this.InternalList.CopyTo(array, arrayIndex);
        }

        /// <summary>
        /// Copies to.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <param name="array">The array.</param>
        /// <param name="arrayIndex">Index of the array.</param>
        /// <param name="count">The count.</param>
        public virtual void CopyTo(int index, T[] array, int arrayIndex, int count)
        {
            this.InternalList.CopyTo(index, array, arrayIndex, count);
        }

        /// <summary>
        /// Checks if the specified match exists.
        /// </summary>
        /// <param name="match">The match.</param>
        /// <returns>Whether items exists.</returns>
        public virtual bool Exists(Predicate<T> match)
        {
            return this.InternalList.Exists(match);
        }

        /// <summary>
        /// Finds the specified match.
        /// </summary>
        /// <param name="match">The match.</param>
        /// <returns>The found item.</returns>
        public virtual T Find(Predicate<T> match)
        {
            return this.InternalList.Find(match);
        }

        /// <summary>
        /// Finds all.
        /// </summary>
        /// <param name="match">The match.</param>
        /// <returns>The found items.</returns>
        public virtual ListEx<T> FindAll(Predicate<T> match)
        {
            return this.InternalList.FindAll(match);
        }

        /// <summary>
        /// Finds the index.
        /// </summary>
        /// <param name="match">The match.</param>
        /// <returns>The index.</returns>
        public virtual int FindIndex(Predicate<T> match)
        {
            return this.InternalList.FindIndex(match);
        }

        /// <summary>
        /// Finds the index.
        /// </summary>
        /// <param name="startIndex">The start index.</param>
        /// <param name="match">The match.</param>
        /// <returns>The index.</returns>
        public virtual int FindIndex(int startIndex, Predicate<T> match)
        {
            return this.InternalList.FindIndex(startIndex, match);
        }

        /// <summary>
        /// Finds the index.
        /// </summary>
        /// <param name="startIndex">The start index.</param>
        /// <param name="count">The count.</param>
        /// <param name="match">The match.</param>
        /// <returns>The index.</returns>
        public virtual int FindIndex(int startIndex, int count, Predicate<T> match)
        {
            return this.InternalList.FindIndex(startIndex, count, match);
        }

        /// <summary>
        /// Finds the last.
        /// </summary>
        /// <param name="match">The match.</param>
        /// <returns>The found item.</returns>
        public virtual T FindLast(Predicate<T> match)
        {
            return this.InternalList.FindLast(match);
        }

        /// <summary>
        /// Finds the last index.
        /// </summary>
        /// <param name="match">The match.</param>
        /// <returns>The index.</returns>
        public virtual int FindLastIndex(Predicate<T> match)
        {
            return this.InternalList.FindLastIndex(match);
        }

        /// <summary>
        /// Finds the last index.
        /// </summary>
        /// <param name="startIndex">The start index.</param>
        /// <param name="match">The match.</param>
        /// <returns>The index.</returns>
        public virtual int FindLastIndex(int startIndex, Predicate<T> match)
        {
            return this.InternalList.FindLastIndex(startIndex, match);
        }

        /// <summary>
        /// Finds the last index.
        /// </summary>
        /// <param name="startIndex">The start index.</param>
        /// <param name="count">The count.</param>
        /// <param name="match">The match.</param>
        /// <returns>The index.</returns>
        public virtual int FindLastIndex(int startIndex, int count, Predicate<T> match)
        {
            return this.InternalList.FindLastIndex(startIndex, count, match);
        }

        /// <summary>
        /// Executes the action for each item.
        /// </summary>
        /// <param name="action">The action.</param>
        public virtual void ForEach(Action<T> action)
        {
            this.InternalList.ForEach(action);
        }

        /// <summary>
        /// Gets the enumerator.
        /// </summary>
        /// <returns>The enumerator.</returns>
        public virtual IEnumerator<T> GetEnumerator()
        {
            return this.InternalList.GetEnumerator();
        }

        /// <summary>
        /// Gets the range.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <param name="count">The count.</param>
        /// <returns>The items within range.</returns>
        public virtual ListEx<T> GetRange(int index, int count)
        {
            return this.InternalList.GetRange(index, count);
        }

        /// <summary>
        /// Gets the enumerator
        /// </summary>
        /// <returns>
        /// An <see cref="T:System.Collections.IEnumerator" /> object which is used to iterate
        /// through the list.
        /// </returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.InternalList.GetEnumerator();
        }

        /// <summary>
        /// Indexes the of.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>The index.</returns>
        public virtual int IndexOf(T item)
        {
            return this.InternalList.IndexOf(item);
        }

        /// <summary>
        /// Indexes the of.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="index">The start index.</param>
        /// <returns>The index.</returns>
        public virtual int IndexOf(T item, int index)
        {
            return this.InternalList.IndexOf(item, index);
        }

        /// <summary>
        /// Indexes the of.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="index">The start index.</param>
        /// <param name="count">The count.</param>
        /// <returns>The index.</returns>
        public virtual int IndexOf(T item, int index, int count)
        {
            return this.InternalList.IndexOf(item, index, count);
        }

        /// <summary>
        /// Inserts the specified index.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <param name="item">The item.</param>
        public virtual void Insert(int index, T item)
        {
            this.InternalList.Insert(index, item);
        }

        /// <summary>
        /// Inserts the range.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <param name="collection">The collection.</param>
        public virtual void InsertRange(int index, IEnumerable<T> collection)
        {
            this.InternalList.InsertRange(index, collection);
        }

        /// <summary>
        /// Lasts the index of.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>The index.</returns>
        public virtual int LastIndexOf(T item)
        {
            return this.InternalList.LastIndexOf(item);
        }

        /// <summary>
        /// Lasts the index of.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="index">The start index.</param>
        /// <returns>The index.</returns>
        public virtual int LastIndexOf(T item, int index)
        {
            return this.InternalList.LastIndexOf(item, index);
        }

        /// <summary>
        /// Lasts the index of.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="index">The start index.</param>
        /// <param name="count">The count.</param>
        /// <returns>The index.</returns>
        public virtual int LastIndexOf(T item, int index, int count)
        {
            return this.InternalList.LastIndexOf(item, index, count);
        }

        /// <summary>
        /// Removes the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>Whether the item was removed.</returns>
        public virtual bool Remove(T item)
        {
            return this.InternalList.Remove(item);
        }

        /// <summary>
        /// Removes all.
        /// </summary>
        /// <param name="match">The match.</param>
        /// <returns>The count of removed items.</returns>
        public virtual int RemoveAll(Predicate<T> match)
        {
            return this.InternalList.RemoveAll(match);
        }

        /// <summary>
        /// Removes at.
        /// </summary>
        /// <param name="index">The index.</param>
        public virtual void RemoveAt(int index)
        {
            this.InternalList.RemoveAt(index);
        }

        /// <summary>
        /// Removes the range.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <param name="count">The count.</param>
        public virtual void RemoveRange(int index, int count)
        {
            this.InternalList.RemoveRange(index, count);
        }

        /// <summary>
        /// Reverses this instance.
        /// </summary>
        public virtual void Reverse()
        {
            this.InternalList.Reverse();
        }

        /// <summary>
        /// Reverses the specified index.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <param name="count">The count.</param>
        public virtual void Reverse(int index, int count)
        {
            this.InternalList.Reverse(index, count);
        }

        /// <summary>
        /// Sorts this instance.
        /// </summary>
        public virtual void Sort()
        {
            this.InternalList.Sort();
        }

        /// <summary>
        /// Sorts the specified comparison.
        /// </summary>
        /// <param name="comparison">The comparison.</param>
        public virtual void Sort(Comparison<T> comparison)
        {
            this.InternalList.Sort(comparison);
        }

        /// <summary>
        /// Sorts the specified comparer.
        /// </summary>
        /// <param name="comparer">The comparer.</param>
        public virtual void Sort(IComparer<T> comparer)
        {
            this.InternalList.Sort(comparer);
        }

        /// <summary>
        /// To the array.
        /// </summary>
        /// <returns>The array.</returns>
        public virtual T[] ToArray()
        {
            return this.InternalList.ToArray();
        }

        /// <summary>
        /// Trims the excess.
        /// </summary>
        public virtual void TrimExcess()
        {
            this.InternalList.TrimExcess();
        }

        /// <summary>
        /// Trues for all.
        /// </summary>
        /// <param name="match">The match.</param>
        /// <returns>Whether it's true for all.</returns>
        public virtual bool TrueForAll(Predicate<T> match)
        {
            return this.InternalList.TrueForAll(match);
        }
    }
}