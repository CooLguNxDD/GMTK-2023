using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    
    [SerializeField] private GameInput gameInput;

    [SerializeField] private UnitSetting unitSetting;

    private float moveSpeed = 10f;
    private bool isWalking;

    private void Start(){
         moveSpeed = unitSetting.getWalkingSpeed();
    }
    private void Update(){

        Vector2 inputVector = gameInput.GetMovementVectorNormalized();


        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);
        transform.position += moveDir * moveSpeed * Time.deltaTime;

        isWalking = moveDir != Vector3.zero;

        float rotationSpeed = 10f;
        transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * rotationSpeed);
    }
    
    public bool IsWalking(){
        return isWalking;
    }

}
