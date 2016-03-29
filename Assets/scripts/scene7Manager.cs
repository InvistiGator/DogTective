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
	public string[] initConvo;

	public int midConvoLength;
	public string[] midConvo;

	public int endConvoLength;
	public string [] endConvo;

	public int walkedUpToCount = 0;
	//script for script GUI stuff
	public bool displayGUI;
	public Canvas scene7CanvasObj;
	public Text displayeddialogue_Scene7;

	public Canvas congratsEvidenceCanvas; 
	public Button okFromCongrats;

	public int maxEvidenceNum;


	void Awake(){
		//finds the empty gameobject associated with sceneHandler
		SceneHandlerObj = GameObject.FindGameObjectWithTag("SceneHandlerM") as GameObject;
		//finds the script that is attached to the above gameobject
		scene7ManagerScript = SceneHandlerObj.GetComponent<SceneHandler>();
	}
	// Use this for initialization
	void Start () {
		loadEvidencesBaseOnKiller();
		scene7CanvasObj = scene7CanvasObj.GetComponent<Canvas>();
		congratsEvidenceCanvas = congratsEvidenceCanvas.GetComponent<Canvas>();

		//3 different stages in this scene
		//	1-load script from 7_1_1 or _1_2
		//	2-if blood in previous evidence or not load 7_2_1 or 7_2_2
		//	3 - generic script load from 7_3 after all evidences are collected 
		stageInThisScene = new bool[3]; 

		congratsEvidenceCanvas.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void displayDialogue(){
		if(!stageInThisScene[0]){
			
		}
		else if(!stageInThisScene[1]){

		}
		else if(!stageInThisScene[2]){

		}
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
}
