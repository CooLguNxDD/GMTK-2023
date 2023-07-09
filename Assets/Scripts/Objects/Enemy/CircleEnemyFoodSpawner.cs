using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleEnemyFoodSpawner : ObjectSpawnerFromPool{

    [SerializeField] private int MaxNumberOfShoot = 10;
    [SerializeField] private int MinNumberOfShoot = 5;
    protected override void SpawnObject()
    {
        Vector3 pos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        int numberOfShoot = Random.Range(MinNumberOfShoot, MaxNumberOfShoot);
        int evenAngle = 360 / numberOfShoot;

        for (int i=0; i<=360; i+=evenAngle){
            GameObject currentFood = objectPool.SpawnFromPool(spawnObjectTag, pos, Quaternion.identity);

            Vector3 direction = new Vector2(Mathf.Sin(i) , Mathf.Cos(i)).normalized;
            currentFood.GetComponent<FoodScript>().setMoveDirection(direction);
        }


        // GameObject currentFood1 = objectPool.SpawnFromPool(spawnObjectTag, pos, Quaternion.identity);
        // direction = new Vector2(1f, 0f).normalized;
        // currentFood1.GetComponent<FoodScript>().setMoveDirection(direction);

        // direction = new Vector2(0f, 1f).normalized;
        // currentFood.GetComponent<FoodScript>().setMoveDirection(direction);

        // direction = new Vector2(0f, 1f).normalized;
        // currentFood.GetComponent<FoodScript>().setMoveDirection(direction);
    }
}

