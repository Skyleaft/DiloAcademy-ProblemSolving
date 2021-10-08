using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldController : MonoBehaviour
{
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
            Destroy(gameObject);
        }
    }
}
