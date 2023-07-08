using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFoodSpawner : ObjectSpawnerFromPool
{
    protected override void SpawnObject()
    {
        Vector3 pos = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        GameObject currentFood = objectPool.SpawnFromPool(spawnObjectTag, pos, Quaternion.identity);

        currentFood.GetComponent<FoodScript>().setMoveDirection(new Vector2(Random.Range(-1f,1f), Random.Range(-1f,1f)));
    }
}
