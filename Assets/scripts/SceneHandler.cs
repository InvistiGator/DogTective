using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour {

	public static SceneHandler SceneInstance; 
	public PickKiller pickKiller;
	public int killerID;
	public bool [] userVisited;

	//public Color color; 


	public Canvas mainMenuCanvas;
	public Canvas quitSubMenu;
	public Button PlayText;
	public Button ExitText;
	public Button YesText;
	public Button NoText;


	public Button queCharactersText;
	public Text characterBio = null; //initial character bio is set to null if user didn't click on anything
	public Text characterName = null;
	public Button evidenceText;
	public Button backToGameText;
	public Button quitGameText;
	public Button backToInfoText;

	public Canvas infoMainMenuCavas;
	public Canvas charactersCanvas;
	public Canvas evidenceCanvas;

	public Image [] CollectedEvidence;
	public string [] CollectedEvidenceString;
	//public Sprite SpriteTemp;
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
		//SpriteTemp =  gameObject.GetComponent<"Sprite">;
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

		queCharactersText.enabled = false;
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
        
        if (userVisited[3]){
		    queCharactersText.enabled = true;
		}

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
		characterName.text = "Doug “Ace” Ventose \nThe Hapless Deceased";
		characterBio.text = "Doug has always dreamt of being a detective. Not just any detective, but a cool, classy sleuth - one from all of those movies and books he would fawn over as a pup. Though he has managed to become a (semi)legitimate private eye, and his penchant for pipes and trenchcoats might make him look a bit like Sherlock Holmes, anybody who actually interacts with Doug quickly realizes that he behaves nothing like his dramatic heroes. The detached facade he shows to others consistently gives way to his true nature as a goofy, naive dreamer. With those close to him, he is more likely to crack a joke than talk about his detective work. \nHe currently runs a private eye business where he receives occasional, but much-needed, help from his close friend Jade. Up until now, he has only gotten small cases of missing dogs and cat burglary, but when an old acquaintance of his dies, he takes it upon himself to solve the murder, and boost his career in the process." ;
	}

	public void characterBio_Norm(){
		characterName.text = "Norm Previse \nThe Hapless Deceased";
		characterBio.text = "Norm attended high school with Doug and Jade, and they hadn’t heard from him since graduation. \nWell, until he died, that is. \nHe was known to be subdued and kind, helping out any who asked, but ultimately failing to make a name for himself. Despite being an exceptionally hardworking cat, Norm always failed to do well in his classes, earning him occasional ridicule from other students. As is pretty evident by this point, he was a very sad sack, which makes his current situation all the more surprising. \nIn the five years between high school and his demise, Norm had somehow accumulated a fair bit of money, a large home, and a prominent position at a law firm. Unfortunately, the police found him lying in a pool of blood in his own home and are at a loss as to who might have committed the deed." ;
	}

	public void characterBio_Jade(){
		characterName.text = "Jade Heimdall \nThe Sly Sidekick";
		characterBio.text = "Jade has usually been the smartest fox in the room, and they are well aware of this fact, being rational and calculated at all times. Though such a demeanor may scare many away from being close to Jade, a kind heart lies in wait for those who persevere. One of the few to do so is Doug, and Jade harbors a begrudging gratitude for that silly hound. Jade may have chosen continued schooling over dramatic sleuthing, but still finds a great deal of pleasure in helping Doug solve even the most minor of cases, constantly pulling him out of his imagined, golden age of detective work and into the present-day reality of cell phones and criminal forensics. \nWith this newest case, Jade plans on helping Doug more than ever, but would never admit to enjoying the thrills of being a part of such a masterful murder case." ;
		
	}

	public void characterBio_Damina(){
		characterName.text = "Damina Punctum \nThe Unassuming Chief";
		characterBio.text = "Years of working in a police department might turn some cats grizzled and cold, but not Damina. Her long service has surprisingly turned her into a source of unending jokes, mostly puns, which she will blurt out at any moment. Keeping spirits high like this helps get both her detectives and herself through the rougher days of police work - a fact of which she is well aware. Behind her uplifting exterior lies a bottomless font of detective knowledge, and, if forced, she is able to get to the heart of any matter in an instant, ensuring her investigations always stay on track. \nShe has taken a liking to Doug, whom she has lovingly nicknamed Ace, and she has come to see more than a bit of herself in his goofy, yet determined, nature. Damina’s almost parental treatment of Doug occasionally gets on his nerves, but he still reveres her as a master sleuth. With the death of Norm Previse, an old acquaintance of Doug’s, Damina decides that it is finally time to bring Doug in on a bigger case, and is eager to see how he fares." ;

	}

	public void characterBio_Goldie(){
		characterName.text = "Goldie Weal \nThe Arrogant Executive";
		characterBio.text = "One would be hard-pressed to find someone with a bigger ego or bank account than Goldie, the fat cat. Thanks to the entrepreneurial efforts of her family, Goldie has come to own innumerable businesses all over town and she is never ashamed of talking about how much she owns and how much money she spends. At least she’s pretty honest about it all. \nGiven her big talk and position as the president of her family’s company, KT Corp, many assume she must be a genius business mogul, but that couldn’t be further from the truth. Goldie is, in fact, utterly inept at almost every aspect of running a business. She simply inherited the business from her family, the actual geniuses behind KT Corp.. \nIn order to prevent the collapse of the business during her reign, Goldie hired a number of others to run the different aspects of things for her while she keeps the title of president for herself. The law firm Norm worked for is owned by Goldie, and they’re in charge of handling any problems KT Corp, or Goldie herself, has with the law. If there were any such problems, Goldie might have been the one responsible for Norm’s death." ;

	}

	public void characterBio_Morgan(){
		characterName.text = "Morgan Evetta \nThe Shrewd Lawyer";
		characterBio.text = "Few dogs have ever looked and acted more like a rat than Morgan Evetta, the head of Weal Law Associates. He is a highly competent prosecutor with an impressive track record, but Morgan did not reach this position with strength or dominance. Rather, he has achieved success thanks to his amazing abilities to suck up to his superiors and sniff out any evidence he wants, whether it’s real or not. At first glance, many would think little of his meek demeanor, but that is exactly what he wants, as he uses this confusion to gain others’ trust and support. The only animal in the world whom Morgan seems to genuinely care for is Goldie,  despite her apparent stupidity and arrogance. He has been responsible for much of KT Corp’s success after Goldie’s mother’s death. \nFour years ago, Morgan hired Norm to work at Weal Law Associates, and was likely one of the people who interacted with Norm the most before his death. If anyone could have seen this tragedy coming, it would have been Morgan, but it seems unlikely that he’d tell anyone the whole truth." ;
		
	}

	public void characterBio_Tom(){
		characterName.text = "Tom “Sweet Tooth” Confetto \nThe Amiable Mobster";
		characterBio.text = "In a world ruled by anthropomorphic canines and felines, the ultimate drug is chocolate, and Tom Confetto is the top dog of this sugary underworld. Though everyone is well aware of his delicious criminal empire, nobody, not even Chief Punctum, has ever been able to catch him with chocolate on his paws. With his likeable personality, Confetto has charmed many an animal into a chocolate purchase, earning him the nickname Sweet Tooth. In fact, he becomes so close and friendly with his customers that very few have ever considered testifying against him, and any who seem like they might are found dead of a chocolate overdose soon enough, a result of Sweet Tooth’s surprisingly short-tempered rage. \nHe runs a bar, The Sultry Saloon, as a front for his business, and he is most often found relaxing there with his clientele. Norm worked down the street from The Sultry Saloon, and this would not be the first time that Sweet Tooth had someone working with the law in his pocket." ;

	}

//=================Methods specifically related to Evidence GUI ========================//
	public void setEvidenceCollected(string name, int srcScene){
		
		//CollectedEvidence[srcScene-1].GetComponent<Image>().sprite =  Resources.Load<Sprite>("Evidence/" + name);
		//SpriteTemp = Resources.Load <Sprite>(name) as Sprite;
		//CollectedEvidence[srcScene-1].GetComponent<Image>().sprite = SpriteTemp;


		CollectedEvidenceString[srcScene-1] = name; 
		Color temp = CollectedEvidence[srcScene-1].color;
		temp.a = 1.0f;
		CollectedEvidence[srcScene-1].color = temp;

		Debug.Log("CollectedEvidence string [] : ");
		Debug.Log(CollectedEvidenceString[srcScene-1]);
		Debug.Log("Evidence/" + name);

		//Debug.Log(SpriteTemp.ToString());
	}

}
