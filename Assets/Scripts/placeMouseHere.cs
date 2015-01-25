using UnityEngine;
using System.Collections;

public class placeMouseHere : MonoBehaviour {

	public PlayerController player;
	public EyeballMovement eyeball;
	public bool isPuzzle = false;
	private bool isEntered = false;
	
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider coll)
	{
		//Debug.Log("Entered");
		isEntered = true;
		StartCoroutine("waitForMouse");
		
	}
	void OnTriggerExit(Collider coll)
	{
		//Debug.Log ("Exited");
		isEntered = false;
	}
	IEnumerator waitForMouse()
	{
		yield return new WaitForSeconds(1);
		//Debug.Log ("Yield: " + isEntered);
		if(isEntered == true)
		{
			if(!isPuzzle)
			{
				player.startPlatformer();
			}
			else
			{
				player.startPuzzle();
			}
		}
	}
}
