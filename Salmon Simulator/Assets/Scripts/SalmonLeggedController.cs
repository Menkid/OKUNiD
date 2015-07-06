using UnityEngine;
using System.Collections;

public class SalmonLeggedController : MonoBehaviour {

	public Rigidbody2D rgbdy;
	public float jump1Force = 700f;
	public float jump2Force = 1000f;
	public float maxSpeed = 10f;
	public float groundRadius = 0.2f;

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
		if (rgbdy.position.y < minPositionY && rgbdy.position.x>minPositionX) {
			//respawn 
			rgbdy.position = origin;
		}
		if (grounded && (Input.GetKeyDown (KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.JoystickButton1))) {
			rgbdy.AddForce (new Vector2 (0, jump1Force));
		} else
		if (grounded && (Input.GetKeyDown (KeyCode.Space) || Input.GetKeyDown(KeyCode.JoystickButton0))) {
			rgbdy.AddForce (new Vector2 (0, jump2Force));
		}
	}

}
