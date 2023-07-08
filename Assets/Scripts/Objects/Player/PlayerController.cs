using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    
    [SerializeField] private GameInput gameInput;
    [SerializeField] private UnitSetting unitSetting;
    [SerializeField] private float _rotationSpeed;

    private Vector2 _movementInput;
    private Vector2 _smoothedMovementInput;
    private Vector2 _movementInputSmoothVelocity;

    private float moveSpeed = 10f;
    private bool isWalking;

    private void Start(){
         moveSpeed = unitSetting.getWalkingSpeed();
    }

    private void Update(){
        
        SetplayerVelocity();
        RotateInDirectionOfInput();
    }
    
    private void SetplayerVelocity(){
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

    private void RotateInDirectionOfInput(){
    if (_movementInput != Vector2.zero){
        float targetAngle = Mathf.Atan2(_smoothedMovementInput.y, _smoothedMovementInput.x) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.Euler(0, 0, targetAngle);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);
    }
}


    public bool IsWalking(){
        return isWalking;
    }

}
