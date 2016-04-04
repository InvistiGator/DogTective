using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class scene16Manager : MonoBehaviour {
	public GameObject SceneHandlerObj;
	public SceneHandler sceneManagerScript;
	public Text displayedDialogue =  null;
	
	private string [] dialogue_1;
	private string [] dialogue_2_1;
	private string [] dialogue_2_2;
	private string [] dialogue_3_1;
	private string [] dialogue_3_2;
	private string [] dialogue_4;

	private int dialogue_1Length;
	private int dialogue_2_1Length;
	private int dialogue_2_2Length;
	private int dialogue_3_1Length;
	private int dialogue_3_2Length;
	private int dialogue_4Length;

	private int section = 1;

	public Canvas sceneCanvas;
	public Canvas decision1Canvas;
	public Canvas decision2Canvas;

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
		sceneManagerScript.setUserVisited(16);
		sceneManagerScript.printCurrentKillerID();
		
		dialogue_1 = sceneManagerScript.readFile("Scene16_1.txt");
		dialogue_1Length = dialogue_1.Length;

		dialogue_2_1 = sceneManagerScript.readFile("Scene16_2_1.txt");
		dialogue_2_1Length = dialogue_2_1.Length;

		dialogue_2_2 = sceneManagerScript.readFile("Scene16_2_2.txt");
		dialogue_2_2Length = dialogue_2_2.Length;

		dialogue_3_1 = sceneManagerScript.readFile("Scene16_3_1.txt");
		dialogue_3_1Length = dialogue_3_1.Length;

		dialogue_3_2 = sceneManagerScript.readFile("Scene16_3_2.txt");
		dialogue_3_2Length = dialogue_3_2.Length;

		dialogue_4 = sceneManagerScript.readFile("Scene16_4.txt");
		dialogue_4Length = dialogue_4.Length;

		displayDialogue();

		sceneCanvas = sceneCanvas.GetComponent<Canvas>(); 
		sceneCanvas.enabled = true; 
		decision1Canvas = decision1Canvas.GetComponent<Canvas>();
		decision1Canvas.enabled = false;
		decision2Canvas = decision2Canvas.GetComponent<Canvas>();
		decision2Canvas.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(section == 1 && i == dialogue_1Length+1){
			sceneCanvas.enabled = false;

			if (sceneManagerScript.killerID == 4 && sceneManagerScript.userVisited[17]){
				decision2Canvas.enabled = true;
			}
			else{
				decision1Canvas.enabled = true;
			}
		}
		else if (section == 21 && i == dialogue_2_1Length+1){
			SceneManager.LoadScene(9);
		}
		else if (section == 22 && i == dialogue_2_2Length+1){
			SceneManager.LoadScene(16);
		}
		else if (section == 31 && i == dialogue_3_1Length+1){
			SceneManager.LoadScene(19);
		}
		else if (section == 32 && i == dialogue_3_2Length+1){
			SceneManager.LoadScene(20);
		}
		else if (section == 4 && i == dialogue_4Length+1){
			SceneManager.LoadScene(21);
		}
	}

	
	public void displayDialogue(){
		if(section == 1 && i < dialogue_1Length){
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
		else if(section == 31 && i < dialogue_3_1Length){
			displayedDialogue.text = dialogue_3_1[i];
			i++;
		}
		else if(section == 32 && i < dialogue_3_2Length){
			displayedDialogue.text = dialogue_3_2[i];
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

	public void decision1(){
		i = 0;
		if (sceneManagerScript.killerID == 4){
			section = 31;
		}
		else{
			section = 4;
		}
		displayDialogue();
		decision1Canvas.enabled = false;
		decision2Canvas.enabled = false;
		sceneCanvas.enabled = true;
	}

	public void decision2(){
		i = 0;
		section = 22;
		displayDialogue();
		decision1Canvas.enabled = false;
		decision2Canvas.enabled = false;
		sceneCanvas.enabled = true;
	}

	public void decision3(){
		i = 0;
		section = 21;
		displayDialogue();
		decision1Canvas.enabled = false;
		decision2Canvas.enabled = false;
		sceneCanvas.enabled = true;
	}

	public void decision4(){
		i = 0;
		section = 32;
		displayDialogue();
		decision1Canvas.enabled = false;
		decision2Canvas.enabled = false;
		sceneCanvas.enabled = true;
	}
}
