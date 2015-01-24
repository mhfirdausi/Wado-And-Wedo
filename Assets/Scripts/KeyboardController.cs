using UnityEngine;
using System.Collections;

public class KeyboardController : MonoBehaviour {
	public float speed = 5.0f;
	public float gravity = 2f;
	public float cutJumpSpeedLimit = 10f;
	private bool onGround = false;
	private int m_TerrainLayer;
	//private Vector2 amtToMove;

	
	void Start () 
	{
		float cutJumpSpeed = gravity / cutJumpSpeedLimit;
		m_TerrainLayer = LayerMask.NameToLayer("Terrain");
	
	}
	
	// Update is called once per frame
	void Update () 
	{	
		//Constant movement right
		transform.Translate (Vector2.right * speed * Time.deltaTime);
		//Gravity Logic
		if (onGround == false) 
		{
			transform.Translate (-Vector2.up * gravity * Time.deltaTime);
		}
		//jump logic

	}
	void OnCollisionrEnter2D(Collider2D coll)
	{
		//Controls 
		if (coll.gameObject.layer == m_TerrainLayer)
		{
			Debug.Log("Touching Ground");
			onGround = true;
			transform.Translate(Vector2.up * 0);
		}
	}
}
