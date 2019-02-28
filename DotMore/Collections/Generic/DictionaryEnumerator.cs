﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace DotMore.Collections.Generic
{
	public class DictionaryEnumerator<TKey, TValue> : IDictionaryEnumerator, IDisposable
	{
		readonly IEnumerator<KeyValuePair<TKey, TValue>> _impl;
		public void Dispose() { _impl.Dispose(); }
		public DictionaryEnumerator(IDictionary<TKey, TValue> value)
		{
			this._impl = value.GetEnumerator();
		}
		public void Reset() { _impl.Reset(); }
		public bool MoveNext() { return _impl.MoveNext(); }
		public DictionaryEntry Entry
		{
			get
			{
				var pair = _impl.Current;
				return new DictionaryEntry(pair.Key, pair.Value);
			}
		}
		public object Key => _impl.Current.Key;
		public object Value => _impl.Current.Value;
		public object Current => Entry;
	}
}
