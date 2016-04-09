using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class scene42Manager : MonoBehaviour {
	public GameObject SceneHandlerObj;
	public SceneHandler scene42ManagerScript;
	public audio42Script audioManager;
	public Text displayedDialogue_Scene42 =  null;
	private string [] dialogue; 
	private int i= 0; // a counter to iterater thru conversations, and set important convo indexes
	private int iwithEvidence;
	private int maxDialogueLength;  // defines the length of the dialogue in this scene

	public Canvas sceneCanvas;
	public Canvas decision1Canvas;
	// Use this for initialization
	// 
	void Awake(){
		//finds the empty gameobject associated with sceneHandler
		SceneHandlerObj = GameObject.FindGameObjectWithTag("SceneHandlerM") as GameObject;
		//finds the script that is attached to the above gameobject
		scene42ManagerScript = SceneHandlerObj.GetComponent<SceneHandler>();
		audioManager = audioManager.GetComponent<audio42Script>();
	}
	void Start () {
		scene42ManagerScript.setUserVisited(42);
		scene42ManagerScript.printCurrentKillerID();
		dialogue = scene42ManagerScript.readFile("Scene42.txt");
		maxDialogueLength = dialogue.Length;

		displayDialogue();

		sceneCanvas = sceneCanvas.GetComponent<Canvas>(); 
		sceneCanvas.enabled = true; 
		decision1Canvas = decision1Canvas.GetComponent<Canvas>();
		decision1Canvas.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(i==maxDialogueLength+1){
			sceneCanvas.enabled = false;
			decision1Canvas.enabled = true;
		}

	}

	
	public void displayDialogue(){
		if(i<maxDialogueLength){
			if (i==4) {
				audioManager.playDoorOpen();
			} else if (i==40) {
				audioManager.playDecisionPrompt();
			}
			displayedDialogue_Scene42.text = dialogue[i];
			i++;
		}
		else{
			i++;
		}
				
	}

	public void decision1(){
		audioManager.playDecisionRes();
		StartCoroutine(scene42ManagerScript.FadeStuff(45));
	}

	public void decision2(){
		audioManager.playDecisionRes();
		StartCoroutine(scene42ManagerScript.FadeStuff(46));
	}

}
