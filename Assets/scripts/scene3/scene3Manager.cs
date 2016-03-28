using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class scene3Manager : MonoBehaviour {
//private scene2Manager: SceneHandler;
	public GameObject SceneHandlerObj;
	public SceneHandler scene3ManagerScript;
	public Text displayedDialogue_Scene3 =  null;
	public Canvas scene3Canvas;
	//different dialogue versions in this scenes based on the random killerID generated in sceneHandler
	private string [] dialogue_1;
	private string [] dialogue_2_1;
	private string [] dialogue_2_2;

	private int i= 0; // a counter to iterater thru conversations, and set important convo indexes
	private int iwithEvidence;
	private int dialogue_1Length;
	private int dialogue_2_1Length;
	private int dialogue_2_2Length;
	private int maxDialogueLength = 3;  // defines the length of the dialogue in this scene
	// Use this for initialization
	// 
	void Awake(){
		//finds the empty gameobject associated with sceneHandler
		SceneHandlerObj = GameObject.FindGameObjectWithTag("SceneHandlerM") as GameObject;
		//finds the script that is attached to the above gameobject
		scene3ManagerScript = SceneHandlerObj.GetComponent<SceneHandler>();
	}
	void Start () {
		scene3ManagerScript.setUserVisited(3);
		scene3ManagerScript.printCurrentKillerID();
		iwithEvidence = 0;		
		//set up dialogue needed for this scene
		
		dialogue_1 = scene3ManagerScript.readFile("Scene3_1.txt");
		dialogue_1Length = dialogue_1.Length;

		dialogue_2_1 = scene3ManagerScript.readFile("Scene3_2_1.txt");
		dialogue_2_1Length = dialogue_2_1.Length;

		dialogue_2_2 = scene3ManagerScript.readFile("Scene3_2_2.txt");
		dialogue_2_2Length = dialogue_2_2.Length;

		displayDialogue();
		
		//disable GUI at beginning 
		scene3Canvas = scene3Canvas.GetComponent<Canvas> (); 
		scene3Canvas.enabled = true; 
	}
	
	// Update is called once per frame
	void Update () {
		//if counter reached the max dialogue length, move onto next scene
		if(i==maxDialogueLength){
			//if before this scene something already visited somewhere direct as needed
			if(scene3ManagerScript.userVisited[2]){
				SceneManager.LoadScene(4);
				Debug.Log("Current SceneInstance.userVisited[3]:  ");
				Debug.Log(scene3ManagerScript.userVisited[3]);

			}
		}
	}

	public void changeDialogue(){
		//write switch or if/else statements to decide what portion of dialogue need to be changed. 
		//if(scene3ManagerScript.killerID == 0 )
		//	dialogue[3] = "hummmm...is Doug the killer?"
	}
	public void displayDialogue(){
		if(i==iwithEvidence){
			scene3ManagerScript.setEvidenceCollected("evidence",3);
		}
		if(i<maxDialogueLength){
			displayedDialogue_Scene3.text = dialogue_1[i];
			i++;
		}
				
	}

	public void enableGUI(){
		scene3Canvas.enabled = true;
	}
}
