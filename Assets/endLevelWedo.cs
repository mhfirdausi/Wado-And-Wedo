using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class endLevelWedo : MonoBehaviour {

	private Text instruction;
	public GameManager gameManager;
	// Use this for initialization
	void Start () {
		instruction = GetComponent<Text>();
		instruction.text = "WEDO Deaths: " + gameManager.wedoTotDeaths;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
