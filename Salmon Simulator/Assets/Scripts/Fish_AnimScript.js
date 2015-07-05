#pragma strict

var eyeTimer : float = 3f;
var blinkTimer : float = 0.2f;
var randomFactor : float = 7f;
var SalmonEyesClosed : String = "Salmon_eyes_closed";
var SalmonMouthOpen : String = "Salmon_mouth_open";
var SalmonMouthClosed : String = "Salmon_mouth_closed";

private var currTime : float;
private var blinking : boolean;

private var FishEyes : GameObject = null;
private var MouthOpen    : GameObject = null;
private var MouthClosed : GameObject = null;

function Start () {
	// Get variables
	FishEyes    = GameObject.Find(SalmonEyesClosed);
	MouthOpen   = GameObject.Find(SalmonMouthOpen);
	MouthClosed = GameObject.Find(SalmonMouthClosed);
	
	// Hide eyelids and open-mouth (looks like lipstick btw)
	FishEyes.GetComponent.<Renderer>().enabled = false;
	MouthOpen.GetComponent.<Renderer>().enabled = false;

	// Init Eyes Timer
	currTime = eyeTimer + Random.value * randomFactor;
	blinking = false;
}

function Update () {
	BlinkEyesCheck();
}

// --------------- //
// Blink functions //
// --------------- //
function BlinkEyesCheck () {
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

function Blink (BlinkDuration : float) {
	CloseEyes();
	currTime = BlinkDuration;
	blinking = true;
}

function CloseEyes () {
	FishEyes.GetComponent.<Renderer>().enabled = true;
}

function OpenEyes () {
	FishEyes.GetComponent.<Renderer>().enabled = false;
}

// --------------- //
// Mouth functions //
// --------------- //
function OpenMouth () {
	MouthClosed.GetComponent.<Renderer>().enabled = false;
	MouthOpen.GetComponent.<Renderer>().enabled = true;
}

function CloseMouth () {
	MouthOpen.GetComponent.<Renderer>().enabled = false;
	MouthClosed.GetComponent.<Renderer>().enabled = true;
}