using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class scene1Dialogue : MonoBehaviour {
	public GameObject SceneHandlerObj;
	public SceneHandler scene1ManagerScript;
	public Text displayedDialogue_Scene1 =  null;
	private string [] dialogue; 
	private int i= 0;
	// Use this for initialization
	// 
	void Awake(){
		//finds the empty gameobject associated with sceneHandler
		SceneHandlerObj = GameObject.FindGameObjectWithTag("SceneHandlerM") as GameObject;
		//finds the script that is attached to the above gameobject
		scene1ManagerScript = SceneHandlerObj.GetComponent<SceneHandler>();
	}
	void Start () {
		scene1ManagerScript.setUserVisited(1);
		scene1ManagerScript.printCurrentKillerID();
		dialogue = new string[3];
		dialogue[0] = "???: On that day - the day that would signal the start of my greatest case yet - I had been sitting in my dark office for a long while.";
		dialogue[1] = "???: It’d been some time since I’d last gotten any sort of work, and even longer since I last caught a whiff of anything big.";
		dialogue[2] = "???: All of that would soon change when that day brought me the biggest case of my career.";


		displayDialogue();
	}
	
	// Update is called once per frame
	void Update () {
		if(i==3){
			SceneManager.LoadScene(2);
		}
	}

	
	public void displayDialogue(){
		if(i<3){
			displayedDialogue_Scene1.text = dialogue[i];
			i++;
		}
				
	}

}
