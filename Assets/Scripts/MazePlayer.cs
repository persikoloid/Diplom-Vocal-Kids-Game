using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
[RequireComponent(typeof(Rigidbody2D))]
public class MazePlayer : MonoBehaviour
{
    // Start is called before the first frame update
    string noteUp;
    string noteDown;
    string noteLeft;
    string noteRight;
    string micNote;
    MicInput2 noteCheck;
    RandomNotes randomNotes;
    Rigidbody2D rigidbody;
    
    public TMP_Text notePlr;
    
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (micNote == noteUp) rigidbody.AddForce(Vector2.up * 2);
        if (micNote == noteDown) rigidbody.AddForce(Vector2.down * 2);
        if (micNote == noteLeft) rigidbody.AddForce(Vector2.left * 2);
        if (micNote == noteRight) rigidbody.AddForce(Vector2.right * 2);
    }

    void NoteCheck(string noteMic){
        micNote = noteMic;
        notePlr.text = micNote;
    }
    void RanNotes(string[] mes){
        noteDown = mes[1];
        noteUp = mes[0];
        noteLeft = mes[2];
        noteRight = mes[3];
    }
}
