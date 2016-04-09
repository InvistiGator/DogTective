using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class scene26Manager : MonoBehaviour {
	public GameObject SceneHandlerObj;
	public SceneHandler sceneManagerScript;
	public Text displayedDialogue =  null;
	
	private string [] dialogue_1;

	private int dialogue_1Length;

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
	}
	void Start () {
		sceneManagerScript.setUserVisited(26);
		sceneManagerScript.printCurrentKillerID();

		if (!sceneManagerScript.lookForEvidence("tie") && sceneManagerScript.userVisited[25]){
			dialogue_1 = sceneManagerScript.readFile("Scene26_1.txt");
			dialogue_1Length = dialogue_1.Length;
		}
		else{
			dialogue_1 = sceneManagerScript.readFile("Scene26_2.txt");
			dialogue_1Length = dialogue_1.Length;
		}

		displayDialogue();
	}
	
	// Update is called once per frame
	void Update () {
		if(section == 1 && i == dialogue_1Length+1){
			StartCoroutine(sceneManagerScript.FadeStuff(9));
		}
	}

	
	public void displayDialogue(){
		if(section == 1 && i < dialogue_1Length){
			displayedDialogue.text = dialogue_1[i];
			i++;
		}
		else{
			i++;
		}		
	}
}
