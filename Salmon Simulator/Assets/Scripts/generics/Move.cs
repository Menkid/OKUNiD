using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour
{

    public float speed = 10;
    public Vector2 direction = new Vector2(0, 0);
    private Vector2 vecSpeed;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        vecSpeed = new Vector2(direction.x, direction.y).normalized * speed;
    }

    void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().velocity = vecSpeed;
    }
}
