using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class showWadoDeaths : MonoBehaviour {

	private Text instruction;
	public GameManager gameManager;
	// Use this for initialization
	void Start () {
		instruction = GetComponent<Text>();
		instruction.text = "WADO Deaths: " + gameManager.wadoTotDeaths;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
