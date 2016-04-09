using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class scene39Manager : MonoBehaviour {
	public GameObject SceneHandlerObj;
	public SceneHandler sceneManagerScript;
	public audio39Script audioManager;
	public Text displayedDialogue =  null;
	
	private string [] dialogue_1;
	private string [] dialogue_2_1;
	private string [] dialogue_2_2;

	private int dialogue_1Length;
	private int dialogue_2_1Length;
	private int dialogue_2_2Length;

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
		audioManager = audioManager.GetComponent<audio39Script>();
	}
	void Start () {
		sceneManagerScript.setUserVisited(39);
		sceneManagerScript.printCurrentKillerID();
		
		dialogue_1 = sceneManagerScript.readFile("Scene39_1.txt");
		dialogue_1Length = dialogue_1.Length;

		dialogue_2_1 = sceneManagerScript.readFile("Scene39_2_1.txt");
		dialogue_2_1Length = dialogue_2_1.Length;

		dialogue_2_2 = sceneManagerScript.readFile("Scene39_2_2.txt");
		dialogue_2_2Length = dialogue_2_2.Length;

		displayDialogue();
	}
	
	// Update is called once per frame
	void Update () {
		if(section == 1 && i == dialogue_1Length+1){
			i = 0;
			if (sceneManagerScript.killerID == 1){
				section = 22;
				displayDialogue();
			}
			else{
				section = 21;
				displayDialogue();
			}
		}
		else if (section == 21 && i == dialogue_2_1Length+1){
			sceneManagerScript.setEvidenceCollected("SchoolRecords", 30);
			StartCoroutine(sceneManagerScript.FadeStuff(9));
		}
		else if (section == 22 && i == dialogue_2_2Length+1){
			sceneManagerScript.setEvidenceCollected("SchoolRecords", 31);
			StartCoroutine(sceneManagerScript.FadeStuff(9));
		}
	}

	
	public void displayDialogue(){
		if(section == 1 && i < dialogue_1Length){
			if (i==9) {
				audioManager.playKnocking();
			} else if (i==13) {
				audioManager.playDoorOpen();
			} else if (i==32) {
				audioManager.playDoorClose();
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
		else{
			i++;
		}	
	}
}
