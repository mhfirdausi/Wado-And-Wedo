using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
		
	private static GameManager _instance;
	private int curScore = 0;
	private int totScore= 0;
	private int curLevel = 0;
	public bool isPaused = false;
	public Canvas canvas;
	//public AudioClip levelOneMusic;
	//public AudioClip levelTwoMusic;
	[HideInInspector]
	public int wadoDeaths = 0;
	public int wedoDeaths = 0;
	public int wedoTotDeaths = 0;
	public int wadoTotDeaths = 0;
	//private AudioSource curMusic;

	
	
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
		//curMusic = gameObject.GetComponent<AudioSource>();
		//audio.clip = levelOneMusic;
		//curMusic.Pause();
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
	void Update()
	{
		if(Input.GetButtonDown("SkipLevel"))
		{
			switch(curLevel)
			{
				case 0:
					instrScreen();
					break;
				case 1:
					startGame();
					break;
				case 2:
					endScreenOne();
					break;
				case 3:
					startLevelTwo();
					break;
				case 4:
					endScreenTwo();
					break;
				case 5:
					returnToMenu();
					break;
			}
		}
		if (Input.GetButtonDown("Menu"))
		{
			Application.LoadLevel(Application.loadedLevel);
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
		
		Application.LoadLevel(2);
		//audio.clip = levelOneMusic;
		
		curLevel = 2;
		//audio.Play();
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
	/*
	public void pauseGame()
	{
		isPaused = true;
		Time.timeScale = 0;
		canvas.enabled = true;
	}
	*/
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
		curLevel = 1;
		Application.LoadLevel(1);
		Screen.showCursor = false;
	}
	public void endScreenOne()
	{
		wedoTotDeaths = wedoDeaths;
		wadoTotDeaths = wadoDeaths;
		Application.LoadLevel(3);
		curLevel = 3;
		Screen.showCursor = true;
	}
	public void startLevelTwo()
	{
		wadoDeaths = 0;
		wedoDeaths = 0;
		//curMusic.clip = levelTwoMusic;
		Application.LoadLevel(4);
		curLevel = 4;
		Screen.showCursor = false;
	}
	public void endScreenTwo()
	{
		wedoTotDeaths += wedoDeaths;
		wadoTotDeaths += wadoTotDeaths;
		Application.LoadLevel(5);
		curLevel = 5;
	}
	public void returnToMenu()
	{
		Application.LoadLevel(1);
		Screen.showCursor = true;
		curLevel = 1;
		//curMusic.Stop();
	}
	
}
