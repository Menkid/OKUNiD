using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour
{

    public Texture btnTex;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnGUI()
    {
        const int btnWidth = 96;
        const int btnHeight = 64;
        Rect pos = new Rect(Screen.width / 2 - btnWidth / 2, Screen.height / 2 - btnHeight / 2, btnWidth, btnHeight);
        if (btnTex != null)
        {
            if (GUI.Button(pos, btnTex))
            {
                Application.LoadLevel("Niv1");
            }
            return;
        }
        if (GUI.Button(pos, "Start !"))
        {
            Application.LoadLevel("Niv1");
        }
    }
}
