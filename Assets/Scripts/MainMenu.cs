using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame(){
        SceneManager.LoadScene("MazeScene", LoadSceneMode.Single);
    }
    public void ExitGame(){
        Application.Quit();
    }
    public void StartRunner(){
        SceneManager.LoadScene("Demo", LoadSceneMode.Single);
    }

    public void StartScroller(){
        SceneManager.LoadScene("Game", LoadSceneMode.Single);
    }
    
}
