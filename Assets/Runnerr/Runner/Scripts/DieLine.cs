using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieLine : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject EndGame;
    void Start()
    {
        
    }
    void OnTriggerEnter2D(Collider2D collider2D){
        if (collider2D.gameObject.tag == "RunnerPlayer"){
            Time.timeScale = 0.0f;
            EndGame.SetActive(true);
            
        }
    }
}
