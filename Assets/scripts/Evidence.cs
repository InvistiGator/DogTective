using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Evidence : MonoBehaviour {

	private string nameOfObject;
	private string sourceOfEvidence;
	private bool hasSoundEffect;
	// Use this for initialization
	void Start () {
		nameOfObject = "testEvidence1";
		sourceOfEvidence = SceneManager.GetActiveScene().name; 
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
