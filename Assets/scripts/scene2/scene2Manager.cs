using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class scene2Manager : MonoBehaviour {
//private scene2Manager: SceneHandler;
	public GameObject SceneHandlerObj;
	public SceneHandler scene2ManagerScript;
	public audio2Script audioManager;

	//various Evidence GameObjects in scene, will load base on killer
	public GameObject bodyObject;
	//public GameObject blood;
	public GameObject redPen;
	public GameObject candyWrapper;
	//public GameObject noBody;
	public GameObject shortWhiteFur;
	public GameObject longWhiteFur;
	public GameObject money;
	public GameObject papersFromWork;
	public GameObject lightBrownFur;

	public bool [] stageInThisScene;
	public int walkedUpToCount = 0;
	//script for script GUI stuff
	public bool displayGUI;
	public Canvas scene2CanvasObj;
	public Text displayeddialogue_Scene2;

	public Canvas congratsEvidenceCanvas; 
	public Button okFromCongrats;
	//public Text congratsText;

	public Canvas bloodCanvasObj;
	public Button touchBloodButt;
	public Button noTouchBloodButt;

	public int maxEvidenceNum;
	//diff versions of the dialogues
	//
	private int maxdialogueInitLength = 8;  // defines the length of the dialogueInit in this scene
	private string [] dialogueInit; 
	// versions of mid convo
	
	private int maxMidDialogueLength;
	private string [] dialogue2_1;
	//private string [] dialogue2_2;

	//versions of blood-mid convo
	private int maxInitBloodLength;
	private string [] dialogue3_1;

	private int maxBloodDialogueLength;
	private string [] dialogue3_2;

	private int maxEvidenceDialogue;
	private string [] dialogue4_1;
	//last convo
	private int maxEndDialogueLength;
	private string [] dialogueEnd;


	private int i= 0; // a counter to iterater thru conversations, and set important convo indexes
	// Use this for initialization
	void Awake(){
		//finds the empty gameobject associated with sceneHandler
		SceneHandlerObj = GameObject.FindGameObjectWithTag("SceneHandlerM") as GameObject;
		//finds the script that is attached to the above gameobject
		scene2ManagerScript = SceneHandlerObj.GetComponent<SceneHandler>();

		scene2ManagerScript.fader = false;

		audioManager = audioManager.GetComponent<audio2Script>();
		//bodyObject = GameObject.FindGameObject("Body").gameObject.GetComponent<GameObject> as GameObject;

	}
	void Start () {
		displayGUI = true;
		scene2ManagerScript.setUserVisited(2);
		scene2ManagerScript.printCurrentKillerID();

		loadEvidencesBaseOnKiller();

		stageInThisScene = new bool[6];			//there are 6 different stages that can determine how dialogues changes
		for(int i=0; i<stageInThisScene.Length; i++){
			stageInThisScene[i] = false;
		}
		scene2CanvasObj = scene2CanvasObj.GetComponent<Canvas>();
		//touchBloodButt = touchBloodButt.GetComponent<Button>();
		//noTouchBloodButt = noTouchBloodButt.GetComponent<Button();
		bloodCanvasObj = bloodCanvasObj.GetComponent<Canvas>();

		congratsEvidenceCanvas = congratsEvidenceCanvas.GetComponent<Canvas>();

		congratsEvidenceCanvas.enabled = false;
		okFromCongrats.enabled = false;
		bloodCanvasObj.enabled = false;
		touchBloodButt.enabled = false;
		noTouchBloodButt.enabled = false;

		//displayeddialogue_Scene2 = displayeddialogue_Scene2.GetComponent<Text>();
		setUpInitScript();
		setUpMidScript();
		setUpBloodInitScript();
		setUpEndScript();
	}
	
	// Update is called once per frame
	void Update () {
		displayGUIorNah();

		if (bloodCanvasObj.enabled == true){
			Time.timeScale = 0;
		}
		if(congratsEvidenceCanvas.enabled == true){
			Time.timeScale = 0;
		}
	/*
		if(allEvidenceCollectd() && stageInThisScene[3]){
            displayDialogue();
            displayGUI=true;
            Debug.Log("I'm inside of allEvidenceCollectd() if statment in Updat");
		}
	*/
		//if counter reached the max dialogueInit length, move onto next scene
		
		if(stageInThisScene[5] && lookForEvidence("blood")){
			scene2ManagerScript.fader = true;
			SceneManager.LoadScene(3);
			Debug.Log("loading scene3 bc blood touched");
		}
		else if(stageInThisScene[5]){
			scene2ManagerScript.fader = true;
			SceneManager.LoadScene(4);
			Debug.Log("loading scene4 bc blood not Touched");
		}
		
	}

	public void displayGUIorNah(){
		if(displayGUI){
			scene2CanvasObj.enabled = true;
			Time.timeScale = 0;
			//displayeddialogue_Scene2.enabled = true;
		}
		else{
			scene2CanvasObj.enabled = false;
			Time.timeScale = 1;
			//displayeddialogue_Scene2.enabled = false;
		}
	}
	public void loadEvidencesBaseOnKiller(){
		showBodyOrNah();
		//these evidences are enabled no matter what
		//load basic evidences (red pen and candy wrapper)
		//
		//
		//blood.SetActive(true);
		redPen.SetActive(true);
		candyWrapper.SetActive(true);

		
		//noBody.SetActive(false);
		shortWhiteFur.SetActive(false);
		longWhiteFur.SetActive(false);
		money.SetActive(false);
		papersFromWork.SetActive(false);
		lightBrownFur.SetActive(false);

		if(scene2ManagerScript.killerID == 0){//if Doug is killer
			//light brown hair
			lightBrownFur.SetActive(true); 
			//maxEvidenceNum = 4;//Blood = inclusive, Body is exclusive in the calculation of maxEvidenceNum per scene
			maxEvidenceNum = 3;
		}
		else if(scene2ManagerScript.killerID == 1){//if Jade is killer
			//enable money
			money.SetActive(true);
			maxEvidenceNum = 3;
			//maxEvidenceNum = 4;
		}
		else if(scene2ManagerScript.killerID == 2){//if Norm is killer
			//no additional other than the body
			maxEvidenceNum = 2;
			//maxEvidenceNum = 3;
		}
		else if(scene2ManagerScript.killerID == 3){//if Damina is killer
			//no body and long white fur
			longWhiteFur.SetActive(true);
			maxEvidenceNum = 3;
			//maxEvidenceNum = 4;
		}
		else if(scene2ManagerScript.killerID == 4){//if Tom is killer
			//enable white fur
			shortWhiteFur.SetActive(true);
			maxEvidenceNum = 3;
			//maxEvidenceNum = 4;
		}
		else if(scene2ManagerScript.killerID == 5){//if Goldie is killer
			//enable money
			money.SetActive(true);
			maxEvidenceNum = 3;
			//maxEvidenceNum = 4;
		}
		else if(scene2ManagerScript.killerID == 6){//if Morgan is killer
			//enable papers from work
			papersFromWork.SetActive(true);
			maxEvidenceNum = 3;
			//maxEvidenceNum = 4;
		}
	}
	public void showBodyOrNah(){
		if(scene2ManagerScript.killerID == 2 || scene2ManagerScript.killerID == 3 ){
			bodyObject.SetActive(false);
			//No body, set no body as an evidence
			scene2ManagerScript.setEvidenceCollected3D("noBody");
		}
		else{
			bodyObject.SetActive(true);
		}
	}

	public bool lookForEvidence(string evidence_){
		for(int i=0; i< scene2ManagerScript.CollectedEvidenceString.Length; i++){
			if(scene2ManagerScript.CollectedEvidenceString[i] == evidence_){
				return true;
			}
		}

		return false;
	}

	public void displayDialogue(){
		if(!stageInThisScene[0]){
			if(i<maxdialogueInitLength){
				//i++;
				displaydialogueInit();
			}
			else{
				//reset temp stuff//
				i = 0; 
				//displayGUI=false;
				//displayeddialogue_Scene2.enabled = false;
				//displayeddialogue_Scene2.text = "*Sniff*  Sniff*"; 
				stageInThisScene[0] = true;
				Debug.Log("I'm inside of the !stageInThisScene[0]'s else statement");
				displaydialogueMid();
			}
		}

		else if(!stageInThisScene[1]){
			if(i<maxMidDialogueLength){
				//i++;
				displaydialogueMid();
			}
			else{
				//reset temp stuff//
				i = 0;
				displayGUI = true; //sending users straight to blood convo
				//displayGUI=false;
				//displayeddialogue_Scene2.enabled = false;
				stageInThisScene[1] = true;
				Debug.Log("I'm inside of the !stageInThisScene[1]'s else statement");
				displayInitBlood();
			}
		}
		else if(!stageInThisScene[2]){
			if(i<maxInitBloodLength){
				//i++;
				Debug.Log("i counter inside stage[2]: " + i);
				displayInitBlood();
			}
			else{
				//reset temp stuff//
				i = 0; 
				displayGUI=false;

				bloodCanvasObj.enabled = true;
				touchBloodButt.enabled = true;
				noTouchBloodButt.enabled = true;

				//displayeddialogue_Scene2.enabled = false;
				stageInThisScene[2] = true;
				decideToTouchBlood();
				Debug.Log("I'm inside of the !stageInThisScene[2]'s else statement");
			}
		}
		else if(!stageInThisScene[3]){	
				bloodCanvasObj.enabled = false;
				touchBloodButt.enabled = false;
				noTouchBloodButt.enabled = false;

			if(i<maxBloodDialogueLength){
				//i++;
			
				displaydialogueBlood();
			}
			else{
				//reset temp stuff//
		
				i = 0; 
				//displayeddialogue_Scene2.enabled = false;
				stageInThisScene[3] = true;
				if(allEvidenceCollectd()){
					Debug.Log("allEvidenceCollectd: " + allEvidenceCollectd());
					displayGUI=true;
					//displayDialogue();
				}
				else{
					displayGUI=false;
				}
				Debug.Log("I'm inside of the !stageInThisScene[3]'s else statement");
			}
		}
		else if(!stageInThisScene[4]){
			//displayGUI = true;
			setUpEvidenceScript();
			//inside of you've collected all the evidence
			if(i<maxEvidenceDialogue){
				//i++;
				displayEvidenceDialogue();
			}
			else{
				//reset temp stuff//
				i = 0; 
				//displayGUI=false;
				//displayeddialogue_Scene2.enabled = false;
				stageInThisScene[4] = true;
				displaydialogueEnd();
				Debug.Log("I'm inside of the !stageInThisScene[4]'s else statement");
			}
		}

		else if(!stageInThisScene[5]){
			if(i<maxEndDialogueLength){
				//i++;
				displaydialogueEnd();
			}
			else{
				//reset temp stuff//
				i = 0; 
				displayGUI=false;
				//displayeddialogue_Scene2.enabled = false;
				stageInThisScene[5] = true;
				Debug.Log("I'm inside of the !stageInThisScene[5]'s else statement");
			}
		}
		
	}

	public bool allEvidenceCollectd(){
		if(walkedUpToCount == maxEvidenceNum){
			return true;
		}
		return false;
	}

	public void displayCongratsGUI(){
		congratsEvidenceCanvas.enabled = true;
		okFromCongrats.enabled = true;    
	}

	public void onClickOk(){
		congratsEvidenceCanvas.enabled = false;
		okFromCongrats.enabled = false;
	}

	public void turnOffCongratsGUI(){
		congratsEvidenceCanvas.enabled = false;
	}
	///===============Set Up different variations of GUI ========================///

	public void setUpInitScript(){
		dialogueInit = scene2ManagerScript.readFile("Scene2_1.txt");
		displayeddialogue_Scene2.text = dialogueInit[i];
		i++;
	}

	public void setUpMidScript(){
		if(!(scene2ManagerScript.killerID == 2 || scene2ManagerScript.killerID == 3) ){
			maxMidDialogueLength = 5;
			dialogue2_1 = scene2ManagerScript.readFile("Scene2_2_1.txt");

		}
		else{
			maxMidDialogueLength = 9;
			dialogue2_1 = scene2ManagerScript.readFile("Scene2_2_2.txt");
		}
	}
	public void setUpBloodInitScript(){
		maxInitBloodLength = 9;
		dialogue3_1 = scene2ManagerScript.readFile("Scene2_3_1.txt");

	}
	public void setUpEvidenceScript(){
		if(lookForEvidence("blood")){
			maxEvidenceDialogue = 20;
			dialogue4_1 = scene2ManagerScript.readFile("Scene2_4_1.txt");
		}
		else{
			maxEvidenceDialogue = 18;
			dialogue4_1 = scene2ManagerScript.readFile("Scene2_4_2.txt");
		}
	}
	public void setUpEndScript(){
		maxEndDialogueLength = 12;
		dialogueEnd = scene2ManagerScript.readFile("Scene2_5.txt");

	}

	public void displaydialogueInit(){
		if(i<maxdialogueInitLength){
			displayeddialogue_Scene2.text = dialogueInit[i];
			i++;
		}
	}
	public void displaydialogueMid(){
		if(i<maxMidDialogueLength){
			displayeddialogue_Scene2.text = dialogue2_1[i];
			i++;
		}
	}
	public void displayInitBlood(){
		if(i<maxInitBloodLength){
			Debug.Log("i counter right before disply init blood: " + i);
			displayeddialogue_Scene2.text = dialogue3_1[i];
			i++;
		}
	}
	public void displayEvidenceDialogue(){
		if(i<maxEvidenceDialogue){
			displayeddialogue_Scene2.text = dialogue4_1[i];
			i++;
		}
	}
	public void displaydialogueEnd(){
		if(i<maxEndDialogueLength){
			if(i==2){ //keyframe to cue phone vibration
				audioManager.playPhoneVibration();
			}
			displayeddialogue_Scene2.text = dialogueEnd[i];
			i++;
		}
	}
	public void decideToTouchBlood(){
		//enable Blood GUI stuff;
		audioManager.playDecisionPrompt();	
		bloodCanvasObj.enabled = true;
		touchBloodButt.enabled = true;
		noTouchBloodButt.enabled = true;
	}
	public void touchBlood(){
		audioManager.playDecisionRes();
		bloodCanvasObj.enabled = false;
		touchBloodButt.enabled = false;
		noTouchBloodButt.enabled = false;
		//the button associated with touching blood
		//set up everything
		//person decided to touch blood. Add this to their evidence inventory. 
		scene2ManagerScript.setEvidenceCollected3D("blood");
		//[Audio: Blood's event sound]
	/*			
	//Randomization: If Norm or Damina is the culprit:
	Doug:  But with no blood and no body… was there even a murder at all?

 */
		if(scene2ManagerScript.killerID==2||scene2ManagerScript.killerID==3){
			maxBloodDialogueLength = 29;
			setUpTouchBlood();

			string [] tempDialogue = new string[maxBloodDialogueLength];
			for (int j = 0; j < 28; j++){
				tempDialogue[j] = dialogue3_2[j];
			}
			tempDialogue[28] = "Doug: But with no blood and no body… was there even a murder at all?"; 
			dialogue3_2 = tempDialogue;
		}
		else{
			maxBloodDialogueLength = 28;
			setUpTouchBlood();
		}	
	
		int i=0;//reset i to 0 just incase, counter has some random memory stored in it. 
		if(i<maxBloodDialogueLength){
			displayGUI=true;
			displaydialogueBlood();
		}
	}

	public void setUpTouchBlood(){
		dialogue3_2 = scene2ManagerScript.readFile("Scene2_3_2.txt");
	}
	public void notToTouchBlood(){
		//button associated with NOT touching blood
		audioManager.playDecisionRes();

		bloodCanvasObj.enabled = false;
		touchBloodButt.enabled = false;
		noTouchBloodButt.enabled = false;

		maxBloodDialogueLength = 3;
		dialogue3_2 = scene2ManagerScript.readFile("Scene2_3_3.txt");

		int i=0;//reset i to 0 just incase, counter has some random memory stored in it. 
		if(i<maxBloodDialogueLength){
			displayGUI=true;
			displaydialogueBlood();
		}
	}
	public void displaydialogueBlood(){
		if(i<maxBloodDialogueLength){
			displayeddialogue_Scene2.text = dialogue3_2[i];
			i++;
		}
	}
}
