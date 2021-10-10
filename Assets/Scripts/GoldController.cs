using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldController : MonoBehaviour
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
        if (collision.gameObject.tag=="Player")
        {
            GameManager.Instance.setScore();
            //jika ini problem 8 maka spawn lagi object nya setelah 3detik
            if (GameManager.Instance.isProblem8)
            {
                Vector2 randPos = Spawner.Instance.positionInRange();
                Spawner.Instance.SpawnItemAfter(randPos, 3f);
            }
            if (GameManager.Instance.isProblem9)
            {
                var playeraudio = collision.gameObject.GetComponent<AudioSource>();
                playeraudio.clip = sfx;
                playeraudio.Play();
            }

            Destroy(gameObject);
        }
    }

    private void PushBall()
    {
        var xForce = Random.Range(-1f, 1f);
        var yForce = Random.Range(-1f, 1f);
        var force = new Vector2(xForce, yForce);
        //push bola random dengan speed konstan
        rigidBody2D.velocity = force.normalized * Random.RandomRange(0.5f,4f);
    }
}
