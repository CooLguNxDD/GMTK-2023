using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class InGameUiController : MonoBehaviour
{
    public TMP_Text ScoreText;
    public GameObject PlayerController;
    // Start is called before the first frame update
    void Start()
    {
        ScoreText.SetText("Score: " + GameManager.Instance.TotalScore);
        PlayerController.GetComponent<UnitSetting>().getScoreWhenUnitCollide += performScoreUp;
    }

    public void performScoreUp(object sender, EventArgs args){

        ScoreText.SetText("Score: " + GameManager.Instance.TotalScore);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
