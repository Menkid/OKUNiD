using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LetsGoScript : MonoBehaviour {
	public Canvas introCanvas;
	public Button LetsGO;
	
	
	// Use this for initialization
	void Start () {
		introCanvas = introCanvas.GetComponent<Canvas> ();
		LetsGO = LetsGO.GetComponent<Button> ();

	}
	public void OnLetsGo(){
		Application.LoadLevel (3);
	}
}
