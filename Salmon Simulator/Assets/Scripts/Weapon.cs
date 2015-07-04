using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {

    public Transform shotPrefab;
    public float shootingRate = 0.25f;
    public bool shootRight = true;

    private float shootCooldown;

    public bool canAttack
    {
        get { return shootCooldown <= 0; }
    }

    // Use this for initialization
    void Start()
    {
        shootCooldown = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (shootCooldown > 0)
        {
            shootCooldown -= Time.deltaTime;
        }
    }

    public void Attack(bool isEnemy)
    {
        if (canAttack)
        {
            shootCooldown = shootingRate;
            Transform shotTransform = Instantiate(shotPrefab) as Transform;
            if (shotTransform == null)
            {
                return;
            }
            shotTransform.position = transform.position + new Vector3(transform.localScale.x, 0, 0);
            Shot shot = shotTransform.GetComponent<Shot>();
            if (shot != null)
            {
                shot.isEnemy = isEnemy;
            }
            Move move = shotTransform.GetComponent<Move>();
            if (move != null)
            {
                move.direction = shootRight ? new Vector2(1, 0) : new Vector2(-1, 0);
            }
        }
    }
}
