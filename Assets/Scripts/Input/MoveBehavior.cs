using UnityEngine;
using System.Collections;

public class MoveBehavior : AbstractBehavior {

	public float movePower = 100;
	public float speedLimit = 1000;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		bool movingRight = false;
		inputState.GetButtonValue (Buttons.Right, out movingRight);

		bool movingLeft = false;
		inputState.GetButtonValue (Buttons.Left, out movingLeft);

		if (movingRight && inputState.direction == Direction.left) {
			body2D.AddForce (new Vector3 (1, 0, 0) * movePower * Time.deltaTime * 0.75f);
			if(body2D.velocity.sqrMagnitude >= speedLimit * 0.75f)
				body2D.AddForce (new Vector3 (-1, 0, 0) * movePower * Time.deltaTime * 0.75f);
			//transform.position += new Vector3 (1, 0, 0) * movePower * Time.deltaTime * 0.5f;
			return;
		} else if (movingLeft && inputState.direction == Direction.right) {
			body2D.AddForce (new Vector3 (-1, 0, 0) * movePower * Time.deltaTime * 0.75f);
			if(body2D.velocity.sqrMagnitude >= speedLimit * 0.75f)
				body2D.AddForce (new Vector3 (1, 0, 0) * movePower * Time.deltaTime * 0.75f);
			//transform.position += new Vector3 (-1, 0, 0) * movePower * Time.deltaTime * 0.5f;
			return;
		} else if(movingLeft || movingRight) {
			if (body2D.velocity.sqrMagnitude >= speedLimit)
 				return;
			body2D.AddForce(new Vector3((float)inputState.direction, 0, 0) * movePower * Time.deltaTime);
			//transform.position += new Vector3 ((float)inputState.direction, 0, 0) * movePower * Time.deltaTime;
		}
	}
		
}
