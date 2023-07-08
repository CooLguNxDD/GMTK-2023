using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class EnemyFeeder : MonoBehaviour
{
    [SerializeField] private UnitSetting unitSetting;

    [SerializeField] private GameInput gameInput;

    [SerializeField] private float impulseForce;


    [SerializeField] private GameObject collidedObject;
    private Vector2 currentImpulse;

    // Start is called before the first frame update
    void Start()
    {
        if(!gameInput){
            gameInput = GameObject.Find("GameInput").GetComponent<GameInput>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(collidedObject){
            Vector2 currentVelocity = collidedObject.GetComponent<Rigidbody2D>().velocity;
            if(Mathf.Abs(currentVelocity.x) > 0.001f  || Mathf.Abs(currentVelocity.y) > 0.001f){
                collidedObject.GetComponent<Rigidbody2D>().velocity = currentVelocity / 1.005f;
            }
        }
    }

    


    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.TryGetComponent(out IUnits units)){
            if(units.GetUnitsType() == IUnits.UnitType.PLAYER_UNIT){
                units.takenDamage(1);

                currentImpulse = gameInput.GetMovementVectorNormalized();
                collision.gameObject.GetComponent<Rigidbody2D>()
                .AddForce(new Vector2(-currentImpulse.x * impulseForce, -currentImpulse.y * impulseForce), ForceMode2D.Impulse);

                collidedObject = collision.gameObject;
            }
        }
    }
}
