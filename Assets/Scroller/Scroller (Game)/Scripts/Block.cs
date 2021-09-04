// NULLcode Studio © 2015
// null-code.ru

using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D coll)
	{
		coll.transform.parent = transform;
	}
	
	void OnCollisionExit2D(Collision2D coll)
	{
		coll.transform.parent = null;
	}

	void Update () 
	{
		transform.Translate(Vector3.up * Game.speed * Time.deltaTime);
	}

	void OnBecameInvisible () 
	{
		Destroy(gameObject);
	}
}
