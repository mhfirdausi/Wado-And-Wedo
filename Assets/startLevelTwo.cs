using UnityEngine;
using System.Collections;

public class startLevelTwo : MonoBehaviour {
	public GameManager gameManager;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Jump"))
		{
			gameManager.startLevelTwo();
		}
	}
}
