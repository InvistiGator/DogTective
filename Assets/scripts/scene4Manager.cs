using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class scene4Manager : MonoBehaviour {
	public GameObject SceneHandlerObj;
	public SceneHandler sceneManagerScript;
	public Text displayedDialogue_Scene4 =  null;
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
		sceneManagerScript = SceneHandlerObj.GetComponent<SceneHandler>();
	}
	void Start () {
		sceneManagerScript.setUserVisited(4);
		sceneManagerScript.printCurrentKillerID();
		dialogue = sceneManagerScript.readFile("Scene4.txt");
		maxDialogueLength = dialogue.Length;

		displayDialogue();
	}
	
	// Update is called once per frame
	void Update () {
		if(i==maxDialogueLength+1){
			if (sceneManagerScript.userVisited[3] && !sceneManagerScript.userVisited[5]){
			    SceneManager.LoadScene(5);
			}
			else if (sceneManagerScript.userVisited[3] && sceneManagerScript.userVisited[5]){
				SceneManager.LoadScene(6);
			}
			else{
				SceneManager.LoadScene(3);
			}
		}

	}

	
	public void displayDialogue(){
		if(i<maxDialogueLength){
			displayedDialogue_Scene4.text = dialogue[i];
			i++;
		}
		else{
			i++;
		}
				
	}

}
