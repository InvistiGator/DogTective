using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class scene18Manager : MonoBehaviour {
	public GameObject SceneHandlerObj;
	public SceneHandler sceneManagerScript;
	public audio18Script audioManager;
	public Text displayedDialogue =  null;
	
	private string [] dialogue_1;
	private string [] dialogue_2_1;
	private string [] dialogue_2_2;

	private int dialogue_1Length;
	private int dialogue_2_1Length;
	private int dialogue_2_2Length;

	private int section = 1;

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
		audioManager = audioManager.GetComponent<audio18Script>();
	}
	void Start () {
		sceneManagerScript.setUserVisited(18);
		sceneManagerScript.printCurrentKillerID();
		
		dialogue_1 = sceneManagerScript.readFile("Scene18_1.txt");
		dialogue_1Length = dialogue_1.Length;

		dialogue_2_1 = sceneManagerScript.readFile("Scene18_2_1.txt");
		dialogue_2_1Length = dialogue_2_1.Length;

		dialogue_2_2 = sceneManagerScript.readFile("Scene18_2_2.txt");
		dialogue_2_2Length = dialogue_2_2.Length;

		displayDialogue();

		sceneCanvas = sceneCanvas.GetComponent<Canvas>(); 
		sceneCanvas.enabled = true; 
		decision1Canvas = decision1Canvas.GetComponent<Canvas>();
		decision1Canvas.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(section == 1 && i == dialogue_1Length+1){
			sceneCanvas.enabled = false;
			decision1Canvas.enabled = true;
		}
		else if (section == 21 && i == dialogue_2_1Length+1){
			StartCoroutine(sceneManagerScript.FadeStuff(21));
		}
		else if (section == 22 && i == dialogue_2_2Length+1){
			StartCoroutine(sceneManagerScript.FadeStuff(22));
		}
	}

	
	public void displayDialogue(){
		if(section == 1 && i < dialogue_1Length){
			if (i==33) {
				audioManager.playDecisionPrompt();
			}
			displayedDialogue.text = dialogue_1[i];
			i++;
		}
		else if(section == 21 && i < dialogue_2_1Length){
			if (i==0){
				audioManager.playDecisionRes();
			}
			displayedDialogue.text = dialogue_2_1[i];
			i++;
		}
		else if(section == 22 && i < dialogue_2_2Length){
			if (i==0){
				audioManager.playDecisionRes();
			}
			displayedDialogue.text = dialogue_2_2[i];
			i++;
		}
		else{
			i++;
		}		
	}

	public void decision1(){
		i = 0;
		section = 22;
		displayDialogue();
		decision1Canvas.enabled = false;
		sceneCanvas.enabled = true;
	}

	public void decision2(){
		i = 0;
		section = 21;
		displayDialogue();
		decision1Canvas.enabled = false;
		sceneCanvas.enabled = true;
	}

}
