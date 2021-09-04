using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class WinMenuRunner : MonoBehaviour
{
    // Update is called once per frame
    float timer = 0.0f;
    public bool isEndGame = false;
    public TMP_Text timerEnd;
    public GameObject canPause, canWinning;
    void Update(){
        if (Time.timeScale != 0.0f) timer += Time.deltaTime;
        if (Time.timeScale == 0.0f) timerEnd.text = "Вы продержались " + Mathf.Round(timer).ToString() + " секунд(ы)!";
        if (canWinning.activeSelf && canPause.activeSelf) canPause.SetActive(false); 
    }
    public void Restart(){
        SceneManager.LoadSceneAsync("Demo", LoadSceneMode.Single);
    }
    public void MainMenu(){
        SceneManager.LoadSceneAsync("Main_Menu", LoadSceneMode.Single);
    }
    
}
