using UnityEngine;
using System.Collections;
using System.Threading;

public class GAMEOVER : MonoBehaviour {
	public int wait;
	// Use this for initialization
	void Start () {
		if (wait <= 0) {
			wait = 10;
		}
		Thread.Sleep(wait*1000);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
