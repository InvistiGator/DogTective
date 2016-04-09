using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class sceneSelection : MonoBehaviour {
	public GameObject SceneHandlerObj;
	public SceneHandler sceneSelectionScript;

	void Awake(){
		//finds the empty gameobject associated with sceneHandler
		SceneHandlerObj = GameObject.FindGameObjectWithTag("SceneHandlerM") as GameObject;
		//finds the script that is attached to the above gameobject
		sceneSelectionScript = SceneHandlerObj.GetComponent<SceneHandler>();
	}
		// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public bool lookForEvidence(string evidence_){
		for(int i=0; i< sceneSelectionScript.CollectedEvidenceString.Length; i++){
			if(sceneSelectionScript.CollectedEvidenceString[i] == evidence_){
				return true;
			}
		}

		return false;
	}
	//====Navigation Game Play logic ===============//
	public void navToDoug(){
		if(!sceneSelectionScript.userVisited[27] && !sceneSelectionScript.userVisited[28] && !sceneSelectionScript.userVisited[29] && (sceneSelectionScript.userVisited[24] || sceneSelectionScript.userVisited[25] || sceneSelectionScript.userVisited[26])){//&& lookForEvidence("blood")){
				SceneManager.LoadScene(27);
				Debug.Log("Current SceneInstance.userVisited[1]:  ");
				Debug.Log(sceneSelectionScript.userVisited[1]);
		}
		else if (!sceneSelectionScript.userVisited[36] && (sceneSelectionScript.killerID == 0 || sceneSelectionScript.killerID == 1 || sceneSelectionScript.killerID == 2)){
			SceneManager.LoadScene(36);
		}
		else if (sceneSelectionScript.killerID == 2 && (sceneSelectionScript.userVisited[40] || sceneSelectionScript.userVisited[41])){
            SceneManager.LoadScene(57);
		}
		else if (sceneSelectionScript.killerID == 1 && (sceneSelectionScript.userVisited[40] || sceneSelectionScript.userVisited[41])){
            SceneManager.LoadScene(57);
		}
		else if (sceneSelectionScript.killerID == 0 && (sceneSelectionScript.userVisited[40] || sceneSelectionScript.userVisited[41])){
            SceneManager.LoadScene(57);
		}
		else{
			SceneManager.LoadScene(51);
		}
	}

	public void navToNorm(){
		if (!sceneSelectionScript.userVisited[15] && (sceneSelectionScript.userVisited[12] || (sceneSelectionScript.userVisited[13] && sceneSelectionScript.userVisited[14]))){
			SceneManager.LoadScene(15);
		}
		else if (!sceneSelectionScript.userVisited[30] && (sceneSelectionScript.userVisited[28] || sceneSelectionScript.userVisited[29])){
			SceneManager.LoadScene(57);
		}
		else{
			SceneManager.LoadScene(52);
		}
	}

	public void navToPolice(){
		if (!sceneSelectionScript.userVisited[14] && !sceneSelectionScript.userVisited[15] && (sceneSelectionScript.killerID == 3 || sceneSelectionScript.killerID == 4)){
			SceneManager.LoadScene(14);
		}
		else if (sceneSelectionScript.userVisited[15]){
			SceneManager.LoadScene(17);
		}
		else if ((sceneSelectionScript.userVisited[24] || sceneSelectionScript.userVisited[25]) && !sceneSelectionScript.userVisited[26] && !sceneSelectionScript.userVisited[27]){
			SceneManager.LoadScene(26);
		}
		else if (!sceneSelectionScript.userVisited[40] && (sceneSelectionScript.userVisited[37] || sceneSelectionScript.userVisited[38])){
			SceneManager.LoadScene(40);
		}
		else{
			SceneManager.LoadScene(53);
		}
	}

	public void navToSaloon(){
		if (!sceneSelectionScript.userVisited[10] && !sceneSelectionScript.userVisited[15] && (sceneSelectionScript.killerID == 3 || sceneSelectionScript.killerID == 4)){
			SceneManager.LoadScene(10);
		}
		else if (sceneSelectionScript.userVisited[15]){
			SceneManager.LoadScene(16);
		}
		else if (!sceneSelectionScript.userVisited[24] && !sceneSelectionScript.userVisited[27] && !sceneSelectionScript.userVisited[26] && (sceneSelectionScript.userVisited[23] || sceneSelectionScript.userVisited[25]) && lookForEvidence("tie")){
			SceneManager.LoadScene(24);
		}
		else{
			SceneManager.LoadScene(54);
		}
	}

	public void navToGoldie(){
		if (!sceneSelectionScript.userVisited[25] && !sceneSelectionScript.userVisited[26] && !sceneSelectionScript.userVisited[27] && (sceneSelectionScript.killerID == 5 || sceneSelectionScript.killerID == 6)){
			SceneManager.LoadScene(25);
		}
		else if (!sceneSelectionScript.userVisited[29] && !sceneSelectionScript.userVisited[30] && sceneSelectionScript.userVisited[27]){
			SceneManager.LoadScene(29);
		}
		else if (!sceneSelectionScript.userVisited[39] && (sceneSelectionScript.userVisited[37] || sceneSelectionScript.userVisited[38]) && !sceneSelectionScript.userVisited[40] && !sceneSelectionScript.userVisited[41]){
			SceneManager.LoadScene(39);
		}
		else{
			SceneManager.LoadScene(55);
		}
	}

	public void navToLawOffice(){
		if (!sceneSelectionScript.userVisited[13] && !sceneSelectionScript.userVisited[15] && (sceneSelectionScript.killerID == 3 || sceneSelectionScript.killerID == 4)){
			SceneManager.LoadScene(13);
		}
		else if (!sceneSelectionScript.userVisited[23] && !sceneSelectionScript.userVisited[24] && sceneSelectionScript.userVisited[25] && (sceneSelectionScript.killerID == 5 || sceneSelectionScript.killerID == 6)){
			SceneManager.LoadScene(23);
		}
		else if (!sceneSelectionScript.userVisited[28] && !sceneSelectionScript.userVisited[30] && sceneSelectionScript.userVisited[27]){
			SceneManager.LoadScene(28);
		}
		else if (!sceneSelectionScript.userVisited[41] && (sceneSelectionScript.userVisited[37] || sceneSelectionScript.userVisited[38]) && sceneSelectionScript.userVisited[39]){
			SceneManager.LoadScene(41);
		}
		else{
			SceneManager.LoadScene(56);
		}
	}

}
