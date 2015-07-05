using UnityEngine;
using System.Collections;

public class SalmonLeggedController : MonoBehaviour {

	public Rigidbody2D rgbdy;
	public float jumpForce = 1000f;
	public float maxSpeed = 10f;
	public float groundRadius = 0.2f;
	bool facingRight = true;
	public int minPositionY = -54;
	public int minPositionX = 134;
	public Vector2 origin;

	Animator anim;

	public Transform groundCheck;
	bool grounded = false;
	public LayerMask whatIsGround;
	
	// Use this for initialization
	void Start () {
		origin = rgbdy.position;
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per physics call
	void FixedUpdate () {

		grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);

		float move = Input.GetAxis ("Horizontal");
		anim.SetFloat ("Speed", Mathf.Abs (move));

		rgbdy.velocity = new Vector2 (move * maxSpeed, rgbdy.velocity.y);
	}

	void Update () {
	
		if (grounded && Input.GetKeyDown (KeyCode.Space)) {
			rgbdy.AddForce (new Vector2 (0, jumpForce));
		}
	}

}
