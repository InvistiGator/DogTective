using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
public class GUIManager : MonoBehaviour {

	//public GameObject sceneHandler;//so we can call & use methods from SceneHandler
	static GUIManager Instance; 

	public Button queCharactersText;
	public Button evidenceText;
	public Button quitGameText;
	public Button backToInfoText;

	public Canvas infoMainMenuCavas;
	public Canvas charactersCanvas;
	public Canvas evidenceCanvas;

	public Image [] CollectedEvidence;
	public Button [] QuestionalbleCharacters;
	public Text [] CharacterBio;

	//Scene Selection GUI after scene 4
	//Dialogue GUI related
	public Button SceneSelection; 
	public Text displayedDialogue;

	//public PickKiller pickKillerObj;
	public int killerID;

	// Use this for initialization
	void Start () {

		if(Instance != null){
			GameObject.Destroy(gameObject);
		}
		else{
			GameObject.DontDestroyOnLoad(gameObject);
			Instance = this; 
		}
		//initialize sceneHandler object
		//sceneHandler = sceneHandler.GetComponent<SceneHandler>();
		//sceneHandler= GameObject.Find("SceneHandler").gameObject.GetComponent<GameObject>();
		charactersCanvas = charactersCanvas.GetComponent<Canvas> (); //drop the charactersCanvas to Unity
		evidenceCanvas = evidenceCanvas.GetComponent<Canvas> (); //drop the evidenceCanvas to Unity
		
		infoMainMenuCavas.enabled = true; //this is true by default, but just incase
		//initial sub menus are NOT enabled until clicked on
		charactersCanvas.enabled = false; //Exit button isn't pressed @ start of game
		evidenceCanvas.enabled = false;		
		//sub menu buttons
		queCharactersText = queCharactersText.GetComponent<Button>();
		evidenceText = evidenceText.GetComponent<Button>();
		quitGameText = quitGameText.GetComponent<Button>();

		backToInfoText = backToInfoText.GetComponent<Button>();

		//pickKillerObj = GameObject.Find("PickKillerEmpty").gameObject.GetComponent<PickKiller>();
		//killerID = pickKillerObj.getRandomizedKiller();
		//Debug.Log("KillerID from GUIManager: ");
		//Debug.Log(killerID);
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyUp(KeyCode.Escape)){
			backButtonPressed();
		}
	}
	//=================Methods related to Main Pause Canvas ==============================//
	
	public void QuesCharactersTextButtPressed(){
		//activate the characters sub menu
		charactersCanvas.enabled = true;

		backToInfoText.enabled = true; 
		//disable all main menu buttons when quit sub menu is enabled.
		queCharactersText.enabled = false;
		evidenceText.enabled = false;
		quitGameText.enabled = false;
	}

	public void EvidenceTextButtPressed(){
		//activate the characters sub menu
		evidenceCanvas.enabled = true;
		backToInfoText.enabled = true; 
		//disable all main menu buttons when quit sub menu is enabled.
		queCharactersText.enabled = false; 
		evidenceText.enabled = false;
		quitGameText.enabled = false;
	}
	
	public void quitGameTextButtPressed(){
		//sceneHandler.ExitTextPressed();
	}


	//reroute users back to info GUI
	public void backButtonPressed(){
		infoMainMenuCavas.enabled = true;

		charactersCanvas.enabled = false;
		evidenceCanvas.enabled = false;

		queCharactersText.enabled = true;
		evidenceText.enabled = true;
		quitGameText.enabled = true;
	}
	//=================Methods specifically related to Characters GUI ========================//
	

	//=================Methods specifically related to Evidence GUI ========================//


	//=================Methods specifically related to Dialogue GUI ========================//



	
}
