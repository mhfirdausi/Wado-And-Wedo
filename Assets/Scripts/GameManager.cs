using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
		
	private static GameManager _instance;
	private int curScore = 0;
	private int totScore= 0;
	public bool isPaused = false;
	public Canvas canvas;
	public AudioClip levelOneMusic;
	public AudioClip levelTwoMusic; 
	private enum e_Scene
	{
		MAINMENU,
		LEVEL1,
		PUZZLE1,
		LEVEL2,
		PUZZLE2,
		LEVEL3,
		PUZZLE3
	};
	
	
	public static GameManager instance 
	{
		get 
		{
			if (_instance == null) 
			{
				_instance = GameObject.FindObjectOfType<GameManager> ();
				DontDestroyOnLoad (_instance.gameObject);
			}
			return _instance;
		}
	}

	void Awake()
	{
		if (_instance == null) 
		{
			_instance = this;
			DontDestroyOnLoad(this);
		}
		else
		{
			if(this != _instance)
			{
				Destroy(this.gameObject);
			}
		}
		
	}
	public void callDeath()
	{
		curScore = 0;
		Debug.Log(curScore);
		Application.LoadLevel(Application.loadedLevel);
	}
	
	public void startGame()
	{
		Application.LoadLevel(1);
		audio.Play();
	}
	public void quit()
	{
		Application.Quit();
	}
	public void coinCollect()
	{
		curScore = curScore + 10;
		Debug.Log(curScore);
	}
	public void pauseGame()
	{
		isPaused = true;
		Time.timeScale = 0;
		canvas.enabled = true;
	}
	public void resumeGame()
	{
		Time.timeScale = 1;
		canvas.enabled = false;
	}
}
