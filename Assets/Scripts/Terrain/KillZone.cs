using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZone : MonoBehaviour, ITerrain
{
    [SerializeField] private ITerrain.GroundType groundType;

    [SerializeField] private float moveSpeedX = 0;
    [SerializeField] private float moveSpeedY = 0;
    public ITerrain.GroundType getGroundType()
    {
        return this.groundType;
    }

    private void Update(){
        transform.position += new Vector3(moveSpeedX, moveSpeedY, 0);
    }

    void OnCollisionEnter2D(Collision2D collision){
        Debug.Log("Collision detected!");

        if(collision.gameObject.TryGetComponent(out IUnits units)){
            if(units.GetUnitsType() == IUnits.UnitType.PLAYER_UNIT || units.GetUnitsType() == IUnits.UnitType.ENEMY_UNIT
            || units.GetUnitsType() == IUnits.UnitType.FODD_UNIT || units.GetUnitsType() == IUnits.UnitType.NONE){
                units.takenDamage(99999);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision){
        Debug.Log("Collision detected!");

        if(collision.gameObject.TryGetComponent(out IUnits units)){
            if(units.GetUnitsType() == IUnits.UnitType.PLAYER_UNIT || units.GetUnitsType() == IUnits.UnitType.ENEMY_UNIT
            || units.GetUnitsType() == IUnits.UnitType.FODD_UNIT || units.GetUnitsType() == IUnits.UnitType.NONE){
                units.takenDamage(99999);
            }
        }
    }
}
