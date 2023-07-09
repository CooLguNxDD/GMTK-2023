using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class EnemyAnimal : MonoBehaviour
{
    [SerializeField] private UnitSetting unitSetting;

    [SerializeField] private GameInput gameInput;
    [SerializeField] private Rigidbody2D rigidbody2D;

    [SerializeField] private float impulseForce;

    [SerializeField] private float detectionRange;

    [SerializeField] private SpriteRenderer spriteRenderer;


    [SerializeField] private GameObject collidedObject;
    private Vector2 currentImpulse;
    [SerializeField] private bool isPlayerTargetFound;

    [SerializeField] private bool isFoodTargetFound;
    
    [SerializeField]
    private GameObject currentTargetObject;
    
    [SerializeField]
    private GameObject currentTargetFood;

    [SerializeField] private Vector2 newtargetPosition;



    // Start is called before the first frame update
    void Start()
    {
        if(!gameInput){
            gameInput = GameObject.Find("GameInput").GetComponent<GameInput>();
        }
        newtargetPosition = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {
        // // slow down
        // if(collidedObject){
        //     Vector2 currentVelocity = collidedObject.GetComponent<Rigidbody2D>().velocity;
        //     if(Mathf.Abs(currentVelocity.x) > 0.001f  || Mathf.Abs(currentVelocity.y) > 0.001f){
        //         collidedObject.GetComponent<Rigidbody2D>().velocity = currentVelocity / 1.005f;
        //     }
        // }

        checkIsPlayerNearby();
        escapeFromPlayer();

        checkNextFood();
        chaseFood();


    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRange);
        Gizmos.DrawLine(transform.position, newtargetPosition);

        Gizmos.color = Color.yellow;
        if(currentTargetFood){
            Gizmos.DrawLine(transform.position, currentTargetFood.transform.position);
        }
        
    }

    private void checkNextFood(){

        if(!isPlayerTargetFound){
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, detectionRange);
            if(colliders.Length == 0){
                return;
            }
            //find the closest player target
            float nearestDistance = 9999999f;
            // Debug.Log("dectected");
            foreach (Collider2D collider in colliders){
                if(collider.TryGetComponent(out IUnits status)){
                    if(status.GetUnitsType() == IUnits.UnitType.FODD_UNIT){
                        float currentDistance = Vector3.Distance(transform.position, collider.gameObject.transform.position);
                        if(currentDistance < nearestDistance){
                            nearestDistance = currentDistance;
                            currentTargetFood = collider.gameObject;
                        }
                        isFoodTargetFound = true;
                    }
                }
            }
        }else{
            isFoodTargetFound = false;
        }
    }

    private void chaseFood(){

        if(!currentTargetFood)  return;

        if(isFoodTargetFound && !isPlayerTargetFound){
            transform.position = Vector2.MoveTowards(transform.position, currentTargetFood.transform.position, unitSetting.getWalkingSpeed() * Time.deltaTime);
        }
        
        if(@isPlayerTargetFound) return;
        Vector2 direction = new Vector2(transform.position.x, transform.position.y) -
             new Vector2(currentTargetFood.transform.position.x, currentTargetFood.transform.position.y);
        float angle = Vector2.Angle(Vector2.right, direction);

        if (Mathf.Abs(angle) < 90f)
        {
            spriteRenderer.flipX = false;
        }
        else if (Mathf.Abs(angle) > 90f)
        {
            spriteRenderer.flipX = true;
        }
            
    }

    private void checkIsPlayerNearby(){

        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, detectionRange);
        // Debug.Log(colliders.Length);
        if(colliders.Length == 1){
            isPlayerTargetFound = false;
            return;
        }
        //find the closest player target
        float nearestDistance = 9999999f;
        // Debug.Log("dectected");
        bool isTargerFound = false;
        foreach (Collider2D collider in colliders){
            if(collider.TryGetComponent(out IUnits status)){
                if(status.GetUnitsType() == IUnits.UnitType.PLAYER_UNIT || status.GetUnitsType() == IUnits.UnitType.ENEMY_UNIT){

                    //it should not detect it's own
                    if(collider.gameObject == this.gameObject){
                        continue;
                    }
                    //find the nearest enemy
                    float currentDistance = Vector3.Distance(transform.position, collider.gameObject.transform.position);
                    if(currentDistance < nearestDistance){
                        nearestDistance = currentDistance;
                        currentTargetObject = collider.gameObject;
                    }
                    isPlayerTargetFound = true;
                    isTargerFound = true;
                }

                if(!isTargerFound){
                    isPlayerTargetFound = false;
                }
            }
        }
    }

    private void escapeFromPlayer(){
        if(isPlayerTargetFound){

            newtargetPosition = new Vector2(
                transform.position.x + (transform.position.x - currentTargetObject.transform.position.x) * 0.5f,
                transform.position.y + (transform.position.y - currentTargetObject.transform.position.y) * 0.5f
            );
            transform.position = Vector2.MoveTowards(transform.position, newtargetPosition, unitSetting.getWalkingSpeed() * Time.deltaTime);

            Vector2 direction = new Vector2(transform.position.x, transform.position.y) -
             new Vector2(currentTargetObject.transform.position.x, currentTargetObject.transform.position.y);

            
            float angle = Vector2.Angle(Vector2.right, direction);

            Debug.Log("Escape:" + angle);

                if (Mathf.Abs(angle) < 90f)
                {
                    spriteRenderer.flipX = true;
                }
                else if (Mathf.Abs(angle) > 90f)
                {
                    spriteRenderer.flipX = false;
                }
            }
    }

    // add a Collision force when player collide with this object
    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.TryGetComponent(out IUnits units)){
            if(units.GetUnitsType() == IUnits.UnitType.FODD_UNIT){
                collision.gameObject.GetComponent<UnitSetting>().SetHP(-1);
            }
        }
    }
}
