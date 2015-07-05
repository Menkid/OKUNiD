using UnityEngine;
using System.Collections;

public class SalmonLeggedController : MonoBehaviour {

	public Rigidbody2D rgbdy;
	public float jumpForce = 1000f;
	public float maxSpeed = 10f;
	public float groundRadius = 0.2f;
	bool facingRight = true;

	Animator anim;

	public Transform groundCheck;
	bool grounded = false;
	public LayerMask whatIsGround;
	
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per physics call
	void FixedUpdate () {
		grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);

		float move = Input.GetAxis ("Horizontal");
		anim.SetFloat ("Speed", Mathf.Abs (move));

		rgbdy.velocity = new Vector2 (move * maxSpeed, rgbdy.velocity.y);

		if (move > 0 && !facingRight)
			Flip ();
		else if (move < 0 && facingRight)
			Flip ();
	}

	void Update () {
		if (grounded && Input.GetKeyDown (KeyCode.Space)) {
			rgbdy.AddForce (new Vector2 (0, jumpForce));
		}
	}

	void Flip () {
		return;
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

}
