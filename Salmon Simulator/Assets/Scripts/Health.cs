﻿using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour
{

    public int Lives = 1;
    public int hp = 10;
    public int MAX_LIVES = 20;
    public int MAX_HP = 100;
    public bool isEnemy = true;

    // Use this for initialization
    void Start()
    {

    }



    // Update is called once per frame
    void Update()
    {

    }

    public void Damage(int amount)
    {
        hp -= amount;
        if (hp <= 0)
        {
            if (--Lives <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    public void Heal(int amount)
    {
        hp += amount;
        if (MAX_HP == 0)
        {
            return;
        }
        if (hp > MAX_HP)
        {
            hp = MAX_HP;
        }
    }

    public void AddLives(int amount)
    {
        Lives += amount;
        if (MAX_LIVES == 0)
        {
            return;
        }
        if (Lives > MAX_LIVES)
        {
            Lives = MAX_LIVES;
        }
    }

    void OnTriggerEnter2D(Collider2D obj)
    {
        Shot shot = obj.gameObject.GetComponent<Shot>();
        if (shot == null) return;
        if (shot.isEnemy == isEnemy) return;
        Damage(shot.damage);
        Destroy(shot.gameObject);
    }
}
