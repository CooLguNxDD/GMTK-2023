using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZone : MonoBehaviour, ITerrain
{
    [SerializeField] private ITerrain.GroundType groundType;
    public ITerrain.GroundType getGroundType()
    {
        return this.groundType;
    }

    void OnCollisionEnter2D(Collision2D collision){
        Debug.Log("got it!");
        if(collision.gameObject.TryGetComponent(out IUnits otherUnits)){
            Debug.Log("got it!");
            if(otherUnits.GetUnitsType() == IUnits.UnitType.PLAYER_UNIT){
                otherUnits.takenDamage(99999);
            }
        }
    }
}
