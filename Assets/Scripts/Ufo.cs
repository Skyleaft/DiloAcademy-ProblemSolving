using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ufo : MonoBehaviour
{
    private Rigidbody2D rigidBody2D;
    public float speed;
    Vector3 movement;
    int floorMask;

    float camRayLength = 100f;


    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();

    }

    void FixedUpdate()
    {
        MouseMove();
    }

    private void MouseMove()
    {
        if (Input.GetButton("Fire1"))
        {
            //ambil posisi mouse
            movement = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            var force = movement - transform.position;
            force.z = 0;
            //pindah posisi dengan speed konstan
            rigidBody2D.velocity = force.normalized * speed;

        }
    }
}
