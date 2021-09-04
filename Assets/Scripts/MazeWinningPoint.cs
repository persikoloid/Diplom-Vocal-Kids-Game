using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MazeWinningPoint : MonoBehaviour
{
    // Start is called before the first frame update
    bool isTrigger = false;
    public GameObject winMenu;
    void OnTriggerEnter2D(Collider2D collider2D){
        if (collider2D.gameObject.tag == "MazePlayer"){
            isTrigger = true;
        }
    }
     void OnTriggerExit2D(Collider2D collider2D){
        if (collider2D.gameObject.tag == "MazePlayer"){
            isTrigger = false;
        }
    }
    void Update(){
        if (isTrigger){
            winMenu.SetActive(true);
        }
    }
}
