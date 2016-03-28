using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class scene7Manager : MonoBehaviour {
	public GameObject SceneHandlerObj;
	public SceneHandler scene2ManagerScript;
	public audio2Script audioManager;

	//various Evidence GameObjects in scene, will load base on killer
	public GameObject scuffMarks;
	//public GameObject blood;
	public GameObject paperCoveredWithRedInk;
	public GameObject reBody;
	//public GameObject noBody;
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
	public int walkedUpToCount = 0;
	//script for script GUI stuff
	public bool displayGUI;
	public Canvas scene7CanvasObj;
	public Text displayeddialogue_Scene7;

	public Canvas congratsEvidenceCanvas; 
	public Button okFromCongrats;

	public int maxEvidenceNum;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
