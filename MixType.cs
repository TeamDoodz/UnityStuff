public enum MixType {
	/// <summary>
	/// Get the maximum of the values.
	/// </summary>
	Maximum,
	/// <summary>
	/// Get the minimum of the values.
	/// </summary>
	Minimum,
	/// <summary>
	/// Add the values together.
	/// </summary>
	Additive,
	/// <summary>
	/// Multiply all values together.
	/// </summary>
	Multiplicative,
	/// <summary>
	/// Get the average of all values.
	/// </summary>
	Average,
	/// <summary>
	/// Return the first element.
	/// </summary>
	FirstBias,
	/// <summary>
	/// Return the last element.
	/// </summary>
	LastBias,
}
