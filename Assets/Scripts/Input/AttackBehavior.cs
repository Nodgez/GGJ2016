using UnityEngine;
using System.Collections;

public class AttackBehavior : AbstractBehavior {

	public GameObject hitBox;

	void Start () {
		hitBox.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		bool punching = false;
		inputState.GetButtonValue (Buttons.Puch, out punching);
		float punchHold = inputState.GetButtonHoldTime (Buttons.Puch);
		Debug.Log ("Punch Hold : " + punchHold);
		if (punching && punchHold < 0.1f) {
			hitBox.SetActive (true);
		}
	}

	public void ActivateHitBox()
	{
		hitBox.SetActive(true);
	}
}
