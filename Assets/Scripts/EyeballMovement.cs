using UnityEngine;
using System.Collections;

public class EyeballMovement : MonoBehaviour {
	private Vector3 mousePosition;
	public GameManager gameManager;
	public float moveSpeed = .5f;
	public bool gameStarted = true;
	public AudioClip boopClip;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		moveSpeed = 10f;
		mousePosition = Input.mousePosition;
		mousePosition = Camera.main.ScreenToWorldPoint (mousePosition);
		transform.position = Vector2.Lerp (transform.position, mousePosition, moveSpeed * Time.smoothDeltaTime);

//		Quaternion rot = Quaternion.LookRotation (transform.position - mousePosition, Vector3.forward);
//		rot *= Quaternion.Euler (0, 0, 90);
//
		if ((transform.position.x - mousePosition.x) > 0) {
			transform.localScale = new Vector3 (.75f, .75f, .75f);
		}
		if ((transform.position.x - mousePosition.x) < 0){
			transform.localScale = new Vector3(-.75f, .75f, .75f);
		}
//		if ((transform.position.x == mousePosition.x) && (transform.position.y == mousePosition.y)) {
//			rigidbody2D.velocity = Vector3.zero;
//			rigidbody2D.angularVelocity = 0f;
//		}
//		//transform.rotation = rot;
//		transform.eulerAngles = new Vector3 (0, 0, transform.eulerAngles.z);
//		rigidbody2D.AddForce (gameObject.transform.right * moveSpeed);
	}
	/*
	 * Hit deadly object: everyone dies
	 * Hit smashable wall: play animation to destroy the wall
	 */
	void OnTriggerEnter(Collider coll) 
	{
		//Debug.Log ("Hit "+ coll.gameObject.tag);
		if ((coll.gameObject.layer == 8 || coll.gameObject.layer == 10 || coll.gameObject.layer == 13) && gameStarted != false) {
			gameManager.callDeath();
			gameManager.wedoDeaths++;
		}

		if (coll.gameObject.layer == 14) {
			gameStarted = true;
		}
		else if (coll.gameObject.layer == 12) {
			Destroy (coll.gameObject);
			audio.PlayOneShot(boopClip);
		}
		else if(coll.gameObject.layer == 15)
		{
				gameManager.coinCollect();
				Destroy(coll.gameObject);
		}
	}

//	void OnTriggerEntered2D(Collider2D coll) {
//		Debug.Log ("Triggered " + coll.gameObject.name);
//	}
}
