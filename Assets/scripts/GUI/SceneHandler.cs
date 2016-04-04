using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Text;
using System.IO; 

public class SceneHandler : MonoBehaviour {

	public static SceneHandler SceneInstance; 
	public PickKiller pickKiller;
	public int killerID;
	//0 Doug, 1 Jade, 2 Norm, 3 Damina, 4 Tom, 5 Goldie, 6 Morgan
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

	public Image[] CharacterImages;

	public Canvas infoMainMenuCavas;
	public Canvas charactersCanvas;
	public Canvas evidenceCanvas;

	public Image [] CollectedEvidence;
	public string [] CollectedEvidenceString;
	//public Sprite SpriteTemp;
	//public int maxEvidenceNum;
	public Text evidenceInfo;

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
		userVisited = new bool [50]; 
		for(int i = 0; i< userVisited.Length; i++){
			userVisited[i] = false;
		}
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

		//Make all character images initially invisible.
		for (int i = 0; i < CharacterImages.Length; i++){
			CharacterImages[i].enabled = false;
		}
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

	public void loadSceneSelectionScene(){
		
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
		Time.timeScale = 0;
		infoMainMenuCavas.enabled = true;
		charactersCanvas.enabled = false;
		evidenceCanvas.enabled = false;
        
        if (userVisited[2]){
		    queCharactersText.enabled = true;
		}

		evidenceText.enabled = true;

		backToGameText.enabled = true;
		quitGameText.enabled = true;

		for (int i = 0; i < 7; i++){
			CharacterImages[i].enabled = false;
		}
		characterName.text = "";
		characterBio.text = "";
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
		Time.timeScale = 1;
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
		for (int i = 0; i < 7; i++){
			CharacterImages[i].enabled = false;
		}
		CharacterImages[0].enabled = true;
	}

	public void characterBio_Norm(){
		characterName.text = "Norm Previse \nThe Hapless Deceased";
		characterBio.text = "Norm attended high school with Doug and Jade, and they hadn’t heard from him since graduation. \nWell, until he died, that is. \nHe was known to be subdued and kind, helping out any who asked, but ultimately failing to make a name for himself. Despite being an exceptionally hardworking cat, Norm always failed to do well in his classes, earning him occasional ridicule from other students. As is pretty evident by this point, he was a very sad sack, which makes his current situation all the more surprising. \nIn the five years between high school and his demise, Norm had somehow accumulated a fair bit of money, a large home, and a prominent position at a law firm. Unfortunately, the police found him lying in a pool of blood in his own home and are at a loss as to who might have committed the deed." ;
		for (int i = 0; i < CharacterImages.Length; i++){
			CharacterImages[i].enabled = false;
		}
		CharacterImages[2].enabled = true;
	}

	public void characterBio_Jade(){
		characterName.text = "Jade Heimdall \nThe Sly Sidekick";
		characterBio.text = "Jade has usually been the smartest fox in the room, and they are well aware of this fact, being rational and calculated at all times. Though such a demeanor may scare many away from being close to Jade, a kind heart lies in wait for those who persevere. One of the few to do so is Doug, and Jade harbors a begrudging gratitude for that silly hound. Jade may have chosen continued schooling over dramatic sleuthing, but still finds a great deal of pleasure in helping Doug solve even the most minor of cases, constantly pulling him out of his imagined, golden age of detective work and into the present-day reality of cell phones and criminal forensics. \nWith this newest case, Jade plans on helping Doug more than ever, but would never admit to enjoying the thrills of being a part of such a masterful murder case." ;
		for (int i = 0; i < 7; i++){
			CharacterImages[i].enabled = false;
		}
		CharacterImages[1].enabled = true;
	}

	public void characterBio_Damina(){
		characterName.text = "Damina Punctum \nThe Unassuming Chief";
		characterBio.text = "Years of working in a police department might turn some cats grizzled and cold, but not Damina. Her long service has surprisingly turned her into a source of unending jokes, mostly puns, which she will blurt out at any moment. Keeping spirits high like this helps get both her detectives and herself through the rougher days of police work - a fact of which she is well aware. Behind her uplifting exterior lies a bottomless font of detective knowledge, and, if forced, she is able to get to the heart of any matter in an instant, ensuring her investigations always stay on track. \nShe has taken a liking to Doug, whom she has lovingly nicknamed Ace, and she has come to see more than a bit of herself in his goofy, yet determined, nature. Damina’s almost parental treatment of Doug occasionally gets on his nerves, but he still reveres her as a master sleuth. With the death of Norm Previse, an old acquaintance of Doug’s, Damina decides that it is finally time to bring Doug in on a bigger case, and is eager to see how he fares." ;
		for (int i = 0; i < 7; i++){
			CharacterImages[i].enabled = false;
		}
		CharacterImages[3].enabled = true;
	}

