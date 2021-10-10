using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NitroBoost : MonoBehaviour
{
    private Rigidbody2D rigidBody2D;
    [SerializeField] private AudioClip sfx;
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        if (GameManager.Instance.isProblem9)
        {
            PushBall();
        }

    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            var player = collision.gameObject.GetComponent<Ball>();
            var playeraudio = collision.gameObject.GetComponent<AudioSource>();
            player.Boost(10f);
            playeraudio.clip = sfx;
            playeraudio.Play();
            Destroy(gameObject);
        }
    }

    private void PushBall()
    {
        var xForce = Random.Range(-1f, 1f);
        var yForce = Random.Range(-1f, 1f);
        var force = new Vector2(xForce, yForce);
        //push bola random dengan speed konstan
        rigidBody2D.velocity = force.normalized * Random.RandomRange(0.2f, 3f);
    }
}
