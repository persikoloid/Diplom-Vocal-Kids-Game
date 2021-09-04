using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazePers : MonoBehaviour
{
    private Animator anim;
    bool isIdle = true;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void OnCollisionEnter2D(Collision2D myCol){
        if (myCol.collider.tag == "Player" && isIdle == true){
            State = States.TriggerPlayer;
            isIdle = false;
        }
    }
    void OnCollisionExit2D(Collision2D myCol){
        if (myCol.collider.tag == "Player" && isIdle == false){
            State = States.IdleMaze;
            isIdle = true;
        }
    }
    private States State{
		get { return (States)anim.GetInteger("state"); }
		set { anim.SetInteger("state", (int)value); }
	}
    public enum States {
	IdleMaze,
	TriggerPlayer
}
}
