using UnityEngine;
using System.Collections;

public class JumpBehavior : AbstractBehavior {

	public float jumpPower = 200;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {


		bool jumping = false;
		inputState.GetButtonValue (Buttons.SpaceBar, out jumping);
		float hold = inputState.GetButtonHoldTime (Buttons.SpaceBar);

		if (jumping && collisionState.standing && hold < .1f) {

			Vector2 vel = body2D.velocity;
			body2D.velocity = new Vector2 (vel.x, jumpPower);
		}
	}
}
