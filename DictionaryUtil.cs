using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class DictionaryUtil {

	/// <summary>
	/// Removes all elements of a dictionary that match the predicate. <seealso href="https://stackoverflow.com/questions/469202/best-way-to-remove-multiple-items-matching-a-predicate-from-a-net-dictionary"/>
	/// </summary>
	public static void PredicateRemove<TKey,TValue>(this Dictionary<TKey,TValue> dict, Predicate<KeyValuePair<TKey,TValue>> predicate) {
		foreach(var s in dict.Where((a) => predicate.Invoke(a)).ToList()) {
			dict.Remove(s.Key);
		}
	}
	
}
