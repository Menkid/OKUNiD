using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour
{
    public Transform loot;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnDestroy()
    {
        Transform myLoot = Instantiate(loot);
        PlanctonPoint info = myLoot.GetComponent<PlanctonPoint>();
        info.points = 100;
        info.lifeTime = 0;
        info.mutation = 1;
    }
}
