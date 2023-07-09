using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; set; }

    public UnityEvent deathEvent;

    public float TotalScore;

    public AudioSource bgMusic;

    public AudioSource deathMusic;

    public float TotalRun;

    public string Menu;

    public bool Die;


    //manage Global variable here
    void Awake(){
        if (Instance == null)
        {
            Debug.Log("only one GameManager instance available");
        }
        Die = false;
        Instance = this;
    }
    void Start()
    {     
        if (deathEvent == null)
            deathEvent = new UnityEvent();
        TotalScore = 0f;
        bgMusic.Play();
        deathMusic.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if(Die){
            deathEvent?.Invoke();
            //put the death screen here!
        }
    }
    public void BackToMenu(){
        Debug.Log("BACK TO Menu");
        SceneManager.LoadScene(Menu);
    }
}
