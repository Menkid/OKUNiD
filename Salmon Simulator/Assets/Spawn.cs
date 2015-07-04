using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour
{

    public Transform EntityPrefab;
    private int timeRed;
    public int timeInterval = 1000;

	// Use this for initialization
	void Start ()
	{
	    timeRed = timeInterval;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	    if (timeRed-- != 0) {return;}
	    if (Random.Range(0, 1) < 0.7)
	    {
	        return;
	    }
	    timeRed = timeInterval;
	    Transform instance = Instantiate(EntityPrefab) as Transform;
	    instance.position = new Vector3(gameObject.GetComponent<Transform>().position.x, Random.Range(-10, 10));
	    instance.GetComponent<Health>().isEnemy = true;
	}
}
