﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class scene37Manager : MonoBehaviour {
	public GameObject SceneHandlerObj;
	public SceneHandler sceneManagerScript;
	public audio37Script audioManager;
	public Text displayedDialogue =  null;
	
	private string [] dialogue_1;
	private string [] dialogue_2;
	private string [] dialogue_3;
	private string [] dialogue_4;

	private string [] emotion_1;
	private string [] emotion_2;
	private string [] emotion_3;
	private string [] emotion_4;

	private int dialogue_1Length;
	private int dialogue_2Length;
	private int dialogue_3Length;
	private int dialogue_4Length;

	private int section = 1;

	public DougEmotionController DougEmo;
	public JadeEmotionController JadeEmo;

	public Canvas sceneCanvas;
	public Canvas decision1Canvas;

	private int i = 0; // a counter to iterater thru conversations, and set important convo indexes
	private int iwithEvidence;
	// Use this for initialization
	// 
	void Awake(){
		//finds the empty gameobject associated with sceneHandler
		SceneHandlerObj = GameObject.FindGameObjectWithTag("SceneHandlerM") as GameObject;
		//finds the script that is attached to the above gameobject
		sceneManagerScript = SceneHandlerObj.GetComponent<SceneHandler>();
		audioManager = audioManager.GetComponent<audio37Script>();
	}
	void Start () {
		sceneManagerScript.setUserVisited(37);
		sceneManagerScript.printCurrentKillerID();
		
		dialogue_1 = sceneManagerScript.readFile("Scene37_1.txt");
		emotion_1 = sceneManagerScript.readEmotion("37_1.txt");
		dialogue_1Length = dialogue_1.Length;

		dialogue_2 = sceneManagerScript.readFile("Scene37_2.txt");
		emotion_2 = sceneManagerScript.readEmotion("37_2.txt");
		dialogue_2Length = dialogue_2.Length;

		dialogue_3 = sceneManagerScript.readFile("Scene37_3.txt");
		emotion_3 = sceneManagerScript.readEmotion("37_3.txt");
		dialogue_3Length = dialogue_3.Length;

		dialogue_4 = sceneManagerScript.readFile("Scene37_4.txt");
		emotion_4 = sceneManagerScript.readEmotion("37_4.txt");
		dialogue_4Length = dialogue_4.Length;

		displayDialogue();

		sceneCanvas = sceneCanvas.GetComponent<Canvas>(); 
		sceneCanvas.enabled = true; 
		decision1Canvas = decision1Canvas.GetComponent<Canvas>();
		decision1Canvas.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(section == 1 && i == dialogue_1Length+1){
			sceneManagerScript.setEvidenceCollected("NormsClassesWithDoug", 28);

			i = 0;

			if (!sceneManagerScript.userVisited[38]){
				section = 2;
				displayDialogue();
			}
			else{
				section = 4;
				displayDialogue();
			}
		}
		else if (section == 2 && i == dialogue_2Length+1){
			sceneCanvas.enabled = false;
			decision1Canvas.enabled = true;
		}
		else if (section == 3 && i == dialogue_3Length+1){
			StartCoroutine(sceneManagerScript.FadeStuff(9));
		}
		else if (section == 4 && i == dialogue_4Length+1){
			StartCoroutine(sceneManagerScript.FadeStuff(9));
		}
	}

	
	public void displayDialogue(){
		if(section == 1 && i < dialogue_1Length){
			if (!emotion_1[i].Equals("z")){
				emotionCheck(emotion_1[i][0], emotion_1[i][1]);
			}

			if (i==9){
				audioManager.playTicking();
			}
			displayedDialogue.text = dialogue_1[i];
			i++;
		}
		else if(section == 2 && i < dialogue_2Length){
			if (!emotion_2[i].Equals("z")){
				emotionCheck(emotion_2[i][0], emotion_2[i][1]);
			}

			if (i==0) {
				audioManager.playDecisionPrompt();
			}
			displayedDialogue.text = dialogue_2[i];
			i++;
		}
		else if(section == 3 && i < dialogue_3Length){
			if (!emotion_3[i].Equals("z")){
				emotionCheck(emotion_3[i][0], emotion_3[i][1]);
			}

			displayedDialogue.text = dialogue_3[i];
			i++;
		}
		else if(section == 4 && i < dialogue_4Length){
			if (!emotion_4[i].Equals("z")){
				emotionCheck(emotion_4[i][0], emotion_4[i][1]);
			}

			displayedDialogue.text = dialogue_4[i];
			i++;
		}
		else{
			i++;
		}		
	}

	public void decision1(){
		audioManager.playDecisionRes();
		StartCoroutine(sceneManagerScript.FadeStuff(38));
	}

	public void decision2(){
		audioManager.playDecisionRes();
		i = 0;
		section = 3;
		displayDialogue();
		sceneCanvas.enabled = true;
		decision1Canvas.enabled = false;
	}

	public void emotionCheck(char who, char what){
		if (who.Equals('j')){
			if (what == 'h'){
				JadeEmo.isHappy();
			}
			else if (what == 'g'){
				JadeEmo.isAngry();
			}
			else if (what == 's'){
				JadeEmo.isSad();
			}
			else if (what == 'a'){
				JadeEmo.isAwk();
			}
			else if (what == 'u'){
				JadeEmo.isSurprised();
			}
			else if (what == 'o'){
				JadeEmo.isAnnoyed();
			}
			else if (what == 'e'){
				JadeEmo.enter();
			}
			else if (what == 'x'){
				JadeEmo.exit();
			}
			else{
				JadeEmo.isIdle();
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
