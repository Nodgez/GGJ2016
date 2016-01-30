using UnityEngine;
using System.Collections;

public class JumpBehavior : AbstractBehavior {

	public float jumpPower = 200;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		Vector2 pos = GGJHelper.Vec3ToVec2 (transform.position);
		RaycastHit2D hit = Physics2D.Raycast (pos, Vector2.down, 0.75f, 1 << 8);

		if (hit.collider == null) {
			ToggleScripts (false);
			return;
		} else
			ToggleScripts (true);

		bool jumping = false;
		inputState.GetButtonValue (Buttons.SpaceBar, out jumping);

		if (jumping) {
			body2D.AddForce (Vector3.up * jumpPower);
		}
	}
}
