﻿using UnityEngine;
using System.Collections;

public class SalmonController : MonoBehaviour {

	private Rigidbody2D body;
	public float speed;
	private bool faceRight = true;
	public float frictionCoeff;
	// Use this for initialization
	void Start () {
		body = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
	
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
