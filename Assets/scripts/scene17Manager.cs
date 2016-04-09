using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class scene17Manager : MonoBehaviour {
	public GameObject SceneHandlerObj;
	public SceneHandler sceneManagerScript;
	public audio17Script audioManager;
	public Text displayedDialogue =  null;

	private string [] dialogue_1;
	private string [] dialogue_2;
	private string [] dialogue_3;
	private string [] dialogue_4_1;
	private string [] dialogue_4_2;
	private string [] dialogue_5_1;
	private string [] dialogue_5_2;

	private int dialogue_1Length;
	private int dialogue_2Length;
	private int dialogue_3Length;
	private int dialogue_4_1Length;
	private int dialogue_4_2Length;
	private int dialogue_5_1Length;
	private int dialogue_5_2Length;

	private int section = 1;

	public Canvas sceneCanvas;
	public Canvas decision1Canvas;
	public Canvas decision2Canvas;

	private int i = 0; // a counter to iterater thru conversations, and set important convo indexes
	private int iwithEvidence;
	// Use this for initialization
	// 
	void Awake(){
		//finds the empty gameobject associated with sceneHandler
		SceneHandlerObj = GameObject.FindGameObjectWithTag("SceneHandlerM") as GameObject;
		//finds the script that is attached to the above gameobject
		sceneManagerScript = SceneHandlerObj.GetComponent<SceneHandler>();
		audioManager = audioManager.GetComponent<audio17Script>();
	}
	void Start () {
		sceneManagerScript.setUserVisited(17);
		sceneManagerScript.printCurrentKillerID();
		
		dialogue_1 = sceneManagerScript.readFile("Scene17_1.txt");
		dialogue_1Length = dialogue_1.Length;

		dialogue_2 = sceneManagerScript.readFile("Scene17_2.txt");
		dialogue_2Length = dialogue_2.Length;

		dialogue_3 = sceneManagerScript.readFile("Scene17_3.txt");
		dialogue_3Length = dialogue_3.Length;

		dialogue_4_1 = sceneManagerScript.readFile("Scene17_4_1.txt");
		dialogue_4_1Length = dialogue_4_1.Length;

		dialogue_4_2 = sceneManagerScript.readFile("Scene17_4_2.txt");
		dialogue_4_2Length = dialogue_4_2.Length;

		dialogue_5_1 = sceneManagerScript.readFile("Scene17_5_1.txt");
		dialogue_5_1Length = dialogue_5_1.Length;

		dialogue_5_2 = sceneManagerScript.readFile("Scene17_5_2.txt");
		dialogue_5_2Length = dialogue_5_2.Length;

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
			if (sceneManagerScript.killerID == 4){
				i = 0;
				section = 2;
				displayDialogue();
			}
			else{
				i = 0;
				section = 3;
				displayDialogue();
			}
		}
		else if (section == 2 && i == dialogue_2Length+1){
			StartCoroutine(sceneManagerScript.FadeStuff(9));
		}
		else if (section == 3 && i == dialogue_3Length+1){
			sceneCanvas.enabled = false;
			decision1Canvas.enabled = true;
		}
		else if (section == 41 && i == dialogue_4_1Length+1){
			StartCoroutine(sceneManagerScript.FadeStuff(9));
		}
		else if (section == 42 && i == dialogue_4_2Length+1){
			sceneCanvas.enabled = false;
			decision2Canvas.enabled = true;
		}
		else if (section == 51 && i == dialogue_5_1Length+1){
			StartCoroutine(sceneManagerScript.FadeStuff(21));
		}
		else if (section == 52 && i == dialogue_5_2Length+1){
			StartCoroutine(sceneManagerScript.FadeStuff(18));
		}
	}

	
	public void displayDialogue(){
		if(section == 1 && i < dialogue_1Length){
			displayedDialogue.text = dialogue_1[i];
			i++;
		}
		else if(section == 2 && i < dialogue_2Length){
			displayedDialogue.text = dialogue_2[i];
			i++;
		}
		else if(section == 3 && i < dialogue_3Length){
			if (i==0) {
				audioManager.playDecisionPrompt();
			}
			displayedDialogue.text = dialogue_3[i];
			i++;
		}
		else if(section == 41 && i < dialogue_4_1Length){
			if (i==0) {
				audioManager.playDecisionRes();
			}
			displayedDialogue.text = dialogue_4_1[i];
			i++;
		}
		else if(section == 42 && i < dialogue_4_2Length){
			if (i==0) {
				audioManager.playDecisionRes();
			} else if (i==4) {
				audioManager.playDecisionPrompt();
			}
			displayedDialogue.text = dialogue_4_2[i];
			i++;
		}
		else if(section == 51 && i < dialogue_5_1Length){
			if (i==0) {
				audioManager.playDecisionRes();
			}
			displayedDialogue.text = dialogue_5_1[i];
			i++;
		}
		else if(section == 52 && i < dialogue_5_2Length){
			if (i==0) {
				audioManager.playDecisionRes();
			}
			displayedDialogue.text = dialogue_5_2[i];
			i++;
		}
		else{
			i++;
		}		
	}

	public void decision1(){
		i = 0;
		section = 42;
		displayDialogue();
		decision1Canvas.enabled = false;
		decision2Canvas.enabled = false;
		sceneCanvas.enabled = true;
	}

	public void decision2(){
		i = 0;
		section = 41;
		displayDialogue();
		decision1Canvas.enabled = false;
		decision2Canvas.enabled = false;
		sceneCanvas.enabled = true;
	}

	public void decision3(){
		i = 0;
		section = 52;
		displayDialogue();
		decision1Canvas.enabled = false;
		decision2Canvas.enabled = false;
		sceneCanvas.enabled = true;
	}

	public void decision4(){
		i = 0;
		section = 51;
		displayDialogue();
		decision1Canvas.enabled = false;
		decision2Canvas.enabled = false;
		sceneCanvas.enabled = true;
	}

}
