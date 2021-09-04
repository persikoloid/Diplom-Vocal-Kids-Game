using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public GameObject pauseUI;
    // Update is called once per frame
    void Start(){
        Time.timeScale = 1f;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)){
            if (gameIsPaused){
                Resume();
            }
            else{
                Pause();
            }
        }
    }

    public void Resume(){
        pauseUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }
    public void Pause(){
        pauseUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }
    public void MainMenu(){
        SceneManager.LoadScene("Main_Menu", LoadSceneMode.Single);
    }
    public void ExitGame(){
        Application.Quit();
    }
}
