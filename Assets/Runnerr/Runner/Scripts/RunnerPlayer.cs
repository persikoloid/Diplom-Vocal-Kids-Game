using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
[RequireComponent(typeof(Rigidbody2D))]
public class RunnerPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    string noteJump;
    string[] Notes = {
        "C", "C#", "D", "D#", "E", "F", "F#", "G", "G#", "A", "A#", "B"
    };
    string micNote;
    MicInputRunner noteCheck;
    Rigidbody2D rigidbody;
    float timer = 0, checkTime = 0;
    public TMP_Text notePlr;
    public TMP_Text jumpNote;
    
    void Start()
    {
        RanNotes();
        rigidbody = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate(){
        if (micNote == noteJump) rigidbody.AddForce(Vector2.up * 25);
    }
    // Update is called once per frame
    void Update()
    {
        rigidbody.AddForce(Vector2.right);
        if (Time.timeScale != 0.0f) timer += Time.deltaTime;
        if (timer > checkTime + 20) {
            checkTime = timer;
            RanNotes();
        }
    }

    void NoteCheck(string noteMic){
        micNote = noteMic;
        notePlr.text = micNote;
    }
    void RanNotes(){
        noteJump = Notes[(int)Random.Range(0, 11)];
        jumpNote.text = noteJump + " - полёт";
    }
}
