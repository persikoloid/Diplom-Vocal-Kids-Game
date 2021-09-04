// NULLcode Studio © 2015
// null-code.ru

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour {

	public GameObject player;
	public float gameSpeed = 3;
	public GameObject block;
	public GameObject blockAlert;
	public float timeoutMin = 1;
	public float timeoutMax = 1.5f;
	public Vector2 offset;
	public GameObject gameOverMenu;
	private float curTimeout;
	private static float tmpSpeed;
	private float timeout;
	public static bool gameOver;

	void Awake () 
	{
		gameOverMenu.SetActive(false);
		gameOver = false;
		offset = new Vector2(Mathf.Abs(offset.x), offset.y);
		timeout = Random.Range(timeoutMin, timeoutMax);
	}

	void Start () 
	{
		//Instantiate(player, transform.position, Quaternion.identity);
	}

	public void Restart()
	{
		Time.timeScale = 1;
		SceneManager.LoadSceneAsync("Game", LoadSceneMode.Single);
		//Application.LoadLevel(Application.loadedLevel);
	}

	public void Exit()
	{
		SceneManager.LoadSceneAsync("Main_Menu", LoadSceneMode.Single);
	}

	public static float speed
	{
		get { return tmpSpeed; }
	}

	void Update ()
	{
		tmpSpeed = gameSpeed;
		curTimeout += Time.deltaTime;
		if (curTimeout > timeout) 
		{
			timeout = Random.Range(timeoutMin, timeoutMax);
			curTimeout = 0;

			GameObject obj = block;

			if(Random.Range(0, 5) == Random.Range(0, 5)) obj = blockAlert;

			Vector3 sdvig = new Vector3(Random.Range(-offset.x, offset.x), offset.y, 0);
			Instantiate(obj, transform.position+sdvig, Quaternion.identity);
		}

		if(gameOver)
		{
			Time.timeScale = 0;
			gameOver = false;
			gameOverMenu.SetActive(true);
		}
	}
}
