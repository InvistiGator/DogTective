﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class scene3Manager : MonoBehaviour {
//private scene2Manager: SceneHandler;
	public GameObject SceneHandlerObj;
	public SceneHandler sceneManagerScript;
	public audio3Script audioManager;
	public Text displayedDialogue_Scene3 =  null;
	public Canvas scene3Canvas;
	public Canvas decisionCanvas;
	private string [] dialogue_1;
	private string [] dialogue_2_1;
	private string [] dialogue_2_2;

	private string [] emotion_1;
	private string [] emotion_2_1;
	private string [] emotion_2_2;

	private int i= 0; // a counter to iterater thru conversations, and set important convo indexes
	private int iwithEvidence;
	private int dialogue_1Length;
	private int dialogue_2_1Length;
	private int dialogue_2_2Length;

	private int section = 1;

	public DougEmotionController DougEmo;
	public GoldieEmotionController GoldieEmo;

	// Use this for initialization
	// 
	void Awake(){
		//finds the empty gameobject associated with sceneHandler
		SceneHandlerObj = GameObject.FindGameObjectWithTag("SceneHandlerM") as GameObject;
		//finds the script that is attached to the above gameobject
		sceneManagerScript = SceneHandlerObj.GetComponent<SceneHandler>();
		audioManager = audioManager.GetComponent<audio3Script>();
	}
	void Start () {
		sceneManagerScript.setUserVisited(3);
		sceneManagerScript.printCurrentKillerID();
		iwithEvidence = 0;		
		//set up dialogue needed for this scene
		
		dialogue_1 = sceneManagerScript.readFile("Scene3_1.txt");
		emotion_1 = sceneManagerScript.readEmotion("3_1.txt");
		dialogue_1Length = dialogue_1.Length;

		dialogue_2_1 = sceneManagerScript.readFile("Scene3_2_1.txt");
		emotion_2_1 = sceneManagerScript.readEmotion("3_2_1.txt");
		dialogue_2_1Length = dialogue_2_1.Length;

		dialogue_2_2 = sceneManagerScript.readFile("Scene3_2_2.txt");
		emotion_2_2 = sceneManagerScript.readEmotion("3_2_2.txt");
		dialogue_2_2Length = dialogue_2_2.Length;

		GoldieEmo.exit();

		displayDialogue();
		
		//disable GUI at beginning 

		scene3Canvas = scene3Canvas.GetComponent<Canvas> (); 
		scene3Canvas.enabled = true; 
		decisionCanvas = decisionCanvas.GetComponent<Canvas>();
		decisionCanvas.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		//if counter reached the max dialogue length, move onto next scene
		if(section == 1 && i == dialogue_1Length+1){
			/*if before this scene something already visited somewhere direct as needed
			if(sceneManagerScript.userVisited[2]){
				StartCoroutine(sceneManagerScript.FadeStuff(4));
				Debug.Log("Current SceneInstance.userVisited[3]:  ");
				Debug.Log(sceneManagerScript.userVisited[3]);

			}*/
			if (sceneManagerScript.userVisited[4]){
				section = 21;
				i = 0;
				displayDialogue();
			}
			else{
				scene3Canvas.enabled = false;
				decisionCanvas.enabled = true;
			}
		}
		else if (section == 21 && i == dialogue_2_1Length+1 && !sceneManagerScript.userVisited[4]){
			StartCoroutine(sceneManagerScript.FadeStuff(4));
		}
		else if (section == 21 && i == dialogue_2_1Length+1 && sceneManagerScript.userVisited[4]){
			StartCoroutine(sceneManagerScript.FadeStuff(5));
		}
		else if (section == 22 && i == dialogue_2_2Length+1){
			StartCoroutine(sceneManagerScript.FadeStuff(5));
		}
	}

	public void stayHere(){
		i = 0;
		section = 22;
		displayDialogue();
		decisionCanvas.enabled = false;
		scene3Canvas.enabled = true;
	}

	public void goAway(){
		i = 0;
		section = 21;
		displayDialogue();
		decisionCanvas.enabled = false;
		scene3Canvas.enabled = true;
	}

	public void displayDialogue(){
		if(section == 1 && i < dialogue_1Length){
			if (!emotion_1[i].Equals("z")){
				emotionCheck(emotion_1[i][0], emotion_1[i][1]);
			}

			if (i == 5) {
				audioManager.playDoorKnock();
			} else if (i == 8) {
				audioManager.playDoorOpen();
			} else if (i == 19) {
				audioManager.playDecisionPrompt();
			} else if (i==21) {
				audioManager.playDecisionResolution();
			}
			displayedDialogue_Scene3.text = dialogue_1[i];
			i++;
		}
		else if (section == 21 && i < dialogue_2_1Length){
			if (!emotion_2_1[i].Equals("z")){
				emotionCheck(emotion_2_1[i][0], emotion_2_1[i][1]);
			}

			if (i==2) {
				audioManager.playDoorClose();
			}
			displayedDialogue_Scene3.text = dialogue_2_1[i];
			i++;
		}
		else if (section == 22 && i < dialogue_2_2Length){
			Debug.Log(i);
			Debug.Log(emotion_2_2[i]);
			if (!emotion_2_2[i].Equals("z")){
				emotionCheck(emotion_2_2[i][0], emotion_2_2[i][1]);
			}

			if (i == 11) {
				audioManager.playDoorClose();
			}
			displayedDialogue_Scene3.text = dialogue_2_2[i];
			i++;
		}
		else{
			i++;
		}	
	}

		public void emotionCheck(char who, char what){
		if (who.Equals('g')){
			if (what == 'h'){
				GoldieEmo.isHappy();
			}
			else if (what == 'g'){
				GoldieEmo.isAngry();
			}
			else if (what == 's'){
				GoldieEmo.isSad();
			}
			else if (what == 'a'){
				GoldieEmo.isAwk();
			}
			else if (what == 'u'){
				GoldieEmo.isSurprised();
			}
			else if (what == 'o'){
				GoldieEmo.isAnnoyed();
			}
			else if (what == 'e'){
				GoldieEmo.enter();
			}
			else if (what == 'x'){
				GoldieEmo.exit();
			}
			else{
				GoldieEmo.isIdle();
			}
		}
		else{
			//doug
			if (what == 'h'){
				DougEmo.isHappy();
			}
			else if (what == 'g'){
				DougEmo.isAngry();
			}
			else if (what == 's'){
				DougEmo.isSad();
			}
			else if (what == 'a'){
				DougEmo.isAwk();
			}
			else if (what == 'u'){
				DougEmo.isSurprised();
			}
			else if (what == 'o'){
				DougEmo.isAnnoyed();
			}
			else if (what == 'e'){
				DougEmo.enter();
			}
			else if (what == 'x'){
				DougEmo.exit();
			}
			else{
				DougEmo.isIdle();
			}
		}
	}
}
