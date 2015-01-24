﻿using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	
	private static GameManager _instance;

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
		Application.LoadLevel(Application.loadedLevel);
	}
}