	public void characterBio_Goldie(){
		characterName.text = "Goldie Weal \nThe Arrogant Executive";
		characterBio.text = "One would be hard-pressed to find someone with a bigger ego or bank account than Goldie, the fat cat. Thanks to the entrepreneurial efforts of her family, Goldie has come to own innumerable businesses all over town and she is never ashamed of talking about how much she owns and how much money she spends. At least she’s pretty honest about it all. \nGiven her big talk and position as the president of her family’s company, KT Corp, many assume she must be a genius business mogul, but that couldn’t be further from the truth. Goldie is, in fact, utterly inept at almost every aspect of running a business. She simply inherited the business from her family, the actual geniuses behind KT Corp.. \nIn order to prevent the collapse of the business during her reign, Goldie hired a number of others to run the different aspects of things for her while she keeps the title of president for herself. The law firm Norm worked for is owned by Goldie, and they’re in charge of handling any problems KT Corp, or Goldie herself, has with the law. If there were any such problems, Goldie might have been the one responsible for Norm’s death." ;
		for (int i = 0; i < 7; i++){
			CharacterImages[i].enabled = false;
		}
		CharacterImages[5].enabled = true;
	}

	public void characterBio_Morgan(){
		characterName.text = "Morgan Evetta \nThe Shrewd Lawyer";
		characterBio.text = "Few dogs have ever looked and acted more like a rat than Morgan Evetta, the head of Weal Law Associates. He is a highly competent prosecutor with an impressive track record, but Morgan did not reach this position with strength or dominance. Rather, he has achieved success thanks to his amazing abilities to suck up to his superiors and sniff out any evidence he wants, whether it’s real or not. At first glance, many would think little of his meek demeanor, but that is exactly what he wants, as he uses this confusion to gain others’ trust and support. The only animal in the world whom Morgan seems to genuinely care for is Goldie,  despite her apparent stupidity and arrogance. He has been responsible for much of KT Corp’s success after Goldie’s mother’s death. \nFour years ago, Morgan hired Norm to work at Weal Law Associates, and was likely one of the people who interacted with Norm the most before his death. If anyone could have seen this tragedy coming, it would have been Morgan, but it seems unlikely that he’d tell anyone the whole truth." ;
		for (int i = 0; i < 7; i++){
			CharacterImages[i].enabled = false;
		}
		CharacterImages[6].enabled = true;
	}

	public void characterBio_Tom(){
		characterName.text = "Tom “Sweet Tooth” Confetto \nThe Amiable Mobster";
		characterBio.text = "In a world ruled by anthropomorphic canines and felines, the ultimate drug is chocolate, and Tom Confetto is the top dog of this sugary underworld. Though everyone is well aware of his delicious criminal empire, nobody, not even Chief Punctum, has ever been able to catch him with chocolate on his paws. With his likeable personality, Confetto has charmed many an animal into a chocolate purchase, earning him the nickname Sweet Tooth. In fact, he becomes so close and friendly with his customers that very few have ever considered testifying against him, and any who seem like they might are found dead of a chocolate overdose soon enough, a result of Sweet Tooth’s surprisingly short-tempered rage. \nHe runs a bar, The Sultry Saloon, as a front for his business, and he is most often found relaxing there with his clientele. Norm worked down the street from The Sultry Saloon, and this would not be the first time that Sweet Tooth had someone working with the law in his pocket." ;
		for (int i = 0; i < 7; i++){
			CharacterImages[i].enabled = false;
		}
		CharacterImages[4].enabled = true;
	}


	//Evidence Texts
	public void blood(){
		evidenceInfo.text = "Blood (?)\nIt looked like there was a huge pool of blood at Norm's place, but it turned out to just be a bunch of red ink.";
	}
	public void redPen(){
		evidenceInfo.text = "Red Pen\nFound at the scene of the crime near the body. Covered in red ink.";
	}

	public void candyWrapper(){
		evidenceInfo.text = "Candy Wrapper\nFound at the scene of the crime. Norm might have been addicted to chocolate.";
	}

	public void shortWhiteFur(){
		evidenceInfo.text = "Short White Fur\nThere was some of this fur at the scene of the crime. It is short, white, and thin.";
	}

