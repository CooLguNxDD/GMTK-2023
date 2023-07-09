using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimPlayerFoodSpawner : ObjectSpawnerFromPool
{
    private GameObject playerObject;
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
        Vector3 pos = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        GameObject currentFood = objectPool.SpawnFromPool(spawnObjectTag, pos, Quaternion.identity);

        Vector3 direction = (playerObject.transform.position - transform.position).normalized;
        
        currentFood.GetComponent<FoodScript>().setMoveDirection(direction);
    }

    protected override void Update(){
        spawnerCounter -= Time.deltaTime;
        if(spawnerCounter < 0f){
            SpawnObject();
            spawnerCounter = Random.Range(spawnerCounterMinTime, spawnerCounterMaxTime);
        }
        AimAtTarget(playerObject);
        // transform.LookAt(playerObject.transform);+
    }

    private float AimAtTarget(GameObject target){
        float angle = 0;
        Vector3 relative = transform.InverseTransformPoint(target.transform.position);
        angle = Mathf.Atan2(relative.x, relative.y)*Mathf.Rad2Deg;
        transform.Rotate(0,0, -angle);

        return angle;
    }
}