using UnityEngine;
using System.Collections;

public class doorTwoManager : MonoBehaviour {
	public GameManager gameManager;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider collision){
		//Debug.Log ("Collided");
		if (collision.gameObject.layer == 9)
		{
			gameManager.endScreenTwo();
		}
	}
}
