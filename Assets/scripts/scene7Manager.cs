using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class scene7Manager : MonoBehaviour {
	public GameObject SceneHandlerObj;
	public SceneHandler scene7ManagerScript;
	public audio7Script audioManager;

	//various Evidence GameObjects in scene, will load base on killer
	public GameObject scuffMarks;
	public GameObject paperCoveredWithRedInk;
	public GameObject reBody;
	public GameObject paperSmearedWithChocolate;
	public GameObject veryCleanDesk;
	public GameObject grayFur;
	public GameObject blackFur;
	public GameObject pinkSlip;
	public GameObject newspaperClipping;
	public GameObject letterOpener;
	public GameObject schoolYearbook;
	public GameObject whiteFur;
	public GameObject pipe;

	public bool [] stageInThisScene;

	public int initConvoLength;
	public string [] initConvo;

	public int midConvoLength;
	public string [] midConvo;

	public int endConvoLength;
	public string [] endConvo;

	public int walkedUpToCount = 0;
	//script for script GUI stuff
	public bool displayGUI;
	public Canvas scene7CanvasObj;
	public Text displayeddialogue_Scene7 = null;

	public Canvas congratsEvidenceCanvas; 
	public Button okFromCongrats;

	public int maxEvidenceNum;

	private int i= 0; // a counter to iterater thru conversations, and set important convo indexes

	void Awake(){
		//finds the empty gameobject associated with sceneHandler
		SceneHandlerObj = GameObject.FindGameObjectWithTag("SceneHandlerM") as GameObject;
		//finds the script that is attached to the above gameobject
		scene7ManagerScript = SceneHandlerObj.GetComponent<SceneHandler>();
	}
	// Use this for initialization
	void Start () {
		scene7ManagerScript.setUserVisited(7);
		scene7ManagerScript.printCurrentKillerID();
		displayGUI = true;

		loadEvidencesBaseOnKiller();
		scene7CanvasObj = scene7CanvasObj.GetComponent<Canvas>();
		congratsEvidenceCanvas = congratsEvidenceCanvas.GetComponent<Canvas>();
		//3 different stages in this scene
		//	1-load script from 7_1_1 or _1_2
		//	2-if blood in previous evidence or not load 7_2_1 or 7_2_2
		//	3 - generic script load from 7_3 after all evidences are collected 
		stageInThisScene = new bool[3];
		for(int i=0; i<stageInThisScene.Length; i++){
			stageInThisScene[i] = false;
		}
		congratsEvidenceCanvas.enabled = false;
		setUpInitConvo();
		setUpMidConvo();
		setUpEndConvo();

		displayDialogue();
	}
	
	// Update is called once per frame
	void Update () {
		displayGUIorNah();
		if (scene7CanvasObj.enabled == true){
			Time.timeScale = 0;
		}
		if(congratsEvidenceCanvas.enabled == true){
			Time.timeScale = 0;
		}
		if(stageInThisScene[2] == true){
			SceneManager.LoadScene(8);
			Debug.Log("loading Scene 8");
		}
	}
	public void displayDialogue(){
		if(!stageInThisScene[0]){
			if(i<initConvoLength){
				displayInit();
			}
			else{
				i = 0; 
				stageInThisScene[0] = true;
				Debug.Log("I'm inside of the !stageInThisScene[0]'s else statement");
				displayMid();
			}
		}
		else if(!stageInThisScene[1]){
			if(i<midConvoLength){
				displayMid();
			}
			else{
				scene7ManagerScript.setEvidenceCollected("blood", 0);
				i = 0; 
				stageInThisScene[1] = true;
				Debug.Log("I'm inside of the !stageInThisScene[1]'s else statement");
				displayGUI = false; // turn off the GUI and let user explore the scene 
			}

		}
		else if(!stageInThisScene[2]){ //this stage of dialogue only pops up when all evidenes are collected 
			if(i<endConvoLength){
				displayEnd();
			}
			else{
				i = 0; 
				displayGUI=false;
				//displayeddialogue_Scene2.enabled = false;
				stageInThisScene[2] = true;
				Debug.Log("I'm inside of the !stageInThisScene[2]'s else statement");
			}
		}
	}

	public bool allEvidenceCollectd(){
		if(walkedUpToCount == maxEvidenceNum){
			return true;
		}
		return false;
	}

	public void displayGUIorNah(){
		if(displayGUI){
			scene7CanvasObj.enabled = true;
			Time.timeScale = 0;
		}
		else{
			scene7CanvasObj.enabled = false;
			Time.timeScale = 1;
		}
	}

	public void displayCongratsGUI(){
		congratsEvidenceCanvas.enabled = true;
		okFromCongrats.enabled = true;
		Time.timeScale = 0;    
	}

	public void onClickOk(){
		congratsEvidenceCanvas.enabled = false;
		okFromCongrats.enabled = false;
	}
	public void turnOffCongratsGUI(){
		congratsEvidenceCanvas.enabled = false;
		Time.timeScale = 1;
	}
	public void loadEvidencesBaseOnKiller(){
		//set everything to false by default;
		scuffMarks.SetActive(false);
		paperCoveredWithRedInk.SetActive(false);
		reBody.SetActive(false);
		paperSmearedWithChocolate.SetActive(false);
		veryCleanDesk.SetActive(false);
		grayFur.SetActive(false);
		blackFur.SetActive(false);
		pinkSlip.SetActive(false);
		newspaperClipping.SetActive(false);
		letterOpener.SetActive(false);
		schoolYearbook.SetActive(false);
		whiteFur.SetActive(false);
		pipe.SetActive(false);

		if(scene7ManagerScript.killerID == 0){//if Doug is killer
			//light brown hair
			schoolYearbook.SetActive(true);
			pipe.SetActive(true); 
			//maxEvidenceNum = 4;//Blood = inclusive, Body is exclusive in the calculation of maxEvidenceNum per scene
			maxEvidenceNum = 2;
		}
		else if(scene7ManagerScript.killerID == 1){//if Jade is killer
			//enable money
			schoolYearbook.SetActive(true);
			whiteFur.SetActive(true);
			maxEvidenceNum = 2;
			//maxEvidenceNum = 4;
		}
		else if(scene7ManagerScript.killerID == 2){//if Norm is killer
			newspaperClipping.SetActive(true);
			letterOpener.SetActive(true);
			maxEvidenceNum = 2;
			//maxEvidenceNum = 3;
		}
		else if(scene7ManagerScript.killerID == 3){//if Damina is killer
			//no body and long white fur
			reBody.SetActive(true);
			paperSmearedWithChocolate.SetActive(true);
			maxEvidenceNum = 2;
			//maxEvidenceNum = 4;
		}
		else if(scene7ManagerScript.killerID == 4){//if Tom is killer
			scuffMarks.SetActive(true);
			paperCoveredWithRedInk.SetActive(true);
			maxEvidenceNum = 2;
			//maxEvidenceNum = 4;
		}
		else if(scene7ManagerScript.killerID == 5){//if Goldie is killer
			//enable money
			veryCleanDesk.SetActive(true);
			grayFur.SetActive(true);
			maxEvidenceNum = 2;
			//maxEvidenceNum = 4;
		}
		else if(scene7ManagerScript.killerID == 6){//if Morgan is killer
			//enable papers from work
			blackFur.SetActive(true);
			pinkSlip.SetActive(true);
			maxEvidenceNum = 2;
			//maxEvidenceNum = 4;
		}
	}

	public void setUpInitConvo(){
		//if norm is the Culprit 
		if(scene7ManagerScript.killerID == 2){
			initConvo =  scene7ManagerScript.readFile("Assets/Dialogue/Scene7/Scene7_1_1.txt");
			initConvoLength = initConvo.Length;
			for(int i=0;i<initConvoLength;i++){
				Debug.Log(initConvo[i]);
			}
			
		}
		//if Damina is the Culprit 
		else if(scene7ManagerScript.killerID == 3){
			initConvo =  scene7ManagerScript.readFile("Assets/Dialogue/Scene7/Scene7_1_2.txt");
			initConvoLength = initConvo.Length;
			for(int i=0;i<initConvoLength;i++){
				Debug.Log(initConvo[i]);
			}
			//Debug.Log(initConvo);
		}
		//what happens if killer ID != 2||3 ？？？
		else{
			stageInThisScene[0] = true; //else skip this convo and movo to 2nd stage
			initConvoLength = 0;
			//call displayDialogue Automatically again with updated stuff
			for(int i=0;i<initConvoLength;i++){
				Debug.Log(initConvo[i]);
			}
			//displayDialogue();
		}
	}
	public void displayInit(){
		if(i<initConvoLength){
			displayeddialogue_Scene7.text = initConvo[i];
			i++;
		}
	}

	public void setUpMidConvo(){
		if(scene7ManagerScript.lookForEvidence("blood")){
			midConvo = scene7ManagerScript.readFile("Assets/Dialogue/Scene7/Scene7_2_1.txt");
			midConvoLength = midConvo.Length;
			Debug.Log(midConvo);

		}
		else{
			midConvo = scene7ManagerScript.readFile("Assets/Dialogue/Scene7/Scene7_2_2.txt");
			midConvoLength = midConvo.Length;
		}
	}
	public void displayMid(){
		if(i<midConvoLength){
			displayeddialogue_Scene7.text = midConvo[i];
			i++;
		}
	}
	public void setUpEndConvo(){
		endConvo = scene7ManagerScript.readFile("Assets/Dialogue/Scene7/Scene7_3.txt");
		endConvoLength = endConvo.Length;
		Debug.Log(endConvo);
	}
	public void displayEnd(){
		if(i<endConvoLength){
			displayeddialogue_Scene7.text = endConvo[i];
			i++;
		}
	}
}
