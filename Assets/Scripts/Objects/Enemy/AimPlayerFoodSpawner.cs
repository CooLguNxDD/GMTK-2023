using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimPlayerFoodSpawner : ObjectSpawnerFromPool
{
    private GameObject playerObject;

    [SerializeField] private int multipleShoot = 1;
    [SerializeField]private float splitFactor = 2f;
    protected override void Start(){
        if (!playerObject)
        {
            playerObject = GameObject.Find("Player");
        }
        if (!objectPool)
        {
            objectPool = GameObject.Find("ObjectPool").GetComponent<ObjectPool>();
        }
    }
    protected override void SpawnObject()
    {

        for(int i = -multipleShoot ; i <= multipleShoot; i ++){
            Vector3 pos = new Vector3(transform.position.x, transform.position.y, transform.position.z);

            GameObject currentFood = objectPool.SpawnFromPool(spawnObjectTag, pos, Quaternion.identity);

            Vector3 direction = (playerObject.transform.position - transform.position + new Vector3(i * 2, i * 2,0)).normalized;
        
            currentFood.GetComponent<FoodScript>().setMoveDirection(direction);
        }

    }

    protected override void Update(){
        spawnerCounter -= Time.deltaTime;
        if(spawnerCounter < 0f){
            SpawnObject();
            spawnerCounter = Random.Range(spawnerCounterMinTime, spawnerCounterMaxTime);
        }
        // transform.LookAt(playerObject.transform);+
    }
}
