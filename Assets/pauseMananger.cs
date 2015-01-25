using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class pauseMananger : MonoBehaviour {
	public GameManager gameManager;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(gameManager.isPaused)
		{
			gameObject.SetActive(true);

		}
		else
		{
			gameObject.SetActive(false);
		}
		
	}
}
