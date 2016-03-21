using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour {

	public static SceneHandler SceneInstance; 
	public PickKiller pickKiller;
	public int killerID;
	public bool [] userVisited;


	public Canvas mainMenuCanvas;
	public Canvas quitSubMenu;
	public Button PlayText;
	public Button ExitText;
	public Button YesText;
	public Button NoText;


	public Button queCharactersText;
	public Text characterBio = null; //initial character bio is set to null if user didn't click on anything
	public Button evidenceText;
	public Button backToGameText;
	public Button quitGameText;
	public Button backToInfoText;

	public Canvas infoMainMenuCavas;
	public Canvas charactersCanvas;
	public Canvas evidenceCanvas;

	public Image [] CollectedEvidence;
	public string [] CollectedEvidenceString;
	public Sprite SpriteTemp;
	//public int maxEvidenceNum;

	public Button [] QuestionalbleCharacters;
	//public Text [] CharacterBio;

	//Scene Selection GUI after scene 4
	//Dialogue GUI related
	public Button SceneSelection; 
	public Text displayedDialogue;

	//public PickKiller pickKillerObj;
	//public int killerID;


	void Awake(){
		if(SceneInstance != null){
			GameObject.Destroy(gameObject);
		}
		else{
			GameObject.DontDestroyOnLoad(gameObject);
			SceneInstance = this; 
		}

		killerID = pickKiller.pickKillerRand();

	}
	void Start () {
		userVisited = new bool [20]; 
		//maxEvidenceNum = 10;
		//CollectedEvidence = new Image [maxEvidenceNum];
		for(int i = 0; i< CollectedEvidence.Length; i++){
			CollectedEvidence[i] = CollectedEvidence[i].GetComponent<Image>();
		}
		CollectedEvidenceString = new string [CollectedEvidence.Length];
		SpriteTemp =  GetComponent<Sprite>();
		//initiate some GUI stuff
		mainMenuCanvas = mainMenuCanvas.GetComponent<Canvas> (); 
		quitSubMenu = quitSubMenu.GetComponent<Canvas> (); //drop the subMenuCanvas to Unity
		PlayText = PlayText.GetComponent<Button>();
		ExitText = ExitText.GetComponent<Button>();
		YesText = YesText.GetComponent<Button>();
	 	NoText = NoText.GetComponent<Button>();
		//initialize my pickKiller object
		//pickKiller = pickKiller.GetComponent<PickKiller>();

		//initialize sceneHandler object
		//sceneHandler = sceneHandler.GetComponent<SceneHandler>();
		//sceneHandler= GameObject.Find("SceneHandler").gameObject.GetComponent<GameObject>();
		charactersCanvas = charactersCanvas.GetComponent<Canvas> (); //drop the charactersCanvas to Unity
		evidenceCanvas = evidenceCanvas.GetComponent<Canvas> (); //drop the evidenceCanvas to Unity
		

		quitSubMenu.enabled = false; //Exit button isn't pressed @ start of game
		infoMainMenuCavas.enabled = false; //this is true by default, but just incase
		//initial sub menus are NOT enabled until clicked on
		charactersCanvas.enabled = false; //Exit button isn't pressed @ start of game
		evidenceCanvas.enabled = false;		
		//sub menu buttons
		queCharactersText = queCharactersText.GetComponent<Button>();
		evidenceText = evidenceText.GetComponent<Button>();
		backToGameText = backToGameText.GetComponent<Button>();
		quitGameText = quitGameText.GetComponent<Button>();
		backToInfoText = backToInfoText.GetComponent<Button>();

		//pickKillerObj = GameObject.Find("PickKillerEmpty").gameObject.GetComponent<PickKiller>();
		//killerID = pickKillerObj.getRandomizedKiller();
		//Debug.Log("KillerID from GUIManager: ");
		//Debug.Log(killerID);
	}
	
	void Update () {
		
		if(Input.GetKeyDown(KeyCode.Escape)){
			Debug.Log("Escape Key Pressed!");
			backToPauseMenu();
		}
		
	}
	public void printCurrentKillerID(){
		Debug.Log ("randomized Killer: ");
		Debug.Log(killerID);
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

	//reroute users back to info GUI
	public void backToPauseMenu(){
		infoMainMenuCavas.enabled = true;
		charactersCanvas.enabled = false;
		evidenceCanvas.enabled = false;

		queCharactersText.enabled = true;
		evidenceText.enabled = true;
		backToGameText.enabled = true;
		quitGameText.enabled = true;
	}
	public void backToMainMenu(){
		mainMenuCanvas.enabled = true;
		PlayText.enabled = true;
		ExitText.enabled = true; 

		infoMainMenuCavas.enabled = false;
		charactersCanvas.enabled = false;
		evidenceCanvas.enabled = false;

		queCharactersText.enabled = false;
		evidenceText.enabled = false;
		backToGameText.enabled = false;
		quitGameText.enabled = false;
	}

	public void backToGameTextPressed(){
		infoMainMenuCavas.enabled = false; 
		infoMainMenuCavas.enabled = false;
		charactersCanvas.enabled = false;
		evidenceCanvas.enabled = false;

		queCharactersText.enabled = false;
		evidenceText.enabled = false;
		quitGameText.enabled = false;
	}
	public void ExitTextPressed(){
		//activate the quit sub menu
		quitSubMenu.enabled = true;
		YesText.enabled = true;
		NoText.enabled = true;

		//disable all main menu buttons when quit sub menu is enabled.
		//PlayText.enabled = false;
		//ExitText.enabled = false;
	}

	public void NoPressedOnQuitMenu(){
		//deactivate the quit sub menu
		quitSubMenu.enabled = false;
		//reactivate all main menu buttons when quit sub menu is not enabled.
		//PlayText.enabled = true;
		//ExitText.enabled = true;	
	}
	public void loadInitScene(string sceneIdentifier){
		//call pickKiller function before loading any game play scene
		//killerID = pickKiller.pickKillerRand();
		SceneManager.LoadScene(sceneIdentifier);
		Debug.Log ("randomized Killer Init: ");
		Debug.Log(killerID);	
	}
	public void optionsClicked(){

	}
	public void ExitGame(){
		Application.Quit ();// actually exiting the game
	}


	//=========NONE GUI related stuff ========== //
	public void setUserVisited(int sceneNum){
		//int sceneNum = int.Parse(SceneManager.GetActiveScene().name);
		userVisited[sceneNum] = true;
		
		Debug.Log("Current Scene Name: ");
		Debug.Log(SceneManager.GetActiveScene().name);
		Debug.Log(userVisited[sceneNum]);
	}

	//=================Methods specifically related to Characters GUI ========================//
	public void characterBio_Doug(){
		characterBio.text = "This is the text field for Doug, insert random  hadfkadfjadjfajdf dfajdlfjadfjadfj  ajdfjaldfladjflajf; lkajdfjaldfjadjf;adjfjsdf; a lkjdfkajdfkasd fajdfladf asdf ahadfafjdfja ajfajfajkfajdfjadkfj adI wonder how this works, does it just over flow? can it next line?this is the beginning of the next line..." ;
	}

	public void characterBio_Norm(){
		characterBio.text = "This is the text field for Norm, I wonder how this works, does it just over flow? can it next line?this is the beginning of the next line..." ;

	}

	public void characterBio_Jade(){
		characterBio.text = "This is the text field for Jade, I wonder how this works, does it just over flow? can it next line?this is the beginning of the next line..." ;
		
	}

	public void characterBio_Damina(){
		characterBio.text = "This is the text field for Damina, I wonder how this works, does it just over flow? can it next line?this is the beginning of the next line.." ;

	}

	public void characterBio_Goldie(){
		characterBio.text = "This is the text field for Goldie, I wonder how this works, does it just over flow? can it next line?this is the beginning of the next line..." ;

	}

	public void characterBio_Morgan(){
		characterBio.text = "This is the text field for Morgan, I wonder how this works, does it just over flow? can it next line?this is the beginning of the next line..." ;
		
	}

	public void characterBio_Tom(){
		characterBio.text = "This is the text field for Tom, I wonder how this works, does it just over flow? can it next line?this is the beginning of the next line..." ;

	}
//=================Methods specifically related to Evidence GUI ========================//
	public void setEvidenceCollected(string name, int srcScene){
		CollectedEvidenceString[srcScene-1] = name; 
		//CollectedEvidence[srcScene-1].GetComponent<Image>().sprite =  Resources.Load<Sprite>("Evidence/" + name);

		SpriteTemp = Resources.Load <Sprite>("../Evidence/" + name) as Sprite;
		

		CollectedEvidence[srcScene-1].GetComponent<Image>().sprite = SpriteTemp;
		Debug.Log("CollectedEvidence string [] : ");
		Debug.Log(CollectedEvidenceString[srcScene-1]);

		Debug.Log("Evidence/" + name);
	}

}
