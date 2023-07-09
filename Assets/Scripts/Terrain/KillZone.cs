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
    Debug.Log("Collision detected!");
    UnitSetting unit = collision.gameObject.GetComponent<UnitSetting>();
    if(unit != null){
        Debug.Log("Player hit!");
        if(unit.GetUnitsType() == IUnits.UnitType.PLAYER_UNIT){
            unit.takenDamage(99999);
        }
    }
}
}
