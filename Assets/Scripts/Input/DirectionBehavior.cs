using UnityEngine;
using System.Collections;

public class DirectionBehavior : AbstractBehavior {

	public Transform target;

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		bool facingRight = false;
		inputState.GetButtonValue (Buttons.Right,out facingRight);

		bool facingLeft = false;
		inputState.GetButtonValue (Buttons.Left,out facingLeft);

		Vector3 dirToTarget = target.position - transform.position;

		if(facingRight && dirToTarget.x > 0)
			inputState.direction = Direction.right;

		else if(facingLeft && dirToTarget.x < 0)
			inputState.direction = Direction.left;

		transform.localScale = new Vector3 ((float)inputState.direction, 1, 1);
	}
}
