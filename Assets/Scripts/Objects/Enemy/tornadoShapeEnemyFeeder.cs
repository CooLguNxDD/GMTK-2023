using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : ObjectSpawnerFromPool
{
    [SerializeField] private int NumberOfShoot = 10;
    protected int currentAngle = 0;
    private int evenAngle;

    protected override void Start(){
        if (!objectPool)
        {
            objectPool = GameObject.Find("ObjectPool").GetComponent<ObjectPool>();
        }
        currentAngle = 0;
        evenAngle = 360 / NumberOfShoot;
    }
    
    protected override void SpawnObject()
    {
        Vector3 pos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        currentAngle = currentAngle + evenAngle;

        if(currentAngle > 360){
            currentAngle -= 360;
        }

        GameObject currentFood = objectPool.SpawnFromPool(spawnObjectTag, pos, Quaternion.identity);

        Vector3 direction = new Vector2(Mathf.Sin(currentAngle) , Mathf.Cos(currentAngle)).normalized;
        currentFood.GetComponent<FoodScript>().setMoveDirection(direction);
    }
}
