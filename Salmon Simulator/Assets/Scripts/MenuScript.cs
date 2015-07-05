using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuScript : MonoBehaviour {

	public Canvas quitMenu;
	public Button play;
	public Button quit;


	// Use this for initialization
	void Start () {
		quitMenu = quitMenu.GetComponent<Canvas> ();
		play = play.GetComponent<Button> ();
		quit = quit.GetComponent<Button> ();
		quitMenu.enabled = false;
	}
	
	public void ExitPress(){
		quitMenu.enabled = true;
		play.enabled = false;
		quit.enabled = false;
	}

	public void NoPress(){
		quitMenu.enabled = false;
		play.enabled = true;
		quit.enabled = true;
	}

	public void StartLevel(){
		Application.LoadLevel(1);
	}

	public void ExitGame(){
		Application.Quit ();
	}
}
