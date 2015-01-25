using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class wadoScoreUpdate : MonoBehaviour {
	private Text instruction;
	private int prevDeaths;
	private int curDeaths;
	public GameManager gameManager;
	// Use this for initialization
	void Start () {
		instruction = GetComponent<Text>();
		instruction.text = "WADO Deaths: " + gameManager.wadoDeaths;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
