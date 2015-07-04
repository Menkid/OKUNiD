#pragma strict

var eyeTimer : float = 3f;
var blinkTimer : float = 0.2f;
var randomFactor : float = 7f;
var SalmonEyesClosed : String = "Salmon_eyes_closed";
var SalmonMouthOpen : String = "Salmon_mouth_open";

private var currTime : float;
private var blinking : boolean;

private var FishEyes : GameObject = null;
private var Mouth    : GameObject = null;

function Start () {
	// Get variables
	FishEyes = GameObject.Find(SalmonEyesClosed);
	Mouth    = GameObject.Find(SalmonMouthOpen);
	
	// Hide eyelids and open-mouth (looks like lipstick btw)
	FishEyes.GetComponent.<Renderer>().enabled = false;
	Mouth.GetComponent.<Renderer>().enabled = false;

	// Init Eyes Timer
	currTime = eyeTimer + Random.value * randomFactor;
	blinking = false;
}

function Update () {
	BlinkEyesCheck();
}

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