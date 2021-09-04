using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore;
using TMPro;

public class RandomNotes : MonoBehaviour
{
    // Start is called before the first frame update
    string[] Notes = {
        "C", "C#", "D", "D#", "E", "F", "F#", "G", "G#", "A", "A#", "B"
    };
    public string noteforup, notefordown, noteforleft, noteforright;
    public TMP_Text tmp1, tmp2, tmp3, tmp4;
    void Start()
    {
        noteforup = Notes[(int)Random.Range(0, 3)];
        notefordown = Notes[(int)Random.Range(3, 6)];
        noteforleft = Notes[(int)Random.Range(6, 9)];
        noteforright = Notes[(int)Random.Range(9, 12)];
        string[] notesMes = {noteforup, notefordown, noteforleft, noteforright};
        GameObject.FindWithTag("MazePlayer").SendMessage("RanNotes",notesMes);
        tmp1.text = noteforup + " - движение вверх";
        tmp2.text = notefordown + " - движение вниз";
        tmp3.text = noteforleft + " - движение влево";
        tmp4.text = noteforright + " - движение вправо";
    }
}

