using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectSpawnerFromPool : MonoBehaviour
{

    [SerializeField]
    protected ObjectPool objectPool;
    [SerializeField]
    protected string spawnObjectTag;
    [SerializeField]
    protected float spawnerCounterMinTime = 5f;
    [SerializeField]
    protected float spawnerCounterMaxTime = 20f;

    private float spawnerCounter = 0f;

    // You can spawn an object assigned to the pool based on the object Tag;
    // You can override SpawnObject() to spawn with custom behavior.

    // Start is called before the first frame update
    void Start()
    {
        if (!objectPool)
        {
            objectPool = GameObject.Find("ObjectPool").GetComponent<ObjectPool>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        spawnerCounter -= Time.deltaTime;
        if(spawnerCounter < 0f){
            SpawnObject();
            spawnerCounter = Random.Range(spawnerCounterMinTime, spawnerCounterMaxTime);
        }
    }

    protected virtual void SpawnObject()
    {
        Vector3 pos = new Vector3(transform.position.x + Random.Range(-2f, 2f), transform.position.y + Random.Range(-2f, 2f), transform.position.z);
        objectPool.SpawnFromPool(spawnObjectTag, pos, Quaternion.identity);
    }
}
