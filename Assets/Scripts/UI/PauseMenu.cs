// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.Events;

// public class PauseMenu : MonoBehaviour
// {

//     public GameObject pauseMenuUI;
//     public static bool GameIsPaused = false;

//     // Update is called once per frame
//     void Update()
//     {
//         if (GameIsPaused)
//         {
//             Debug.Log("Game is Paused");
//             Pause();
//         }
//         else
//         {
//             Resume();
//         }
//     }

//     public void Pause()
//     {
//         pauseMenuUI.SetActive(true);
//         Time.timeScale = 0f;
//         GameIsPaused = true;
//         Debug.Log("Game is Paused");
//     }

//     public void Resume()
//     {
//         pauseMenuUI.SetActive(false);
//         Time.timeScale = 1f;
//         GameIsPaused = false;
//     }

// }
