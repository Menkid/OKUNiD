using UnityEngine;
using System.Collections;

public class PlanctonPoint : MonoBehaviour {
	public int points = 1;
	public int lifeTime = 0;
	public bool isEnemy = false;
	
	// Use this for initialization
	void Start()
	{
		if (lifeTime == 0)
		{
			return;
		}
		Destroy(gameObject, lifeTime);
	}
}
