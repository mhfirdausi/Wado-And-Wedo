using UnityEngine;
using System.Collections;

public class DoorHandler : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter (Collider coll) {
		if (coll.gameObject.layer == 9) {
			Debug.Log("Wado has won!");
//			Application.LoadLevel(3);
		}
	}
}
