using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HPHeartController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject UIHeartGroup;
    public GameObject HeartPrefab;

    public UnitSetting unitSetting;

    public GameObject playerObject;

    public List<GameObject> HeartPrefabList;


    void Awake(){

    }

    void Start(){
        for(int i = 0 ; i < playerObject.GetComponent<UnitSetting>().GetHP(); i++){
            GameObject newHeart = Instantiate(HeartPrefab, new Vector3(0f,0f,0f), Quaternion.identity);
            newHeart.transform.SetParent(UIHeartGroup.transform);
            HeartPrefabList.Add(newHeart);
        }
        playerObject.GetComponent<UnitSetting>().unitHurt += performHeartBrokenVisual;
    }

    public void performHeartBrokenVisual(object sender, EventArgs args){
        GameObject gameHeart = HeartPrefabList[(int)playerObject.GetComponent<UnitSetting>().GetHP() - 1];
        gameHeart.GetComponent<Animator>().SetBool("isBroken", true);
    }

    public void performWinUIPop(object sender, EventArgs args){

    }

    public void performLoseUIPop(object sender, EventArgs args){

    }


    // Update is called once per frame
    void Update()
    {
    }
}
