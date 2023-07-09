using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomEnemyFoodSpawner : ObjectSpawnerFromPool
{
    protected override void SpawnObject()
    {
        Vector3 pos = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        GameObject currentFood = objectPool.SpawnFromPool(spawnObjectTag, pos, Quaternion.identity);

        Vector2 shootingDirection = new Vector2(Mathf.Sin(Random.Range(0,360)), Mathf.Cos(Random.Range(0,360))).normalized;
        currentFood.GetComponent<FoodScript>().setMoveDirection(shootingDirection);

    }
}
