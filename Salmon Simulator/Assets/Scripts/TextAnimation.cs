using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Threading;

public class TextAnimation : MonoBehaviour {
	public string TextToWrite = "";
	private string currentTextAppearing = "";
	public Text CanvasText;
	public	int speed;
	private int Position;
	// Use this for initialization
	void Start () {
		CanvasText = GetComponent<Text> ();
		CanvasText.text = TextToWrite;
		Position = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (Position < TextToWrite.Length){
			if(TextToWrite[Position].Equals('\\')){
				currentTextAppearing = currentTextAppearing + '\n';
				Position++;
				Thread.Sleep(1000);
			}else{
			currentTextAppearing = currentTextAppearing + TextToWrite[Position];
			Position++;
			int milliseconds = 1000/speed;
			Thread.Sleep(milliseconds);
			}
		}
		CanvasText.text = currentTextAppearing;
	}
}
