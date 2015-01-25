using UnityEngine;
using System.Collections;

public class TriggeredItemMovement : MonoBehaviour {
	// Use this for initialization
	
	public AudioClip Blop;
	public AudioClip Jump;
	
	private AudioSource source;
	
	void Awake () {
		source = GetComponent<AudioSource> ();
	}
	
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D(Collider2D coll) {
		Debug.Log (coll.gameObject.name + " triggered " + this.gameObject.name);
		AudioSource.PlayClipAtPoint(Blop, transform.position);
	}
	
	void OnTriggerExit2D(Collider2D coll) {
		Debug.Log (coll.gameObject.name + " exited " + this.gameObject.name);
		AudioSource.PlayClipAtPoint(Jump, transform.position);
	}
}
