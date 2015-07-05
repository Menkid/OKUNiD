using UnityEngine;
using System.Collections;

public class SalmonStat : MonoBehaviour {
	public GameObject salmon;
    private Health myHealth;
    private SalmonController control;
	// Use this for initialization
	void Start () {
		myHealth = salmon.GetComponent<Health>();
	    control = salmon.GetComponent<SalmonController>();
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnGUI(){
	    if (myHealth == null)
	    {
	        return;
	    }
        GUI.Box(new Rect(0, 0, 300, 20), "Score : " + control.score + " Lives : " + myHealth.Lives + " HP : " + myHealth.hp);
	}
}
