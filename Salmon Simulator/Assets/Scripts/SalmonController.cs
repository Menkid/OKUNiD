using UnityEngine;
using System.Collections;

public class SalmonController : MonoBehaviour {

	private Rigidbody2D body;
	public float speed;
	private bool faceRight = true;
	public float frictionCoeff;
	public int Lives;
	// Use this for initialization
	void Start () {
		Lives = 3;
		body = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		//lives
		if (body.velocity.x > 3) {
			Lives = Lives+1;
		}


		//rotations
		Quaternion rotationFixed = new Quaternion (0, 0, 0,0);
		body.transform.rotation = rotationFixed;
	}

	void FixedUpdate(){
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		if (moveHorizontal < 0 && faceRight) {
			Flip ();
		}
		if (moveHorizontal > 0 && !faceRight) {
			Flip ();
		}
		float frictionX = frictionCoeff * body.velocity.x;
		float frictionY = frictionCoeff * body.velocity.y;


		Vector2 force = new Vector2 (moveHorizontal-frictionX, moveVertical-frictionY);
		body.AddForce(force*speed);
	}

	void Flip(){
		transform.localScale = new Vector3(transform.localScale.x *-1, transform.localScale.y, transform.localScale.z);
		faceRight = !faceRight;
	}
}
