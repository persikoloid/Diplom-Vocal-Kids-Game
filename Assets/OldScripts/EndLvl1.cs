using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLvl1 : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D myCol){
        if (myCol.tag == "Player"){
            SceneManager.LoadSceneAsync("Lvl2Scene", LoadSceneMode.Single);
        }
    }
    
    
}
