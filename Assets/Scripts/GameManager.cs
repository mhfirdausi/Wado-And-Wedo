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
	[HideInInspector]
	public int wadoDeaths = 0;
	public int wedoDeaths = 0;
	public int wedoTotDeaths = 0;
	public int wadoTotDeaths = 0;
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
	public void instrScreen()
	{
		wadoDeaths = 0;
		wedoDeaths = 0;
		wedoTotDeaths = 0;
		wadoTotDeaths = 0;
		Application.LoadLevel(2);
	}
	public void endScreenOne()
	{
		wedoTotDeaths = wedoDeaths;
		wadoTotDeaths = wadoDeaths;
		Application.LoadLevel(3);
	}
	public void startLevelTwo()
	{
		wadoDeaths = 0;
		wedoDeaths = 0;
		Application.LoadLevel(4);
	}
	public void endScreenTwo()
	{
		wedoTotDeaths += wedoDeaths;
		wadoTotDeaths += wadoTotDeaths;
		Application.LoadLevel(5);
	}
	public void returnToMenu()
	{
		Application.LoadLevel(0);
	}
}
