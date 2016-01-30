using UnityEngine;
using System.Collections;

public class Expand : MonoBehaviour {

	public float modifier = 3;

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.localScale *= 1 + Time.deltaTime * modifier;
	}
}
