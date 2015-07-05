using System;
using UnityEngine;
using System.Collections;

public class Boss : MonoBehaviour
{
    public Transform loot;
    public int shootInterval = 1;
    private int timeRed;
    private Move movement;

	// Use this for initialization
	void Start ()
	{
	    movement = GetComponent<Move>();
	}
	
	// Update is called once per frame
	void Update () {
	    if (movement == null)
	    {
	        return;
	    }
        movement.direction = new Vector2((float) Math.Sin(Time.time),(float) Math.Cos(Time.time));
	}

    void OnDestroy()
    {
        Vector2 pos = GetComponent<Rigidbody2D>().position;
        Transform myLoot = Instantiate(loot);
        myLoot.position = pos;
    }

    void FixedUpdate()
    {
        if (--timeRed <= 0 && UnityEngine.Random.Range(0, 100) < 10)
        {
            timeRed = shootInterval;
            Weapon weapon = GetComponent<Weapon>();
            if (weapon != null)
            {
                weapon.Attack(true); // WE ARE an enemy
            }
        }
    }
}
