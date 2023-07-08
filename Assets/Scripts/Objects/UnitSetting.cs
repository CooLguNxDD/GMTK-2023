using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class UnitSetting : MonoBehaviour, IUnits
{
   public UnitsScriptableObject UnitsScriptableObject;

    //UnitsScriptableObject -> Unit Setting
    private string UnitsTag;

    private IUnits.UnitType UnitsType;
    

    public event EventHandler unitHurt;
    public event EventHandler getScoreWhenUnitCollide;
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
            this.gameObject.SetActive(false);
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

    public void HurtedVisual(){
        unitHurt?.Invoke(this, EventArgs.Empty);
    }

    public void AddingScore(){
        GameManager.Instance.TotalScore += 1;
        getScoreWhenUnitCollide?.Invoke(this, EventArgs.Empty);
    }

    public void takenDamage(float hp)
    {
        HurtedVisual();
        this.HP -= hp;
    }
}
