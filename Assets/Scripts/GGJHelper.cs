using UnityEngine;
using System.Collections;

public static class GGJHelper {

	public static Vector2 Vec3ToVec2(Vector3 vec)
	{
		Vector2 newVec = new Vector2 (vec.x, vec.y);
		return newVec;
	}
}
