using UnityEngine;
using System.Collections;

public class WindowReposition : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 screenPos = Camera.main.WorldToScreenPoint (transform.position);
		if (screenPos.x > Screen.width + 32) {
			transform.position = new Vector3 (Camera.main.ScreenToWorldPoint (Vector3.zero).x, transform.position.y, 0);
		} else if (screenPos.x < -32) {
			transform.position = new Vector3 (Camera.main.ScreenToWorldPoint (new Vector3(Screen.width,0,0)).x, transform.position.y, 0);
		}
	
	}
}
