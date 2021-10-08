using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    private Rigidbody2D rigidBody2D;
    public float speed;

    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        PushBall();
    }


    private void PushBall()
    {
        var xForce = Random.Range(-1f, 1f);
        var yForce = Random.Range(-1f, 1f);
        var force = new Vector2(xForce, yForce);
        //push bola random dengan speed konstan
        rigidBody2D.velocity = force.normalized * speed;
    }
}
