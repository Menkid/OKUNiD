using System;
using UnityEngine;
using System.Collections;
using System.ComponentModel;
using UnityEngine.UI;

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
	public Canvas canvas;
	public Text text;
	public int TextDuration = 20;

	// Use this for initialization
	void Start ()
    {
		canvas = GetComponent<Canvas> ();
		text = GetComponent<Text> ();
        weapon = GetComponent<Weapon>();
	    movement = GetComponent<Move>();
	    music = GetComponent<AudioSource>();
	    if (music != null && levelTheme != null)
	    {
	        music.enabled = true;
	        music.clip = levelTheme;
	        music.Play();
	        music.volume = 0.6f;
            
	    }
		TextDuration *= 100;
		text.text = "MWAHAHAHA ! This place belongs to me, the whole ocean !" +
			"How dare you swim in my territory ?! You think a poor salmon can defeat Meow Zedong aka Mr. Tsunami ?!" +
			"After Japan surrendered to me in 1945, I decided to put my head onto a cat body !" +
			"I would keep harassing them, even after my death. I hired the best Chinese surgeons to transplant. " +
			"Remember Fukushima ? Why do you think people call me Mr. Tsunami ! I’ll wreck you !";
    }

    void OnDestroy()
    {
        if (music == null)
        {
            return;
        }
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
			if(canvas!=null)canvas.enabled=true;
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
        if (canvas != null)
        {
            if (TextDuration <= 0)
                canvas.enabled = false;
            else
            {
                TextDuration--;
            }
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
