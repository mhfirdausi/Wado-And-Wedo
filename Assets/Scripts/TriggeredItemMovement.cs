using UnityEngine;
using System.Collections;

public class TriggeredItemMovement : MonoBehaviour {
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D(Collider2D coll) {
		Debug.Log (coll.gameObject.name + " triggered " + this.gameObject.name);
		GameObject myBall = GameObject.Find ("TestBall");
		float moveSpeed = 10f;
		Vector3 ballPosition = Camera.main.ScreenToWorldPoint(myBall.transform.position);
		myBall.transform.position = Vector2.Lerp (ballPosition, new Vector2(ballPosition.x - 10, ballPosition.y), moveSpeed * Time.smoothDeltaTime);
	}
	
	void OnTriggerExit2D(Collider2D coll) {
		Debug.Log (coll.gameObject.name + " exited " + this.gameObject.name);
		GameObject myBall = GameObject.Find ("TestBall");
		float moveSpeed = 10f;
		Vector3 ballPosition = Camera.main.ScreenToWorldPoint(myBall.transform.position);
		myBall.transform.position = Vector2.Lerp (ballPosition, new Vector2(ballPosition.x + 10, ballPosition.y), moveSpeed * Time.smoothDeltaTime);
	}
}
