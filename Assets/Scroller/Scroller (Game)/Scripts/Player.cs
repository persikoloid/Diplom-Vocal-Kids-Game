using UnityEngine;
using System.Collections;
using TMPro;

[RequireComponent(typeof(Rigidbody2D))]

public class Player : MonoBehaviour {

	public float speed = 150;
	public float linearDrag = 10;
	public bool isFacingRight = true;
	private Vector3 direction;
	private float h;
	private Rigidbody2D body;
	string[] Notes = {
        "C", "C#", "D", "D#", "E", "F", "F#", "G", "G#", "A", "A#", "B"
    };
    string micNote, rightNote, leftNote;
	public TMP_Text notePlr, RightNote, LeftNote;
	
	void Start () 
	{
		RanNotes();
		body = GetComponent<Rigidbody2D>();
		body.freezeRotation = true;
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		if(coll.transform.tag == "Finish") Game.gameOver = true;
	}
	
	void FixedUpdate()
	{
		body.AddForce(direction * body.mass * speed);
		
		if(Mathf.Abs(body.velocity.x) > speed/100f)
		{
			body.velocity = new Vector2(Mathf.Sign(body.velocity.x) * speed/100f, body.velocity.y);
		}
	}
	// отражение по горизонтали
	void Flip()
	{
		isFacingRight = !isFacingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	void Update () 
	{
		//h = Input.GetAxis("Horizontal");

		if(micNote == rightNote) h = 1f; 
		else if (micNote == leftNote) h =-1f; 
		else h = 0f;
		direction = new Vector2(h, 0); 

		if(h > 0 && !isFacingRight) Flip(); else if(h < 0 && isFacingRight) Flip();

		if(body.velocity.y == 0) body.drag = linearDrag; else body.drag = 0;
	}

	void NoteCheck(string noteMic){
        micNote = noteMic;
        notePlr.text = micNote;
    }

	void RanNotes(){
        rightNote = Notes[(int)Random.Range(0, 5)];
		leftNote = Notes[(int)Random.Range(6, 11)];
        RightNote.text = rightNote + " - движение вправо";
		LeftNote.text = leftNote + " - движение влево";
    }
}
