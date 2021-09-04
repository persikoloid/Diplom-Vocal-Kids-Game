using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]

public class Character2DPlatformer : MonoBehaviour {

	public float speed = 1.5f; // скорость движения
	public float acceleration = 100; // ускорение
	public float jumpForce = 5; // сила прыжка
	public float jumpDistance = 0.75f; // расстояние от центра объекта, до поверхности (определяется вручную в зависимости от размеров спрайта)
	public bool facingRight = true; // в какую сторону смотрит персонаж на старте?
	public KeyCode jumpButton = KeyCode.Space; // клавиша для прыжка

	private Vector3 direction;
	private int layerMask;
	private Rigidbody2D body;
	private Animator anim;
	
	void Start () 
	{
		anim = GetComponent<Animator>();
		body = GetComponent<Rigidbody2D>();
		body.freezeRotation = true;
		layerMask = 1 << gameObject.layer | 1 << 2;
		layerMask = ~layerMask;
	}

	private States State{
		get { return (States)anim.GetInteger("state"); }
		set { anim.SetInteger("state", (int)value); }
	}

	bool GetJump() // проверяем, есть ли коллайдер под ногами
	{
		bool result = false;
		RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector3.down, jumpDistance, layerMask);
		if(hit.collider)
		{
			result = true;
		}
		return result;
	}
	
	void FixedUpdate()
	{
		body.AddForce(direction * body.mass * speed * acceleration);
		if (GetJump() && body.velocity == Vector2.zero) State = States.Idle;
		else if (GetJump() && body.velocity != Vector2.zero) State = States.move;
		else State = States.jump;
		if(Mathf.Abs(body.velocity.x) > speed)
		{
			body.velocity = new Vector2(Mathf.Sign(body.velocity.x) * speed, body.velocity.y);
		}
	}
	
	void Flip() // отражение по горизонтали
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
	
	void Update () 
	{	
		Debug.DrawRay(transform.position, Vector3.down * jumpDistance, Color.red); // подсветка, для визуальной настройки jumpDistance
		if(Input.GetKeyDown(jumpButton) && GetJump())
		{
			body.velocity = new Vector2(0, jumpForce);
		}
		float h = Input.GetAxis("Horizontal");
		direction = new Vector2(h, 0); 
		if(h > 0 && !facingRight) Flip(); else if(h < 0 && facingRight) Flip();
	}
}
public enum States {
	Idle,
	move,
	jump
}