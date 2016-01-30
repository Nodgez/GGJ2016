using UnityEngine;
using System.Collections;

public class CheckHit : MonoBehaviour {

	public LayerMask detectionLayer;
	public GameObject target;
	public float damage;
	public float power;

	void Start () {
	
	}
	
	void OnTriggerEnter2D(Collider2D col)
	{
		Debug.Log ("Hit Persona : " + col.gameObject.name);
		if (col.gameObject == target) {
			HealthScript hs = target.GetComponent<HealthScript> ();
			if (hs)
				hs.ModifyHealth (damage);

			Vector2 p = GGJHelper.Vec3ToVec2 (transform.position);
			Vector2 p1 = GGJHelper.Vec3ToVec2 (col.transform.position);

			col.gameObject.GetComponent<Rigidbody2D> ().AddForce ((p1 - p) * power);
		}
	}
}
