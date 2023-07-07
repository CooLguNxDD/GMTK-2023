using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUnits
{
    public enum UnitType
    {
        PLAYER_UNIT,
        ENEMY_UNIT,
        BOSS_UNIT,
        NONE
    }
    public void SetHP(float hp);
    public float GetHP();

    public void takenDamage(float hp);
    public UnitType GetUnitsType();
    public string getUnitsName();
}
