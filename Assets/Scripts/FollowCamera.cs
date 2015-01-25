using UnityEngine;
using System.Collections;

public class FollowCamera : MonoBehaviour {

	public GameObject camera;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (camera.transform.position.x, transform.position.y, 0);
	
	}
}
