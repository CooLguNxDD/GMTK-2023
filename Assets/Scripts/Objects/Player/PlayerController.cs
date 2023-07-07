using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    
    [SerializeField] private GameInput gameInput;

    [SerializeField] private UnitSetting unitSetting;

    private Vector2 _movementInput;
    private Vector2 _smoothedMovementInput;
    private Vector2 _movementInputSmoothVelocity;

    private float moveSpeed = 10f;
    private bool isWalking;

    private void Start(){
         moveSpeed = unitSetting.getWalkingSpeed();
    }

    private void Update(){


        _movementInput = gameInput.GetMovementVectorNormalized();

        _smoothedMovementInput = Vector2.SmoothDamp(
            _smoothedMovementInput,
             _movementInput,
            ref _movementInputSmoothVelocity,
            0.1f);

        Vector3 moveDir = new Vector3(_smoothedMovementInput.x, _smoothedMovementInput.y, 0f);
        transform.position += moveDir * moveSpeed * Time.deltaTime;

        isWalking = moveDir != Vector3.zero;

        // float rotationSpeed = 10f;
        // transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * rotationSpeed);
    }
    
    public bool IsWalking(){
        return isWalking;
    }

}
