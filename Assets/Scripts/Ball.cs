using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{

    private Rigidbody2D rigidBody2D;
    public float speed;
    public float speedboost;
    public float boostDuration;
    Vector3 movement;
    int floorMask;

    float camRayLength = 100f;

    [SerializeField]
    private bool isProblem3;
    [SerializeField]
    private bool isProblem4;
    [SerializeField]
    private bool isProblem5;
    [SerializeField]
    private bool isProblem9;

    [SerializeField]
    private Text boostText;

    private TrailRenderer trail;
    private float initSpeed;

    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        if (isProblem3)
        {
            PushBall();
        }

        if (isProblem9)
        {
            trail = gameObject.GetComponent<TrailRenderer>();
            initSpeed = speed;
        }

    }

    void Update()
    {
        if (isProblem9)
        {
            if (boostDuration >= 0)
            {
                speed = speedboost;
                //tampilkan ui durasi nya
                boostText.text = boostDuration.ToString("F2");
                trail.startColor = Color.cyan;
                boostDuration -= Time.deltaTime;
            }
            else
            {
                boostText.text = "";
                trail.startColor = Color.red;
                speed = initSpeed;
            }
        }
    }

    private void FixedUpdate()
    {
        //Mendapatkan nilai input horizontal (-1,0,1)
        float h = Input.GetAxisRaw("Horizontal");

        //Mendapatkan nilai input vertical (-1,0,1)
        float v = Input.GetAxisRaw("Vertical");

        if (isProblem4)
        {
            Move(h, v);
        }

        if (isProblem5)
        {
            MouseMove();
        }


    }

    public void switchMode()
    {
        isProblem5 = !isProblem5;
        isProblem4 = !isProblem4;
    }

    public void Boost(float _duration)
    {
        boostDuration += _duration;
    }

    public void Move(float h, float v)
    {
        //Set nilai x dan y
        movement.Set(h, v, 0f);

        //Menormalisasi nilai vector agar total panjang dari vector adalah 1
        movement = movement.normalized * speed * Time.deltaTime;

        //Move to position
        rigidBody2D.MovePosition(transform.position + movement);
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


    private void PushBall()
    {
        var xForce = Random.Range(-1f, 1f);
        var yForce = Random.Range(-1f, 1f);
        var force = new Vector2(xForce, yForce);
        //push bola random dengan speed konstan
        rigidBody2D.velocity = force.normalized * speed;
    }
}
