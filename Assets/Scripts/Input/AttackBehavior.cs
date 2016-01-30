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

		if (punching)
			hitBox.SetActive(true);
	}
}
