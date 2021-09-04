using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinMenuMaze : MonoBehaviour
{
    public static bool gameIsPaused = false;
    // Update is called once per frame
    public void Restart(){
        SceneManager.LoadSceneAsync("MazeScene", LoadSceneMode.Single);
    }
    public void MainMenu(){
        SceneManager.LoadSceneAsync("Main_Menu", LoadSceneMode.Single);
    }
}
