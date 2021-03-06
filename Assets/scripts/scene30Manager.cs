﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class scene30Manager : MonoBehaviour {
	public GameObject SceneHandlerObj;
	public SceneHandler sceneManagerScript;
	public audio30Script audioManager;
	public Text displayedDialogue =  null;
	
	private string [] dialogue_1;
	private string [] dialogue_2_1;
	private string [] dialogue_2_2;
	private string [] dialogue_3;
	private string [] dialogue_4_1;
	private string [] dialogue_4_2;

	private string [] emotion_1;
	private string [] emotion_2_1;
	private string [] emotion_2_2;
	private string [] emotion_3;
	private string [] emotion_4_1;
	private string [] emotion_4_2;

	private int dialogue_1Length;
	private int dialogue_2_1Length;
	private int dialogue_2_2Length;
	private int dialogue_3Length;
	private int dialogue_4_1Length;
	private int dialogue_4_2Length;

	private int section = 1;

	public Canvas sceneCanvas;
	public Canvas decision1Canvas;
	public Canvas decision2Canvas;

	public DougEmotionController DougEmo;
	public JadeEmotionController JadeEmo;
	public GoldieEmotionController GoldieEmo;

	private int i = 0; // a counter to iterater thru conversations, and set important convo indexes
	private int iwithEvidence;
	// Use this for initialization
	// 
	void Awake(){
		//finds the empty gameobject associated with sceneHandler
		SceneHandlerObj = GameObject.FindGameObjectWithTag("SceneHandlerM") as GameObject;
		//finds the script that is attached to the above gameobject
		sceneManagerScript = SceneHandlerObj.GetComponent<SceneHandler>();
		audioManager = audioManager.GetComponent<audio30Script>();
	}
	void Start () {
		sceneManagerScript.setUserVisited(30);
		sceneManagerScript.printCurrentKillerID();

		if (sceneManagerScript.killerID == 6){
			section = 1;
		}
		else{
			section = 3;
		}
		
		dialogue_1 = sceneManagerScript.readFile("Scene30_1.txt");
		emotion_1 = sceneManagerScript.readEmotion("30_1.txt");
		dialogue_1Length = dialogue_1.Length;

		dialogue_2_1 = sceneManagerScript.readFile("Scene30_2_1.txt");
		emotion_2_1 = sceneManagerScript.readEmotion("30_2_1.txt");
		dialogue_2_1Length = dialogue_2_1.Length;

		dialogue_2_2 = sceneManagerScript.readFile("Scene30_2_2.txt");
		emotion_2_2 = sceneManagerScript.readEmotion("30_2_2.txt");
		dialogue_2_2Length = dialogue_2_2.Length;

		dialogue_3 = sceneManagerScript.readFile("Scene30_3.txt");
		emotion_3 = sceneManagerScript.readEmotion("30_3.txt");
		dialogue_3Length = dialogue_3.Length;

		dialogue_4_1 = sceneManagerScript.readFile("Scene30_4_1.txt");
		emotion_4_1 = sceneManagerScript.readEmotion("30_4_1.txt");
		dialogue_4_1Length = dialogue_4_1.Length;

		dialogue_4_2 = sceneManagerScript.readFile("Scene30_4_2.txt");
		emotion_4_2 = sceneManagerScript.readEmotion("30_4_2.txt");
		dialogue_4_2Length = dialogue_4_2.Length;

		GoldieEmo.exit();

		displayDialogue();

		sceneCanvas = sceneCanvas.GetComponent<Canvas>(); 
		sceneCanvas.enabled = true; 
		decision1Canvas = decision1Canvas.GetComponent<Canvas>();
		decision1Canvas.enabled = false;
		decision2Canvas = decision2Canvas.GetComponent<Canvas>();
		decision2Canvas.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(section == 1 && i == dialogue_1Length+1){
			sceneCanvas.enabled = false;
			decision1Canvas.enabled = true;
		}
		else if (section == 21 && i == dialogue_2_1Length+1){
			StartCoroutine(sceneManagerScript.FadeStuff(30));
		}
		else if (section == 22 && i == dialogue_2_2Length+1){
			StartCoroutine(sceneManagerScript.FadeStuff(31));
		}
		else if (section == 3 && i == dialogue_3Length+1){
			sceneCanvas.enabled = false;
			decision2Canvas.enabled = true;
		}
		else if (section == 41 && i == dialogue_4_1Length+1){
			StartCoroutine(sceneManagerScript.FadeStuff(34));
		}
		else if (section == 42 && i == dialogue_4_2Length+1){
			StartCoroutine(sceneManagerScript.FadeStuff(35));
		}
	}

	
	public void displayDialogue(){
		if(section == 1 && i < dialogue_1Length){
			if (!emotion_1[i].Equals("z")){
				emotionCheck(emotion_1[i][0], emotion_1[i][1]);
			}

			if (i==4) {
				audioManager.playDecisionPrompt();
			}
			displayedDialogue.text = dialogue_1[i];
			i++;
		}
		else if(section == 21 && i < dialogue_2_1Length){
			if (!emotion_2_1[i].Equals("z")){
				emotionCheck(emotion_2_1[i][0], emotion_2_1[i][1]);
			}

			if (i==0) {
				audioManager.playDecisionRes();
			}
			displayedDialogue.text = dialogue_2_1[i];
			i++;
		}
		else if(section == 22 && i < dialogue_2_2Length){
			if (!emotion_2_2[i].Equals("z")){
				emotionCheck(emotion_2_2[i][0], emotion_2_2[i][1]);
			}

			if (i==0) {
				audioManager.playDecisionRes();
			}
			displayedDialogue.text = dialogue_2_2[i];
			i++;
		}
		else if(section == 3 && i < dialogue_3Length){
			if (!emotion_3[i].Equals("z")){
				emotionCheck(emotion_3[i][0], emotion_3[i][1]);
			}

			if (i==6) {
				audioManager.playDecisionPrompt();
			}
			displayedDialogue.text = dialogue_3[i];
			i++;
		}
		else if(section == 41 && i < dialogue_4_1Length){
			if (!emotion_4_1[i].Equals("z")){
				emotionCheck(emotion_4_1[i][0], emotion_4_1[i][1]);
			}

			if (i==0) {
				audioManager.playDecisionRes();
			}
			displayedDialogue.text = dialogue_4_1[i];
			i++;
		}
		else if(section == 42 && i < dialogue_4_2Length){
			if (!emotion_4_2[i].Equals("z")){
				emotionCheck(emotion_4_2[i][0], emotion_4_2[i][1]);
			}

			if (i==0) {
				audioManager.playDecisionRes();
			}
			displayedDialogue.text = dialogue_4_2[i];
			i++;
		}
		else{
			i++;
		}		
	}

	public void decision1(){
		i = 0;
		section = 21;
		displayDialogue();
		decision1Canvas.enabled = false;
		sceneCanvas.enabled = true;
	}

	public void decision2(){
		i = 0;
		section = 22;
		displayDialogue();
		decision1Canvas.enabled = false;
		sceneCanvas.enabled = true;
	}

	public void decision3(){
		i = 0;
		section = 42;
		displayDialogue();
		decision2Canvas.enabled = false;
		sceneCanvas.enabled = true;
	}

	public void decision4(){
		i = 0;
		section = 41;
		displayDialogue();
		decision2Canvas.enabled = false;
		sceneCanvas.enabled = true;
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
		else if (who.Equals('g')){
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
		else if (who.Equals('a')){
			DougEmo.exit();
			JadeEmo.exit();
			GoldieEmo.exit();
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
