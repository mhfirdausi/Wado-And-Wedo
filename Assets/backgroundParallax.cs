using UnityEngine;
using System.Collections;

public class backgroundParallax : MonoBehaviour {

	public GameObject player;
	public float parallaxStrength;
	private float prevPlayerPos;
	private float curPlayerPos;
	// Use this for initialization
	void Start () {
		prevPlayerPos = player.transform.position.x;
	
	}
	
	// Update is called once per frame
	void Update () {
		curPlayerPos = player.transform.position.x;
		transform.position = new Vector2((curPlayerPos - prevPlayerPos), 0);
		prevPlayerPos = curPlayerPos;
	}
}
