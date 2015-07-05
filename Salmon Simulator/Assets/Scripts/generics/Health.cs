using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour
{

    public int Lives = 1;
    public int hp;
    public int MAX_LIVES = 20;
    public int SPAWN_HP = 10;
    public int MAX_HP = 100;
    public bool isEnemy = true;
    public Transform loot;
    public AudioClip deathSound;

    // Use this for initialization
    void Start()
    {
        hp = SPAWN_HP;
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
            hp = SPAWN_HP;
            if (--Lives <= 0)
            {
                if (deathSound != null)
                {
                    AudioSource.PlayClipAtPoint(deathSound, transform.position, 0.8f);
                }
                if (loot != null)
                {
                    Vector2 pos = GetComponent<Rigidbody2D>().position;
                    Transform myLoot = Instantiate(loot);
                    myLoot.position = pos;
                }
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

    void OnCollisionEnter2D(Collision2D obj)
    {
        Shot shot = obj.gameObject.GetComponent<Shot>();
        if (shot == null) return;
        if (shot.isEnemy == isEnemy) return;
        Damage(shot.damage);
        if (shot.lifeTime == 0)
        {
            return;
        }
        Destroy(shot.gameObject);
    }
}
