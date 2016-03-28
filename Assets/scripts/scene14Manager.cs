using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class scene14Manager : MonoBehaviour {
	public GameObject SceneHandlerObj;
	public SceneHandler scene14ManagerScript;
	public Text displayedDialogue_Scene14 =  null;
	private string [] dialogue; 
	private int i= 0; // a counter to iterater thru conversations, and set important convo indexes
	private int iwithEvidence;
	private int maxDialogueLength;  // defines the length of the dialogue in this scene
	// Use this for initialization
	// 
	void Awake(){
		//finds the empty gameobject associated with sceneHandler
		SceneHandlerObj = GameObject.FindGameObjectWithTag("SceneHandlerM") as GameObject;
		//finds the script that is attached to the above gameobject
		scene14ManagerScript = SceneHandlerObj.GetComponent<SceneHandler>();
	}
	void Start () {
		scene14ManagerScript.setUserVisited(14);
		scene14ManagerScript.printCurrentKillerID();
		dialogue = scene14ManagerScript.readFile("Scene14.txt");
		maxDialogueLength = dialogue.Length;

		displayDialogue();
	}
	
	// Update is called once per frame
	void Update () {
		if(i==maxDialogueLength+1){
			SceneManager.LoadScene(7);
		}

	}

	
	public void displayDialogue(){
		if(i<maxDialogueLength){
			displayedDialogue_Scene14.text = dialogue[i];
			i++;
		}
		else{
			i++;
		}
				
	}

}
