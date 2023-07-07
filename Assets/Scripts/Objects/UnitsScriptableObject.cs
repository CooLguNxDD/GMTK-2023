using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewGameUnits/Units", menuName = "GameUnits")]
public class UnitsScriptableObject : ScriptableObject
{
    public int UnitsUID;

    //Unit discriptions
    //Unit tag should match the tag of the objectPool
    public string UnitsTag;

    public IUnits.UnitType UnitsType;
    public string UnitsName;

    //Basic Unit status
    public int HP;

    public float WalkingSpeed;


}
