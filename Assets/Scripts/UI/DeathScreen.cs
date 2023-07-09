using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DeathScreen : MonoBehaviour
{
    // Start is called before the first frame update

    public Button toMenuButton;
    public TMP_Text GameScore;
    public TMP_Text WalkingDistance;

    private bool isEnd;
    void Start()
    {
        isEnd = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!isEnd){
            GameScore.SetText("Score: " + GameManager.Instance.TotalScore);
            WalkingDistance.SetText("Run: " + Mathf.Floor(GameManager.Instance.TotalRun) + "M");
        }

    }
    public void setGameEnd(){
        isEnd = true;
    }

    public void SetDeathScreenUp(){
        gameObject.SetActive(true);
    }
}