	public void scuffMarks(){
		evidenceInfo.text = "Scuff Marks\nNear one of the walls at the scene of the crime, there were some scuff marks. What could have caused this?";
	}

	public void inkPaper(){
		evidenceInfo.text = "Ink-Covered Paper\nAll of this paper was found at Norm's desk covered in ink. I wonder if there was anything important on these pages...";
	}

	public void noBody(){
		evidenceInfo.text = "No Body\nWhen I first went to the scene of the crime, Norm's body wasn't there! Where could it have gone?";
	}

	public void longWhiteFur(){
		evidenceInfo.text = "Long White Fur\nBeautiful, long, white hairs, clearly from a great creature in its prime. Found at the crime scene.";
	}

	public void bodyReappeared(){
		evidenceInfo.text = "The Body Returned\nNorm's body magically appeared at the scene of the crime the second time I was there. How did it disappear and reappear like that?!";
	}

	public void chocolatePaper(){
		evidenceInfo.text = "Chocolate-Covered Paper\nChocolate has been smeared all over these papers. Ah, the sweet smell of evidence.";
	}

	public void Money(){
		evidenceInfo.text = "Money\nWho would leave a bunch of money at the scene of a crime. Is this Norm's or someone else's?";
	}

	public void emptyDesk(){
		evidenceInfo.text = "Empty Desk\nLooks like everything on, in, and around Norm's desk was wiped clean. Too clean... Suspiciously clean... This is totally evidence.";
	}

	public void grayFur(){
		evidenceInfo.text = "Gray Fur\nFound at the scene of the crime. This looks a lot like Norm's fur, but there are a lot of other animals with this color on them as well.";
	}

	public void workPapers(){
		evidenceInfo.text = "Papers from Work\nLooks like Norm was bringing his work home with him. ...this stuff isn't nearly as cool as my job is!";
	}

	public void blackFur(){
		evidenceInfo.text = "Black Fur\nA bunch of black fur from the scene of the cime. It's black. It's fur. Not much to say, really.";
	}

	public void pinkSlip(){
		evidenceInfo.text = "Pink Slip\nWas Norm going to be fired? Well, I guess he doesn't have to worry about his job anymore...";
	}

	public void newspaperClipping(){
		evidenceInfo.text = "Newspaper Clipping\nHey, look! That's me! I remember catching that cat burgler red-handed! I only caught him because he bumbed into me on the street while running from the cops, but that still counts!";
	}

	public void letterOpener(){
		evidenceInfo.text = "Letter Opener\nNorm had one of these on his desks. I've never been sure why animals with claws need letter openers, though...";
	}

	public void schoolYearbook(){
		evidenceInfo.text = "School Yearbook\nHey, Norm kept our old high school yearbook. Good times... mostly for Jade.";
	}

	public void whiteFur(){
		evidenceInfo.text = "White Fur\nFound some pretty average white fur at the scene of the crime. It looks really familar... Probably because so many cats and dogs have some white fur.";
	}

	public void lightBrownFur(){
		evidenceInfo.text = "Light Brown Fur\nThere was some light brown fur at the scene of the crime. Kinda looks like some of the patches of my fur.";
	}

	public void pipe(){
		evidenceInfo.text = "Pipe\nIt seems like Norm had a pipe. If only I would have known... He and I could have had pipe parties where we sit around looking like cool detectives!";
	}

	public void knocking(){
		evidenceInfo.text = "Knocking\nApparently some thugs were knocking on things around town. This piece of evidence has been brought to you by knocking. Knocking: don't knock it till you try it.";
	}

	public void twoOneThree(){
		evidenceInfo.text = "2-1-3\nSo this may be a passcode that Tom uses... He should really make it longer, with at least an uppercase letter and special character.";
	}

	public void tomPassage(){
		evidenceInfo.text = "Tom's Secret Passage\nWe managed to sneak into one of Tom's secret passaged using his 2-1-3 passcode. How does knocking on a wall open a door, anyway?";
	}

	public void normPassage(){
		evidenceInfo.text = "Norm's Secret Passage\nWow, Norm has a secret passage connected to his house. It would be so awesome to have that in your house. I wonder if Norm's house is for sale...";
	}

	public void tie(){
		evidenceInfo.text = "Tie\nA tie. It looks like Tom's, but Morgan gave it to me. Do I trust this as a piece of evidence?";
	}

	public void goldieClass(){
		evidenceInfo.text = "Norm's Classes with Goldie\nNorm took some classes with Goldie, so they must have known each other. Were they friends?";
	}

