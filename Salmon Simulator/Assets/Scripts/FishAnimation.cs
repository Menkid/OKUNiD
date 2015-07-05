using UnityEngine;
using System.Collections;

public class FishAnimation : MonoBehaviour {

	public float eyeTimer = 3f;
	public float blinkTimer = 0.3f;
	public float mouthOpenTimer = 0.3f;
	public float randomFactor = 9f;

	public string SalmonOpenMouth = "Salmon_mouth_open";
	public string SalmonClosedMouth = "Salmon_mouth_closed";
	public string SalmonEyesClosed = "Salmon_eyes_closed";

	private float currTime;
	private float mCurrTime;
	private bool blinking;
	private bool mouthOpen;

	private GameObject FishEyes = null;
	private GameObject MouthOpen = null;
	private GameObject MouthClosed = null;

	// Use this for initialization
	public void Start () {
		// Get objects
		FishEyes = GameObject.Find (SalmonEyesClosed);
		MouthOpen = GameObject.Find (SalmonOpenMouth);
		MouthClosed = GameObject.Find (SalmonClosedMouth);

		// Hide eyelids and open mouth (looks like lipstick btw)
		FishEyes.GetComponent<Renderer> ().enabled = false;
		MouthOpen.GetComponent<Renderer> ().enabled = false;

		// Initialize blink variables
		currTime = eyeTimer + Random.value * randomFactor;
		blinking = false;

		// Initialize mouth variables
		mCurrTime = 0f;
		mouthOpen = false;

	}
	
	// Update is called once per frame
	public void Update () {
		BlinkEyesCheck ();
		MouthCheck ();
	}

	// --------------- //
	// Blink functions //
	// --------------- //
	public void BlinkEyesCheck () {
		if(currTime > 0.0f) {
			currTime -= Time.deltaTime;
		} else {
			if(blinking) {
				OpenEyes();	
				currTime = eyeTimer + Random.value * randomFactor;
				blinking = false;
			} else {
				Blink(blinkTimer);
			}
		}
	}

	public void Blink (float BlinkDuration) {
		CloseEyes();
		currTime = BlinkDuration;
		blinking = true;
	}
	
	public void CloseEyes () {
		FishEyes.GetComponent<Renderer>().enabled = true;
	}
	
	public void OpenEyes () {
		FishEyes.GetComponent<Renderer>().enabled = false;
	}

	// --------------- //
	// Mouth functions //
	// --------------- //
	public void MouthCheck () {
		if (mouthOpen) {
			mCurrTime -= Time.deltaTime;
			if(mCurrTime < 0.0f) {
				CloseMouth();
				mCurrTime = 0f;
				mouthOpen = false;
			}
		}
	}

	public void OpenMouth () {
		mCurrTime = mouthOpenTimer;
		mouthOpen = true;
		MouthClosed.GetComponent<Renderer>().enabled = false;
		MouthOpen.GetComponent<Renderer>().enabled = true;
	}
	
	public void CloseMouth () {
		MouthOpen.GetComponent<Renderer>().enabled = false;
		MouthClosed.GetComponent<Renderer>().enabled = true;
	}
}
