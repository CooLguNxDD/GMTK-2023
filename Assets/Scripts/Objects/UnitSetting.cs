using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSetting : MonoBehaviour, IUnits
{
   public UnitsScriptableObject UnitsScriptableObject;

    //UnitsScriptableObject -> Unit Setting
    private string UnitsTag;

    private IUnits.UnitType UnitsType;
    private string UnitsName;

    private int level;
    private float HP;
    private float WalkingSpeed;


    void Awake()
    {
        ResetSetting();
        // Debug.Log("Spawned Unit " + UnitsName);
    }
    public void ResetSetting()
    {
        UnitsTag = UnitsScriptableObject.UnitsTag;
        UnitsType = UnitsScriptableObject.UnitsType;
        UnitsName = UnitsScriptableObject.UnitsName;
        HP = UnitsScriptableObject.HP;
        WalkingSpeed = UnitsScriptableObject.WalkingSpeed;
    }

    public void Update(){
        if(this.HP <= 0f){
            Destroy(this.gameObject);
        }
    }


    public void ResetAll(){
        ResetSetting();
    }


    public string getUnitsName()
    {
        return this.UnitsName;
    }
    public float getWalkingSpeed(){
        return WalkingSpeed;
    }

    public IUnits.UnitType GetUnitsType()
    {
        return this.UnitsType;
    }
    public void SetHP(float hp)
    {
        this.HP = hp;
    }

    public float GetHP()
    {
        return HP;
    }

    public void takenDamage(float hp)
    {
        this.HP -= hp;
    }
}
