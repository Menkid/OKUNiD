using System;
using UnityEngine;
using System.Collections;

public class Floating : MonoBehaviour
{
    public Move movement;
    public float xFactor = 1;
    public float yFactor = 1;
    public float xSpeed = 1;
    public float ySpeed = 1;

    // Use this for initialization
    void Start()
    {
        movement = GetComponent<Move>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        movement.direction = new Vector2(xFactor * (float)Math.Cos(xSpeed * Time.time), yFactor * (float)Math.Sin(ySpeed * Time.time));
    }
}
