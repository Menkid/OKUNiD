using UnityEngine;
using System.Collections;

public class FloatingPlancton : MonoBehaviour {

	public float speed = 0.5f;
	private Vector2 origin;
	private Rigidbody2D body;
	// Use this for initialization
	void Start () {
		body = GetComponent<Rigidbody2D> ();
		origin = new Vector2 (body.position.x, body.position.y);

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		body.position = new Vector2 (origin.x, origin.y+speed*Mathf.Cos(Time.time));
	}
}
