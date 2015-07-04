using UnityEngine;
using System.Collections;

public class SalmonStat : MonoBehaviour {
	public GameObject salmon;
    private Health myHealth;
	// Use this for initialization
	void Start () {
		salmon = GameObject.Find ("Salmon");
	    myHealth = salmon.GetComponent<Health>();
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnGUI(){
	    if (myHealth == null)
	    {
	        return;
	    }
        GUI.Box(new Rect(0, 0, 300, 20), "Lives : " + myHealth.Lives + " HP : " + myHealth.hp);
	}
}
