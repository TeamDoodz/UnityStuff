using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptableObjectLoader<T> where T : Object {
	public static List<T> AllData {
		get {
			LoadData("");
			return allData;
		}
	}

	public static void LoadData(string subDirectoryPath = "") {
		if(allData == null) {
			string path = GetPath() + subDirectoryPath;
			allData = new List<T>(Resources.LoadAll<T>(path));
		}
	}

	public static string GetPath() {
		return "Data/" + typeof(T).FullName.Replace('.', '/') + "/";
	}

	private static List<T> allData;
}
