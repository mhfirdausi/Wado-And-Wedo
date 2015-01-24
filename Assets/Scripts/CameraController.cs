using UnityEngine;
using System.Collections;

public class CameraController: MonoBehaviour {
	public float distanceBehindPlayer;
	public float distanceAbovePlayer;
	public GameObject player;
	// Use this for initialization
	void Start () {
		transform.position = new Vector3 (player.transform.position.x + distanceBehindPlayer , player.transform.position.y + distanceAbovePlayer, -10);
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (player.transform.position.x + distanceBehindPlayer , transform.position.y, -10);
	
	}
}
