using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    private PlayerLife playerLife;
    [SerializeField] private GameInput gameInput;
    [SerializeField] private UnitSetting unitSetting;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator animator;
	[SerializeField] private SpriteRenderer playerSprite;

    private Vector2 _movementInput;
    private Vector2 _smoothedMovementInput;
    private Vector2 _movementInputSmoothVelocity;

    private float moveSpeed = 10f;
    private bool isWalking;

    private void Start(){
    playerLife = GetComponent<PlayerLife>();

    if (playerLife == null)
    {
        Debug.LogError("PlayerLife component not found on this GameObject. Please add one.");
    }
    }

    private void Update(){
        if (playerLife != null && playerLife.IsDead()) return;

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

        if(_smoothedMovementInput.x > 0f){
            playerSprite.flipX = true;
        }
        else{
            playerSprite.flipX = false;
        }
        Vector3 moveDir = new Vector3(_smoothedMovementInput.x, _smoothedMovementInput.y, 0f);


        transform.position += moveDir * moveSpeed * Time.deltaTime;

        isWalking = moveDir != Vector3.zero;
        if(!animator) return;
        animator.SetBool("IsWalking", isWalking);
        

        // float rotationSpeed = 10f;
        // transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * rotationSpeed);
    }

    private void RotateInDirectionOfInput(){
        if (_movementInput != Vector2.zero){
            float targetAngle = Mathf.Atan2(_smoothedMovementInput.y, _smoothedMovementInput.x) * Mathf.Rad2Deg;
            Quaternion targetRotation = Quaternion.Euler(0, 0, targetAngle);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);
        }
    }

    public bool IsWalking(){
        return isWalking;
    }


    void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.TryGetComponent(out IUnits units)){
            if(units.GetUnitsType() == IUnits.UnitType.FODD_UNIT){
                unitSetting.AddingScore();
                collision.gameObject.GetComponent<UnitSetting>().SetHP(-1);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.TryGetComponent(out IUnits units)){
            if(units.GetUnitsType() == IUnits.UnitType.FODD_UNIT){
                unitSetting.AddingScore();
                collision.gameObject.GetComponent<UnitSetting>().SetHP(-1);
            }
        }
    }



}
