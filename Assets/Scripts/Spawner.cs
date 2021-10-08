using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float locationX;
    [SerializeField] private float locationY;
    [SerializeField] private float MinspawnDelay=0.5f;
    [SerializeField] private float MaxspawnDelay=3;
    [SerializeField] private GameObject ItemSpawn;

    private float randomSpawnTime;

    float timer;

    void Update()
    {
        timer += Time.deltaTime;
        //randomSpawn time
        randomSpawnTime = Random.RandomRange(MinspawnDelay, MaxspawnDelay);
        if (timer >= randomSpawnTime)
        {
            SpawnItem();
        }
    }

    //spawn item random size
    private void SpawnItem()
    {
        timer = 0f;
        //random spawn position
        var randPos = new Vector3(Random.Range(locationX, -locationX), Random.Range(locationY, -locationY), 0f);
        var obj = Instantiate(ItemSpawn, randPos, this.transform.rotation, this.gameObject.transform);
        //random scale
        obj.transform.localScale = new Vector3(Random.Range(1f, 3f), Random.Range(1f, 3f), 1);
    }

}
