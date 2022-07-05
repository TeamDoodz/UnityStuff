using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public static class CollectionsUtil {
	public static T GetRandom<T>(this List<T> list) {
		if(list.Count == 0) throw new ArgumentException("List cannot be empty.", nameof(list));
		return list[UnityEngine.Random.Range(0, list.Count)];
	}

	public static List<T> Cycle<T>(this List<T> self, out T cycled) {
		if(self.Count == 0) throw new ArgumentException("List cannot be empty.", nameof(self));

		List<T> outp = new List<T>(self);
		if(self.Count == 1) { 
			cycled = outp[0];
			return outp;
		}

		T current = outp[0];
		outp.Remove(current);
		outp.Add(current);

		cycled = current;
		return outp;
	}
	/// <summary>
	/// Shuffles the specified list using the modernized Fisher-Yates shuffle algorithm.
	/// </summary>
	/// <typeparam name="T">The type of list provided.</typeparam>
	/// <param name="self">The list provided.</param>
	public static List<T> Shuffle<T>(this List<T> self) {
		List<T> outp = new List<T>(self);

		// For a list a of n elements
		for(int i = 0; i <= (self.Count - 2); i++) {
			int j = UnityEngine.Random.Range(i, self.Count); // A random integer such that i <= j < n
			outp.Swap(i, j);
		}

		return outp;
	}
	/// <summary>
	/// Swaps elements A and B in a list.
	/// </summary>
	/// <typeparam name="T">The type of list provided.</typeparam>
	/// <param name="self">The list provided.</param>
	/// <param name="A">The index of entry A.</param>
	/// <param name="B">The index of entry B.</param>
	public static void Swap<T>(this List<T> self, int A, int B) {
		T valA = self[A];
		T valB = self[B];
		self[A] = valB;
		self[B] = valA;
	}

	public static string PrettyPrint<T>(this IEnumerable<T> self, char seperator = '\n') {
		StringBuilder sb = new StringBuilder();
		foreach(var i in self) {
			sb.Append($"{i}{seperator}");
		}
		return sb.ToString();
	}
}
