using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class scene13Manager : MonoBehaviour {
	public GameObject SceneHandlerObj;
	public SceneHandler scene13ManagerScript;
	public Text displayedDialogue =  null;

	private string [] dialogue_1;
	private string [] dialogue_2_1;
	private string [] dialogue_2_2;

	private int dialogue_1Length;
	private int dialogue_2_1Length;
	private int dialogue_2_2Length;

	private int section = 1;

	private int i= 0; // a counter to iterater thru conversations, and set important convo indexes
	private int iwithEvidence;
	// Use this for initialization
	// 
	void Awake(){
		//finds the empty gameobject associated with sceneHandler
		SceneHandlerObj = GameObject.FindGameObjectWithTag("SceneHandlerM") as GameObject;
		//finds the script that is attached to the above gameobject
		scene13ManagerScript = SceneHandlerObj.GetComponent<SceneHandler>();
	}
	void Start () {
		scene13ManagerScript.setUserVisited(13);
		scene13ManagerScript.printCurrentKillerID();

		dialogue_1 = scene13ManagerScript.readFile("Scene13_1.txt");
		dialogue_1Length = dialogue_1.Length;

		dialogue_2_1 = scene13ManagerScript.readFile("Scene13_2_1.txt");
		dialogue_2_1Length = dialogue_2_1.Length;

		dialogue_2_2 = scene13ManagerScript.readFile("Scene13_2_2.txt");
		dialogue_2_2Length = dialogue_2_2.Length;

		displayDialogue();
	}
	
	// Update is called once per frame
	void Update () {
		//if counter reached the max dialogue length, move onto next scene
		if(section == 1 && i == dialogue_1Length+1){
			if (scene13ManagerScript.userVisited[12]){
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
		else if (section == 21 && i == dialogue_2_1Length+1){
			SceneManager.LoadScene(9);
		}
		else if (section == 22 && i == dialogue_2_2Length+1){
			SceneManager.LoadScene(9);
		}

	}

	
	public void displayDialogue(){
		if(section == 1 && i < dialogue_1Length){
			displayedDialogue.text = dialogue_1[i];
			i++;
		}
		else if (section == 21 && i < dialogue_2_1Length){
			displayedDialogue.text = dialogue_2_1[i];
			i++;
		}
		else if (section == 22 && i < dialogue_2_2Length){
			displayedDialogue.text = dialogue_2_2[i];
			i++;
		}
		else{
			i++;
		}		
	}

}
