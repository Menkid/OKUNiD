using System;
using UnityEngine;
using System.Collections;
using System.ComponentModel;
using UnityEditor;

public class Boss : MonoBehaviour
{
    public int shootInterval = 1;
    private int timeRed;
    private Move movement;
    public bool faceRight = false;
    private bool oldActive = false;
    private bool firstActive = false;
    public Transform player;
    private Weapon weapon;
    public int activationRadius = 200;
    public AudioClip theme;
    public AudioClip levelTheme;
    private AudioSource music;

	// Use this for initialization
	void Start ()
    {
        weapon = GetComponent<Weapon>();
	    movement = GetComponent<Move>();
	    music = GetComponent<AudioSource>();
	    if (music != null && levelTheme != null)
	    {
	        music.clip = levelTheme;
	        music.Play();
	    }
    }

    void OnDestroy()
    {
        music.Stop();
    }
	
	// Update is called once per frame
	void Update () {
	    if (movement == null)
	    {
	        return;
	    }
        movement.direction = new Vector2((float) Math.Sin(Time.time),(float) Math.Cos(Time.time));
	}


    void FixedUpdate()
    {
        float delta = player.position.x - transform.position.x;
        if (delta * delta > activationRadius * activationRadius)
        {
            return;
        }
        firstActive = true;
        if (firstActive && !oldActive)
        {
            music.Stop();
            music.clip = theme;
            music.Play();
        }
        oldActive = true;
        if (--timeRed <= 0 && UnityEngine.Random.Range(0, 100) < 10)
        {
            timeRed = shootInterval;
            if (weapon != null)
            {
                weapon.Attack(true); // WE ARE an enemy
            }
        }
        if (delta < 0 && faceRight)
        {
            Flip();
        }
        else if (delta > 0 && !faceRight)
        {
            Flip();
        }
    }

    private void Flip()
    {
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        faceRight = !faceRight;
        if (weapon != null)
        {
            weapon.shootRight = faceRight;
            if (weapon.shotPrefab != null)
            {
                weapon.shotPrefab.localScale = new Vector3(-weapon.shotPrefab.localScale.x, weapon.shotPrefab.localScale.y, weapon.shotPrefab.localScale.z);
            }
        }
    }
}
