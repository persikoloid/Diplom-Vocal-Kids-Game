using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MazeActivator : MonoBehaviour
{
    public Canvas textMesh;
    public AudioListener audioListener;
    BoxCollider2D boxCollider2D;
    public bool isEnabled = false, isTrigger = false;
    Scene scene;
    int tcount = 0;
    void Start(){
        boxCollider2D = GetComponent<BoxCollider2D>();
    }
    void Update(){
        if (Input.GetKeyDown(KeyCode.E) && isTrigger){
            Debug.Log("клавиша нажата");
            SceneManager.LoadSceneAsync("MazeScene", LoadSceneMode.Additive);
            audioListener.enabled = false;
            boxCollider2D.enabled = false;
        }
    }
    void OnCollisionEnter2D(Collision2D myCollision) {
        if (myCollision.gameObject.tag == "Player")
        {  
            isTrigger = true;
            isEnabled = true;
            textMesh.enabled = isEnabled;
        }
       
    }

    void OnCollisionExit2D(Collision2D collision){
        if (collision.gameObject.tag == "Player")
        {  
            isTrigger = false;
            isEnabled = false;
            textMesh.enabled = isEnabled;
            audioListener.enabled = true;
        }
    }
}

