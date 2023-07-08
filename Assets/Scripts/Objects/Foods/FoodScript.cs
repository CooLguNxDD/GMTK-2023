using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodScript : MonoBehaviour
{
    // Start is called before the first frame update

    public UnitSetting unitSetting;

    private Vector3 moveDirection;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += moveDirection * unitSetting.getWalkingSpeed() * Time.deltaTime;
    }

    public void setMoveDirection(Vector2 moveDir){
        moveDirection = new Vector3(moveDir.x, moveDir.y, 0f);
    }
}
