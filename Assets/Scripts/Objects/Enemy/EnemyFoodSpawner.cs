using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFoodSpawner : ObjectSpawnerFromPool
{
    protected override void SpawnObject()
    {
        Vector3 pos = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        GameObject currentFood = objectPool.SpawnFromPool(spawnObjectTag, pos, Quaternion.identity);
        GameObject currentFood2 = objectPool.SpawnFromPool(spawnObjectTag, pos, Quaternion.identity);
        GameObject currentFood3 = objectPool.SpawnFromPool(spawnObjectTag, pos, Quaternion.identity);


        Vector2 shootingDirection = new Vector2(Random.Range(-1f,1f), Random.Range(-1f,1f));
        Vector2 shootingDirection2 = new Vector3(shootingDirection.x - 0.1f, shootingDirection.y - 0.1f);
        Vector2 shootingDirection3 = new Vector3(shootingDirection.x + 0.1f, shootingDirection.y + 0.1f);
        
        currentFood.GetComponent<FoodScript>().setMoveDirection(shootingDirection);
        currentFood2.GetComponent<FoodScript>().setMoveDirection(shootingDirection2);
        currentFood3.GetComponent<FoodScript>().setMoveDirection(shootingDirection3);
    }
}
