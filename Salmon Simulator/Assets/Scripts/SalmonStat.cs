using UnityEngine;
using System.Collections;

public class SalmonStat : MonoBehaviour {
	public GameObject salmon;
	public int Lives;
    private Health myHealth;
	// Use this for initialization
	void Start () {
		salmon = GameObject.Find ("Salmon");
	    myHealth = salmon.GetComponent<Health>();

		Lives = salmon.GetComponent<SalmonController> ().Lives;
	}
	
	// Update is called once per frame
	void Update () {
		Lives = salmon.GetComponent<SalmonController> ().Lives;
	}

	void OnGUI(){
		GUI.Box (new Rect (0, 0, 200, 20), "Lives : " + Lives);
	    if (myHealth == null)
	    {
	        return;
	    }
        GUI.Box(new Rect(200, 0, 200, 20), "Lives : " + myHealth.Lives);
	}
}