	public void dougClass(){
		evidenceInfo.text = "Norm's Classes with Doug\nI barely remember him, but I know Norm and I took some classes together. Poor guy could never catch a break.";
	}

	public void schoolClub(){
		evidenceInfo.text = "School Club\nNorm was in our high school's Science Club with Jade. He worked so hard, but I guess science wasn't his calling either.";
	}

	public void schoolRecords(){
		evidenceInfo.text = "School Records\nNorm took a few classes at a private academy to try and catch up on his coursework. Goldie isn't good at keeping her information secure, is she...?";
	}

	public void noSchoolRecords(){
		evidenceInfo.text = "No School Records\nNorm's school records were completely deleted. Someone with 1337 h4ck1ng skills must be up to something here...";
	}

//=================Methods specifically related to Evidence GUI ========================//
	public void setEvidenceCollected(string name, int srcScene){
		
		//CollectedEvidence[srcScene-1].GetComponent<Image>().sprite =  Resources.Load<Sprite>("Evidence/" + name);
		//SpriteTemp = Resources.Load <Sprite>(name) as Sprite;
		//CollectedEvidence[srcScene-1].GetComponent<Image>().sprite = SpriteTemp;

		CollectedEvidenceString[srcScene] = name; 
		Color temp = CollectedEvidence[srcScene].color;
		temp.a = 1.0f;
		CollectedEvidence[srcScene].color = temp;

		Debug.Log("CollectedEvidence string [] : ");
		Debug.Log(CollectedEvidenceString[srcScene]);
		Debug.Log("Evidence/" + name);

		//Debug.Log(SpriteTemp.ToString());
	}
	//the setEvidenceCollected method for scene2 and scene4
	public void setEvidenceCollected3D(string name){
		int tempInt = 0;
			//Debug.Log(SpriteTemp.ToString());
			if(name=="blood"){
				tempInt = 0;
			}
			if(name=="redPen"){
				tempInt = 1;
			}
			if(name=="candyWrapper"){
				tempInt = 2;
			}
			if(name=="noBody"){
				tempInt = 6;
			}
			if(name=="shortWhiteFur"){
				tempInt = 3;
			}
			if(name=="longWhiteFur"){
				tempInt = 7;
			}
			if(name=="money"){
				tempInt = 10;
			}
			if(name=="papersFromWork"){
				tempInt = 13;
			}
			if(name=="lightBrownFur"){
				tempInt = 20;
			}

			if(name=="scuffMarks"){
				tempInt = 4;
			}
			if(name=="paperCoveredWithRedInk"){
				tempInt = 5;
			}
			if(name=="reBody"){
				tempInt = 8;
			}
			if(name=="paperSmearedWithChocolate"){
				tempInt = 9;
			}
			if(name=="veryCleanDesk"){
				tempInt = 11;
			}
			if(name=="grayFur"){
				tempInt = 12;
			}
			if(name=="blackFur"){
				tempInt = 14;
			}
			if(name=="pinkSlip"){
				tempInt = 15;
			}
			if(name=="newspaperClipping"){
				tempInt = 16;
			}
			if(name=="letterOpener"){
				tempInt = 17;
			}
			if(name=="schoolYearbook"){
				tempInt = 18;
			}
			if(name=="whiteFur"){
				tempInt = 19;
			}
			if(name=="pipe"){
				tempInt = 21;
			}

		CollectedEvidenceString[tempInt] = name; 
		Color temp = CollectedEvidence[tempInt].color;
		temp.a = 1.0f;
		CollectedEvidence[tempInt].color = temp;

		Debug.Log("CollectedEvidence string [] : ");
		Debug.Log(CollectedEvidenceString[tempInt]);
		Debug.Log("Evidence/" + name);
	}

	public bool lookForEvidence(string evidence_){
		for(int i=0; i<CollectedEvidenceString.Length; i++){
			if(CollectedEvidenceString[i] == evidence_){
				return true;
			}
		}

		return false;
	}

	public string[] readFile(string fileName){
			string currentLine;

			int lineCount = File.ReadAllLines(fileName).Length;

			string[] allLines = new string[lineCount];
			StreamReader reader = new StreamReader(fileName, Encoding.Default);
			int i = 0;

			using (reader){
				do{
					currentLine = reader.ReadLine();

					if (currentLine != null){
						allLines[i] = currentLine;
						i++;
					}
				}
				while (currentLine != null);
				reader.Close();
			}

		return allLines;
	}


}
