using UnityEngine;
using System.Collections;

public class PlanctonPoint : MonoBehaviour {
	public int points = 1;
    public int mutation = 0;
	public int lifeTime = 0;
	public bool isEnemy = false;
	public bool isLoot = false;
	public int levelToLoadOnDeath = -1;
	
	// Use this for initialization
	void Start()
	{

	}

	void Update(){
		if (lifeTime == 0) {
			return;
		}
		Destroy (gameObject, lifeTime);
	}

    void OnDestroy()
    {
	}
}
