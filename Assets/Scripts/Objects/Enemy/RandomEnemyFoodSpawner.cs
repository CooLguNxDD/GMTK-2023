using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomEnemyFoodSpawner : ObjectSpawnerFromPool
{
    protected override void SpawnObject()
    {
        Vector3 pos = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        GameObject currentFood = objectPool.SpawnFromPool(spawnObjectTag, pos, Quaternion.identity);
        GameObject currentFood2 = objectPool.SpawnFromPool(spawnObjectTag, pos, Quaternion.identity);
        GameObject currentFood3 = objectPool.SpawnFromPool(spawnObjectTag, pos, Quaternion.identity);


        Vector2 shootingDirection = new Vector2(Random.Range(-1f,1f), Random.Range(-1f,1f)).normalized;
        currentFood.GetComponent<FoodScript>().setMoveDirection(shootingDirection);

    }
}
