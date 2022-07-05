using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public struct Point {
	public Vector3 Position;
	public Vector3 Normal;

	public Point(Vector3 position, Vector3 normal) {
		Position = position;
		Normal = normal;
	}

	public Point(Vector3 position) {
		Position = position;
		Normal = Vector3.zero;
	}

	public Point(ContactPoint contactPoint) : this(contactPoint.point, contactPoint.normal) { }

	public Point(ParticleCollisionEvent particleCollisionEvent) : this(particleCollisionEvent.intersection, particleCollisionEvent.normal) { }
}
