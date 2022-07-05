using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using DoomlikeGame;
using UnityEngine;

namespace RichText {
	/// <summary>
	/// Transpiles a custom formatting language to TMPro Rich Text.
	/// </summary>
	public static class RichTextTranspiler {
		public const string TAG_BOLD = "[b";
		public const string TAG_ITALIC = "[i";
		public const string TAG_COLOR = "[c";

		public const string TAG_END_BOLD = "[/b";
		public const string TAG_END_ITALIC = "[/i";
		public const string TAG_END_COLOR = "[/c";

		public const string TAG_FORMAT = "[v";

		public static string Transpile(string text, params string[] formatting) {
			string outp = text;

			string newVal = "";
			for(int i = 0; i < text.Length; i++) {
				string code = GetTagCode(text, i);
				if(string.IsNullOrEmpty(code)) continue;


				if(code.StartsWith(TAG_BOLD)) {
					newVal = "<b>";
				} else if(code.StartsWith(TAG_END_BOLD)) {
					newVal = "</b>";
				} else if(code.StartsWith(TAG_ITALIC)) {
					newVal = "<i>";
				} else if(code.StartsWith(TAG_END_ITALIC)) {
					newVal = "</i>";
				} else if(code.StartsWith(TAG_COLOR)) {
					newVal = "<color=#" + ColorUtility.ToHtmlStringRGBA(GetColorCode(GetStringValue(code, "c"))) + ">";
				} else if(code.StartsWith(TAG_END_COLOR)) {
					newVal = "</color>";
				} else if(code.StartsWith(TAG_FORMAT)) {
					newVal = formatting[int.Parse(GetStringValue(code, "v"))];
				} else {
					newVal = "";
				}

				outp = outp.Replace(code, newVal);
			}

			return outp;
		}

		private static string GetTagCode(string message, int currentIndex) {
			string result = "";
			string text = message.Remove(0, currentIndex);
			if(message.Length > 0 && text[0] == '[') {
				if(text.IndexOf(']') + 1 < text.Length) {
					result = text.Remove(text.IndexOf(']') + 1);
				} else {
					result = text;
				}
			}
			return result;
		}

		private static string GetStringValue(string code, string codeId) {
			string text = code.Replace("[", "").Replace("]", "");
			if(text[0] == codeId[0]) {
				return text.Remove(0, text.IndexOf(":") + 1);
			}
			return "";
		}

		private static Dictionary<int, Color> colorCodes = null;

		public static Color GetColorCode(string code) => GetColorCode(code, Color.magenta);

		public static Color GetColorCode(string code, Color fallback) {
			if(colorCodes == null) {
				colorCodes = new Dictionary<int, Color>();
				foreach(var field in typeof(GameColors).GetFields(BindingFlags.Public | BindingFlags.Instance)) {
					ExposeColorAttribute attribute = field.GetCustomAttribute<ExposeColorAttribute>();
					if(attribute != null) {
						colorCodes.Add(attribute.ID, (Color)field.GetValue(GameColors.Instance));
					}
				}
			}
			if(colorCodes.TryGetValue(code.GetHashCode(), out Color col)) {
				return col;
			} else {
				return fallback;
			}
		}
	}
}