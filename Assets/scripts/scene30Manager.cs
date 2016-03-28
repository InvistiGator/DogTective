﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class scene30Manager : MonoBehaviour {
	public GameObject SceneHandlerObj;
	public SceneHandler scene30ManagerScript;
	public Text displayedDialogue_Scene30 =  null;
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
		scene30ManagerScript = SceneHandlerObj.GetComponent<SceneHandler>();
	}
	void Start () {
		scene30ManagerScript.setUserVisited(30);
		scene30ManagerScript.printCurrentKillerID();
		dialogue = scene30ManagerScript.readFile("Scene30.txt");
		maxDialogueLength = dialogue.Length;

		displayDialogue();
	}
	
	// Update is called once per frame
	void Update () {
		if(i==maxDialogueLength+1){
			SceneManager.LoadScene(2);
		}

	}

	
	public void displayDialogue(){
		if(i<maxDialogueLength){
			displayedDialogue_Scene30.text = dialogue[i];
			i++;
		}
		else{
			i++;
		}
				
	}

}