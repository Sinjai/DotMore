using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DotMore.Collections.Generic
{
	/// <summary>
	/// A concrete implementation of the abstract KeyedCollection class using lambdas for the
	/// implementation.
	/// </summary>
	public class KeyedCollection2<TKey, TItem> : KeyedCollection<TKey, TItem>
	{
		private const string DelegateNullExceptionMessage = "Delegate passed cannot be null";
		private readonly Func<TItem, TKey> _getKeyForItemFunction;

		public KeyedCollection2(Func<TItem, TKey> getKeyForItemFunction) : base()
		{
			_getKeyForItemFunction = getKeyForItemFunction ?? throw new ArgumentNullException(DelegateNullExceptionMessage);
		}

		public KeyedCollection2(Func<TItem, TKey> getKeyForItemDelegate, IEqualityComparer<TKey> comparer) : base(comparer)
		{
			_getKeyForItemFunction = getKeyForItemDelegate ?? throw new ArgumentNullException(DelegateNullExceptionMessage);
		}

		protected override TKey GetKeyForItem(TItem item)
		{
			return _getKeyForItemFunction(item);
		}

		public void SortByKeys()
		{
			var comparer = Comparer<TKey>.Default;
			SortByKeys(comparer);
		}

		public void SortByKeys(IComparer<TKey> keyComparer)
		{
			var comparer = new Comparer2<TItem>((x, y) => keyComparer.Compare(GetKeyForItem(x), GetKeyForItem(y)));
			Sort(comparer);
		}

		public void SortByKeys(Comparison<TKey> keyComparison)
		{
			var comparer = new Comparer2<TItem>((x, y) => keyComparison(GetKeyForItem(x), GetKeyForItem(y)));
			Sort(comparer);
		}

		public void Sort()
		{
			var comparer = Comparer<TItem>.Default;
			Sort(comparer);
		}

		public void Sort(Comparison<TItem> comparison)
		{
			var newComparer = new Comparer2<TItem>((x, y) => comparison(x, y));
			Sort(newComparer);
		}

		public void Sort(IComparer<TItem> comparer)
		{
			if (base.Items is List<TItem> list)
			{
				list.Sort(comparer);
			}
		}
	}
}
