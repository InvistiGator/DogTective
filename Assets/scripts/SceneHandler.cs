using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour {

	public Canvas quitSubMenu;
	public Button PlayText;
	public Button ExitText;
	public PickKiller pickKiller;
	//public GUIManager guiManager;
	public int killerID;

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
	//public int killerID;

	// Use this for initialization
	void Start () {

		quitSubMenu = quitSubMenu.GetComponent<Canvas> (); //drop the subMenuCanvas to Unity
		PlayText = PlayText.GetComponent<Button>();
		ExitText = ExitText.GetComponent<Button>();
		quitSubMenu.enabled = false; //Exit button isn't pressed @ start of game
		//initialize my pickKiller object
		//pickKiller = pickKiller.GetComponent<PickKiller>();
		killerID = pickKiller.pickKillerRand();

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


	public void ExitTextPressed(){
		//activate the quit sub menu
		quitSubMenu.enabled = true;
		//disable all main menu buttons when quit sub menu is enabled.
		PlayText.enabled = false;
		ExitText.enabled = false;
	}

	public void NoPressedOnQuitMenu(){
		//deactivate the quit sub menu
		quitSubMenu.enabled = false;
		//reactivate all main menu buttons when quit sub menu is not enabled.
		PlayText.enabled = true;
		ExitText.enabled = true;	
	}
	public void loadInitScene(string sceneIdentifier){
		//call pickKiller function before loading any game play scene
		//killerID = pickKiller.pickKillerRand();
		SceneManager.LoadScene(sceneIdentifier);
		Debug.Log ("randomized Killer: ");
		Debug.Log(killerID);	
	}
	public void optionsClicked(){
		SceneManager.LoadScene("pauseMenuScene");
	}
	public void ExitGame(){
		Application.Quit ();// actually exiting the game
	}
}
