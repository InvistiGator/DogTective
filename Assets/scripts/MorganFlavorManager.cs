using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class MorganFlavorManager : MonoBehaviour {
	public GameObject SceneHandlerObj;
	public SceneHandler sceneManagerScript;
	public Text displayedDialogue =  null;
	
	private string [] dialogue_1;

	private int dialogue_1Length;

	private int i = 0; // a counter to iterater thru conversations, and set important convo indexes
	private int iwithEvidence;

	// initialization
	void Awake(){
		//finds the empty gameobject associated with sceneHandler
		SceneHandlerObj = GameObject.FindGameObjectWithTag("SceneHandlerM") as GameObject;
		//finds the script that is attached to the above gameobject
		sceneManagerScript = SceneHandlerObj.GetComponent<SceneHandler>();
	}
	void Start () {

		dialogue_1 = sceneManagerScript.readFile("MorganFlavor.txt");
		dialogue_1Length = dialogue_1.Length;

		displayDialogue();
	}
	
	// Update is called once per frame
	void Update () {
		if(i == dialogue_1Length+1){
			SceneManager.LoadScene(9);
		}
	}

	
	public void displayDialogue(){
		if(i < dialogue_1Length){
			displayedDialogue.text = dialogue_1[i];
			i++;
		}
		else{
			i++;
		}
	}
}
