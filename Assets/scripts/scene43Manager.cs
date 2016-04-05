using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class scene43Manager : MonoBehaviour {
	public GameObject SceneHandlerObj;
	public SceneHandler scene43ManagerScript;
	public audio43Script audioManager;
	public Text displayedDialogue_Scene43 =  null;
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
		scene43ManagerScript = SceneHandlerObj.GetComponent<SceneHandler>();
		audioManager = audioManager.GetComponent<audio43Script>();
	}
	void Start () {
		scene43ManagerScript.setUserVisited(43);
		scene43ManagerScript.printCurrentKillerID();
		dialogue = scene43ManagerScript.readFile("Scene43.txt");
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
			if (i==33) {
				audioManager.playDecisionPrompt();
			}
			displayedDialogue_Scene43.text = dialogue[i];
			i++;
		}
		else{
			i++;
		}
				
	}

	public void decision1(){
		audioManager.playDecisionRes();
		SceneManager.LoadScene(48);
	}

	public void decision2(){
		audioManager.playDecisionRes();
		SceneManager.LoadScene(47);
	}

}
