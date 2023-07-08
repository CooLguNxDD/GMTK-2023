using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; set; }

    public float TotalScore;


    //manage Global variable here
    void Awake(){
        if (Instance == null)
        {
            Debug.Log("only one GameManager instance available");
        }

        Instance = this;
    }
    void Start()
    {
        TotalScore = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
