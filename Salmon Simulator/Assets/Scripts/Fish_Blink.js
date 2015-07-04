#pragma strict

var eyeTimer : float = 3f;
var blinkTimer : float = 0.2f;
var randomFactor : float = 7f;
var objectName : String = "Salmon_eyes_closed";

private var currTime : float;
private var blinking : boolean;

function Start () {
	currTime = eyeTimer + Random.value * randomFactor;
	blinking = false;
}

function Update () {
	if(currTime > 0.0f) {
		currTime -= Time.deltaTime;
	} else {
		if(blinking) {
			GameObject.Find(objectName).GetComponent.<Renderer>().enabled = false;
			currTime = eyeTimer + Random.value * randomFactor;
			blinking = false;
		} else {
			GameObject.Find(objectName).GetComponent.<Renderer>().enabled = true;
			currTime = blinkTimer;
			blinking = true;
		}
	}
}