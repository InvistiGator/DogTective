using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class scene14Manager : MonoBehaviour {
	public GameObject SceneHandlerObj;
	public SceneHandler sceneManagerScript;
	public Text displayedDialogue =  null;
	
	private string [] dialogue_1;
	private string [] dialogue_2;
	private string [] dialogue_3;
	private string [] dialogue_4;

	private int dialogue_1Length;
	private int dialogue_2Length;
	private int dialogue_3Length;
	private int dialogue_4Length;

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
		sceneManagerScript.setUserVisited(14);
		sceneManagerScript.printCurrentKillerID();
		
		dialogue_1 = sceneManagerScript.readFile("Scene14_1.txt");
		dialogue_1Length = dialogue_1.Length;

		dialogue_2 = sceneManagerScript.readFile("Scene14_2.txt");
		dialogue_2Length = dialogue_2.Length;

		dialogue_3 = sceneManagerScript.readFile("Scene14_3.txt");
		dialogue_3Length = dialogue_3.Length;

		dialogue_4 = sceneManagerScript.readFile("Scene14_4.txt");
		dialogue_4Length = dialogue_4.Length;

		displayDialogue();
	}
	
	// Update is called once per frame
	void Update () {
		if(section == 1 && i == dialogue_1Length+1){
			if (sceneManagerScript.userVisited[12]){
				section = 2;
				i = 0;
				displayDialogue();
			}
			else{
				section = 3;
				i = 0;
				displayDialogue();
			}
		}
		else if(section == 2 && i == dialogue_2Length+1){
  			section = 3;
  			i = 0;
  			displayDialogue();
		}
		else if(section == 3 && i == dialogue_3Length+1){
			if (sceneManagerScript.userVisited[12]){
				section = 4;
				i = 0;
				displayDialogue();
			}
			else{
				SceneManager.LoadScene(9);
			}
		}
		else if (section == 4 && i == dialogue_4Length+1){
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
		else{
			i++;
		}
				
	}

}
