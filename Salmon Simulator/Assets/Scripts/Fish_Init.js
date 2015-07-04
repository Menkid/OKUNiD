#pragma strict

var eyes_closed : String = "Salmon_eyes_closed";
var mouth_open : String = "Salmon_mouth_open";

function Start () {
	GameObject.Find(eyes_closed).GetComponent.<Renderer>().enabled = false;
	GameObject.Find(mouth_open).GetComponent.<Renderer>().enabled = false;
}

function Update () {

}