#pragma strict

var eyeTimer : float;
var blinkTimer : float;
var randomFactor : float;

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
			GameObject.Find("Salmon_eyes_closed").GetComponent.<Renderer>().enabled = false;
			currTime = eyeTimer + Random.value * randomFactor;
			blinking = false;
		} else {
			GameObject.Find("Salmon_eyes_closed").GetComponent.<Renderer>().enabled = true;
			currTime = blinkTimer;
			blinking = true;
		}
	}
}