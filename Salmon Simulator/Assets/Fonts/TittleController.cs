using UnityEngine;
using System.Collections;

public class TittleController : MonoBehaviour {

	// Use this for initialization
	void OnMouseEnter(){
		Rigidbody2D body = GetComponent<Rigidbody2D> ();

		body.transform.localScale.Set (0.2f, 0.2f, 0.2f);
	}

}
