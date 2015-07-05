using UnityEngine;
using System.Collections;

public class IntroScript : MonoBehaviour {
	public int introDuration = 200;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(introDuration == 0){
			Application.LoadLevel(1);
		}else{
			introDuration = introDuration-1;
		}
	}
}
