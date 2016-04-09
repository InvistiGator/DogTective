using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class scene15Manager : MonoBehaviour {
	public GameObject SceneHandlerObj;
	public SceneHandler sceneManagerScript;
	public audio15Script audioManager;
	public Text displayedDialogue =  null;
	
	private string [] dialogue_1;
	private string [] dialogue_2_1;
	private string [] dialogue_2_2;
	private string [] dialogue_3;

	private int dialogue_1Length;
	private int dialogue_2_1Length;
	private int dialogue_2_2Length;
	private int dialogue_3Length;

	private int section = 1;

	private int i = 0; // a counter to iterater thru conversations, and set important convo indexes
	private int iwithEvidence;
	// Use this for initialization
	// 
	void Awake(){
		//finds the empty gameobject associated with sceneHandler
		SceneHandlerObj = GameObject.FindGameObjectWithTag("SceneHandlerM") as GameObject;
		//finds the script that is attached to the above gameobject
		sceneManagerScript = SceneHandlerObj.GetComponent<SceneHandler>();
		audioManager = audioManager.GetComponent<audio15Script>();
	}
	void Start () {
		sceneManagerScript.setUserVisited(15);
		sceneManagerScript.printCurrentKillerID();
		
		dialogue_1 = sceneManagerScript.readFile("Scene15_1.txt");
		dialogue_1Length = dialogue_1.Length;

		dialogue_2_1 = sceneManagerScript.readFile("Scene15_2_1.txt");
		dialogue_2_1Length = dialogue_2_1.Length;

		dialogue_2_2 = sceneManagerScript.readFile("Scene15_2_2.txt");
		dialogue_2_2Length = dialogue_2_2.Length;

		dialogue_3 = sceneManagerScript.readFile("Scene15_3.txt");
		dialogue_3Length = dialogue_3.Length;

		displayDialogue();
	}
	
	// Update is called once per frame
	void Update () {
		if(section == 1 && i == dialogue_1Length+1){
			if (sceneManagerScript.killerID == 3){
				section = 22;
				i = 0;
				displayDialogue();
			}
			else{
				section = 21;
				i = 0;
				displayDialogue();
			}
		}
		else if ((section == 21 && i == dialogue_2_1Length+1) || (section == 22 && i == dialogue_2_2Length+1)){
			section = 3;
			i = 0;
			displayDialogue();
		}
		else if (section == 3 && i == dialogue_3Length+1){
			sceneManagerScript.setEvidenceCollected("NormsSecretPassage", 25);
			StartCoroutine(sceneManagerScript.FadeStuff(57));
		}
	}

	
	public void displayDialogue(){
		if(section == 1 && i < dialogue_1Length){
			if (i==5) {
				audioManager.playKnucklesCracking();
			} else if (i==6) {
				audioManager.playVar213();
			} else if (i==14) {
				audioManager.playClick();
			}
			displayedDialogue.text = dialogue_1[i];
			i++;
		}
		else if(section == 21 && i < dialogue_2_1Length){
			displayedDialogue.text = dialogue_2_1[i];
			i++;
		}
		else if(section == 22 && i < dialogue_2_2Length){
			displayedDialogue.text = dialogue_2_2[i];
			i++;
		}
		else if(section == 3 && i < dialogue_3Length){
			displayedDialogue.text = dialogue_3[i];
			i++;
		}
		else{
			i++;
		}
				
	}

}
