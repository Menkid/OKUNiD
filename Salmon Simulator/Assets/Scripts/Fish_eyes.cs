using UnityEngine;
using System.Collections;

public class Fish_eyes : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void MakeVisible() {
		GameObject.FindGameObjectWithTag ("Salmon_eyes_closed").GetComponent<Renderer>().enabled = true;
	}

	public void MakeInvisible() {
		GameObject.FindGameObjectWithTag ("Salmon_eyes_closed").GetComponent<Renderer>().enabled = false;
	}
}
