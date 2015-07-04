using UnityEngine;
using System.Collections;

public class Shot : MonoBehaviour
{

    public int damage = 1;
    public int lifeTime = 20;
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

    // Update is called once per frame
    void Update()
    {

    }
}