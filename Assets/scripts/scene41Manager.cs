using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class scene41Manager : MonoBehaviour {
	public GameObject SceneHandlerObj;
	public SceneHandler sceneManagerScript;
	public Text displayedDialogue =  null;
	
	private string [] dialogue_1;
	private string [] dialogue_2;
	private string [] dialogue_3;
	private string [] dialogue_4;
	private string [] dialogue_5;
	private string [] dialogue_6;

	private int dialogue_1Length;
	private int dialogue_2Length;
	private int dialogue_3Length;
	private int dialogue_4Length;
	private int dialogue_5Length;
	private int dialogue_6Length;

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
	}
	void Start () {
		sceneManagerScript.setUserVisited(41);
		sceneManagerScript.printCurrentKillerID();
		
		dialogue_1 = sceneManagerScript.readFile("Scene41_1.txt");
		dialogue_1Length = dialogue_1.Length;

		dialogue_2 = sceneManagerScript.readFile("Scene41_2.txt");
		dialogue_2Length = dialogue_2.Length;

		dialogue_3 = sceneManagerScript.readFile("Scene41_3.txt");
		dialogue_3Length = dialogue_3.Length;

		dialogue_4 = sceneManagerScript.readFile("Scene41_4.txt");
		dialogue_4Length = dialogue_4.Length;

		dialogue_5 = sceneManagerScript.readFile("Scene41_5.txt");
		dialogue_5Length = dialogue_5.Length;

		dialogue_6 = sceneManagerScript.readFile("Scene41_6.txt");
		dialogue_6Length = dialogue_6.Length;

		displayDialogue();

		sceneCanvas = sceneCanvas.GetComponent<Canvas>(); 
		sceneCanvas.enabled = true; 
		decision1Canvas = decision1Canvas.GetComponent<Canvas>();
		decision1Canvas.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(section == 1 && i == dialogue_1Length+1){
			i = 0;

			if (sceneManagerScript.killerID == 1){
				section = 2;
				displayDialogue();
			}
			else{
				section = 3;
				displayDialogue();
			}
		}
		else if (section == 2 && i == dialogue_2Length+1){
			i = 0;
			section = 3;
			displayDialogue();
		}
		else if (section == 3 && i == dialogue_3Length+1){
			sceneCanvas.enabled = false;
			decision1Canvas.enabled = true;
		}
		else if (section == 4 && i == dialogue_4Length+1){
			if (sceneManagerScript.killerID == 1){
				SceneManager.LoadScene(48);
			}
			else{
				i = 0;
				section = 5;
				displayDialogue();
			}
		}
		else if (section == 5 && i == dialogue_5Length+1){
			SceneManager.LoadScene(41);
		}
		else if (section == 6 && i == dialogue_6Length+1){
			SceneManager.LoadScene(9);
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
			displayedDialogue.text = dialogue_3[i];
			i++;
		}
		else if(section == 4 && i < dialogue_4Length){
			displayedDialogue.text = dialogue_4[i];
			i++;
		}
		else if(section == 5 && i < dialogue_5Length){
			displayedDialogue.text = dialogue_5[i];
			i++;
		}
		else if(section == 6 && i < dialogue_6Length){
			displayedDialogue.text = dialogue_6[i];
			i++;
		}
		else{
			i++;
		}		
	}

	public void decision1(){
		i = 0;
		section = 6;
		sceneCanvas.enabled = true;
		decision1Canvas.enabled = false;
		displayDialogue();
	}

	public void decision2(){
		i = 0;
		section = 4;
		sceneCanvas.enabled = true;
		decision1Canvas.enabled = false;
		displayDialogue();
	}
}
