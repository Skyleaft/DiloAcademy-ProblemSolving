using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    #region Singleton

    private static Spawner _instance = null;
    public static Spawner Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<Spawner>();
                if (_instance == null)
                {
                    Debug.LogError("Fatal Error: Spawner not Found");
                }
            }
            return _instance;
        }
    }
    #endregion

    [SerializeField] private float locationX;
    [SerializeField] private float locationY;
    [SerializeField] private float locationMinX;
    [SerializeField] private float locationMinY;
    [SerializeField] private float MinspawnDelay=0.5f;
    [SerializeField] private float MaxspawnDelay=3;
    [SerializeField] private GameObject ItemSpawn;
    [SerializeField] private int maxItem;
    public Ball player;
    public float ballArea;
    [SerializeField] private bool isProblem9;

    private float randomSpawnTime;

    float timer;

    void Start()
    {
        if (GameManager.Instance.isProblem8)
        {
            SpawnItem();
        }
        if (isProblem9)
        {
            SpawnItem();
        }
    }


    void Update()
    {
        timer += Time.deltaTime;
        //randomSpawn time
        randomSpawnTime = Random.RandomRange(MinspawnDelay, MaxspawnDelay);
        if (timer >= randomSpawnTime)
        {
            if (!GameManager.Instance.isProblem8)
            {
                SpawnItem();
            }
        }
    }

    //spawn item random size
    private void SpawnItem()
    {
        timer = 0f;
        //random spawn position
        var obj = Instantiate(ItemSpawn, positionInRange(), this.transform.rotation, this.gameObject.transform);
        //random scale
        if (!isProblem9)
        {
            obj.transform.localScale = new Vector3(Random.Range(1f, 3f), Random.Range(1f, 3f), 1);
        }

    }

    public void SpawnItemAfter(Vector2 randPos,float delay)
    {
        StartCoroutine(spawnDelay(randPos,delay));
    }
    IEnumerator spawnDelay(Vector2 randPos,float delay)
    {
        yield return new WaitForSeconds(delay);
        //setelah delay spawn object baru
        var obj = Instantiate(ItemSpawn, randPos, this.transform.rotation, this.gameObject.transform);
        obj.transform.localScale = new Vector3(Random.Range(1f, 3f), Random.Range(1f, 3f), 1);
    }

    public Vector2 positionInRange()
    {
        var playerPositionX = player.transform.position.x;
        var playerPositionY = player.transform.position.y;
        Vector2 pos;
        do
        {
            var xPosition = Random.Range(locationMinX, locationX);
            var yPosition = Random.Range(locationMinY, locationY);
            pos = new Vector2(xPosition, yPosition);
        } while (pos.x >= -ballArea + playerPositionX && pos.x <= ballArea + playerPositionX
            && pos.y >= -ballArea + playerPositionY && pos.y <= ballArea + playerPositionY);

        return pos;
    }

}
