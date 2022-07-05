using System;
using UnityEngine;

public static class ColorUtil {
	public static Color Transparent(this Color col) {
		col.a = 0f;
		return col;
	}

	public static Color MoveTowards(Color current, Color target, float maxDelta) {
		return Color.Lerp(current, target, maxDelta);
	}

	public static string ColorString(string str, Color c) {
		return "<color=#" + ColorUtility.ToHtmlStringRGBA(c) + ">" + str + "</color>";
	}

	public static string ColorCharacter(char character, Color c) {
		return ColorString(character.ToString(), c);
	}
}
