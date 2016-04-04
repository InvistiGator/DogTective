using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class scene12Manager : MonoBehaviour {
	public GameObject SceneHandlerObj;
	public SceneHandler scene12ManagerScript;
	public audio12Script audioManager;
	public Text displayedDialogue_Scene12 =  null;
	private string [] dialogue; 
	private int i= 0; // a counter to iterater thru conversations, and set important convo indexes
	private int iwithEvidence;
	private int maxDialogueLength;  // defines the length of the dialogue in this scene
	// Use this for initialization
	// 
	void Awake(){
		//finds the empty gameobject associated with sceneHandler
		SceneHandlerObj = GameObject.FindGameObjectWithTag("SceneHandlerM") as GameObject;
		//finds the script that is attached to the above gameobject
		scene12ManagerScript = SceneHandlerObj.GetComponent<SceneHandler>();
		audioManager = audioManager.GetComponent<audio12Script>();
	}
	void Start () {
		scene12ManagerScript.setUserVisited(12);
		scene12ManagerScript.printCurrentKillerID();
		dialogue = scene12ManagerScript.readFile("Scene12.txt");
		maxDialogueLength = dialogue.Length;

		displayDialogue();
	}
	
	// Update is called once per frame
	void Update () {
		if(i==maxDialogueLength+1){
			scene12ManagerScript.setEvidenceCollected("TomsSecretPassage", 24);
			SceneManager.LoadScene(9);
		}

	}

	
	public void displayDialogue(){
		if(i<maxDialogueLength){
			if (i==33) {
				audioManager.playFootsteps();
			}
			displayedDialogue_Scene12.text = dialogue[i];
			i++;
		}
		else{
			i++;
		}
				
	}

}
