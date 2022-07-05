using System;
using System.Collections.Generic;

namespace RichText {
	/// <summary>
	/// Exposes a color to the rich text transpiler.
	/// </summary>
	[AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
	public class ExposeColorAttribute : Attribute {
		public int ID;

		public ExposeColorAttribute(string displayName) {
			this.ID = displayName.GetHashCode();
		}
	}
}