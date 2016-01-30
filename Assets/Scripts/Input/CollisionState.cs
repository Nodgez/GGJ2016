using UnityEngine;
using System.Collections;

public class CollisionState : MonoBehaviour {

	public LayerMask collisionLayer;
	public bool standing;
	public bool onWall;
	public Vector2 bottomPos = Vector2.zero;
	public Vector2 leftPos = Vector2.zero;
	public Vector2 rightPos = Vector2.zero;
	public float collisionRadius = 10;
	public Color debugColor = Color.red;

	private InputState inputState;

	void Awake()
	{
		inputState = GetComponent<InputState> ();
	}

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate()
	{
		Vector2 pos = bottomPos;

		pos.x += transform.position.x;
		pos.y += transform.position.y;

		standing = Physics2D.OverlapCircle (pos, collisionRadius, collisionLayer);

		pos = inputState.direction == Direction.right ? rightPos : leftPos;

		pos.x += transform.position.x;
		pos.y += transform.position.y;

		onWall = Physics2D.OverlapCircle (pos, collisionRadius, collisionLayer);
	}

	void OnDrawGizmos()
	{
		Gizmos.color = debugColor;

		Vector2[] positions = new Vector2[]{ rightPos, leftPos, bottomPos};
		foreach (Vector2 position in positions) {
			Vector2 pos = position;

			pos.x += transform.position.x;
			pos.y += transform.position.y;

			Gizmos.DrawWireSphere (pos, collisionRadius);
		}
	}
}
