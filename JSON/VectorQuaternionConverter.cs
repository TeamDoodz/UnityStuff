using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;
using System.Globalization;

namespace JSON {
	public class VectorQuaternionConverter : JsonConverter {
		private static readonly List<Type> types = new List<Type> { 
			typeof(Vector3),
			typeof(Quaternion),
		};

		public override bool CanConvert(Type objectType) {
			return types.Contains(objectType);
		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) {
			string[] keys = reader.Value.ToString().Split(',');
			float[] nums = keys.Select((x) => {
				return float.Parse(x, NumberStyles.Float);
			}).ToArray();

			if(objectType == typeof(Vector3)) {
				return new Vector3(nums[0], nums[1], nums[2]);
			} else if(objectType == typeof(Quaternion)) {
				return new Quaternion(nums[0], nums[1], nums[2], nums[3]);
			}

			throw new NotImplementedException();
		}

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) {
			string res = "";
			if(value is Vector3) {
				var vec3 = (Vector3)value;
				res = $"{vec3.x},{vec3.y},{vec3.z}";
			} else if(value is Quaternion) {
				var quat = (Quaternion)value;
				res = $"{quat.x},{quat.y},{quat.z},{quat.w}";
			}
			JToken token = JToken.FromObject(res);
			token.WriteTo(writer);
		}

		public override bool CanRead => true;
		public override bool CanWrite => true;

		public VectorQuaternionConverter() { }
	}
}