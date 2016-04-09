using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class sceneSelection : MonoBehaviour {
	public GameObject SceneHandlerObj;
	public SceneHandler sceneManagerScript;

	void Awake(){
		//finds the empty gameobject associated with sceneHandler
		SceneHandlerObj = GameObject.FindGameObjectWithTag("SceneHandlerM") as GameObject;
		//finds the script that is attached to the above gameobject
		sceneManagerScript = SceneHandlerObj.GetComponent<SceneHandler>();
	}
		// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public bool lookForEvidence(string evidence_){
		for(int i=0; i< sceneManagerScript.CollectedEvidenceString.Length; i++){
			if(sceneManagerScript.CollectedEvidenceString[i] == evidence_){
				return true;
			}
		}

		return false;
	}
	//====Navigation Game Play logic ===============//
	public void navToDoug(){
		if(!sceneManagerScript.userVisited[27] && !sceneManagerScript.userVisited[28] && !sceneManagerScript.userVisited[29] && (sceneManagerScript.userVisited[24] || sceneManagerScript.userVisited[25] || sceneManagerScript.userVisited[26])){//&& lookForEvidence("blood")){
				StartCoroutine(sceneManagerScript.FadeStuff(27));
				Debug.Log("Current SceneInstance.userVisited[1]:  ");
				Debug.Log(sceneManagerScript.userVisited[1]);
		}
		else if (!sceneManagerScript.userVisited[36] && (sceneManagerScript.killerID == 0 || sceneManagerScript.killerID == 1 || sceneManagerScript.killerID == 2)){
			StartCoroutine(sceneManagerScript.FadeStuff(36));
		}
		else if (sceneManagerScript.killerID == 2 && (sceneManagerScript.userVisited[40] || sceneManagerScript.userVisited[41])){
            StartCoroutine(sceneManagerScript.FadeStuff(57));
		}
		else if (sceneManagerScript.killerID == 1 && (sceneManagerScript.userVisited[40] || sceneManagerScript.userVisited[41])){
            StartCoroutine(sceneManagerScript.FadeStuff(57));
		}
		else if (sceneManagerScript.killerID == 0 && (sceneManagerScript.userVisited[40] || sceneManagerScript.userVisited[41])){
            StartCoroutine(sceneManagerScript.FadeStuff(57));
		}
		else{
			StartCoroutine(sceneManagerScript.FadeStuff(51));
		}
	}

	public void navToNorm(){
		if (!sceneManagerScript.userVisited[15] && (sceneManagerScript.userVisited[12] || (sceneManagerScript.userVisited[13] && sceneManagerScript.userVisited[14]))){
			StartCoroutine(sceneManagerScript.FadeStuff(15));
		}
		else if (!sceneManagerScript.userVisited[30] && (sceneManagerScript.userVisited[28] || sceneManagerScript.userVisited[29])){
			StartCoroutine(sceneManagerScript.FadeStuff(57));
		}
		else{
			StartCoroutine(sceneManagerScript.FadeStuff(52));
		}
	}

	public void navToPolice(){
		if (!sceneManagerScript.userVisited[14] && !sceneManagerScript.userVisited[15] && (sceneManagerScript.killerID == 3 || sceneManagerScript.killerID == 4)){
			StartCoroutine(sceneManagerScript.FadeStuff(14));
		}
		else if (sceneManagerScript.userVisited[15]){
			StartCoroutine(sceneManagerScript.FadeStuff(17));
		}
		else if ((sceneManagerScript.userVisited[24] || sceneManagerScript.userVisited[25]) && !sceneManagerScript.userVisited[26] && !sceneManagerScript.userVisited[27]){
			StartCoroutine(sceneManagerScript.FadeStuff(26));
		}
		else if (!sceneManagerScript.userVisited[40] && (sceneManagerScript.userVisited[37] || sceneManagerScript.userVisited[38])){
			StartCoroutine(sceneManagerScript.FadeStuff(40));
		}
		else{
			StartCoroutine(sceneManagerScript.FadeStuff(53));
		}
	}

	public void navToSaloon(){
		if (!sceneManagerScript.userVisited[10] && !sceneManagerScript.userVisited[15] && (sceneManagerScript.killerID == 3 || sceneManagerScript.killerID == 4)){
			StartCoroutine(sceneManagerScript.FadeStuff(10));
		}
		else if (sceneManagerScript.userVisited[15]){
			StartCoroutine(sceneManagerScript.FadeStuff(16));
		}
		else if (!sceneManagerScript.userVisited[24] && !sceneManagerScript.userVisited[27] && !sceneManagerScript.userVisited[26] && (sceneManagerScript.userVisited[23] || sceneManagerScript.userVisited[25]) && lookForEvidence("tie")){
			StartCoroutine(sceneManagerScript.FadeStuff(24));
		}
		else{
			StartCoroutine(sceneManagerScript.FadeStuff(54));
		}
	}

	public void navToGoldie(){
		if (!sceneManagerScript.userVisited[25] && !sceneManagerScript.userVisited[26] && !sceneManagerScript.userVisited[27] && (sceneManagerScript.killerID == 5 || sceneManagerScript.killerID == 6)){
			StartCoroutine(sceneManagerScript.FadeStuff(25));
		}
		else if (!sceneManagerScript.userVisited[29] && !sceneManagerScript.userVisited[30] && sceneManagerScript.userVisited[27]){
			StartCoroutine(sceneManagerScript.FadeStuff(29));
		}
		else if (!sceneManagerScript.userVisited[39] && (sceneManagerScript.userVisited[37] || sceneManagerScript.userVisited[38]) && !sceneManagerScript.userVisited[40] && !sceneManagerScript.userVisited[41]){
			StartCoroutine(sceneManagerScript.FadeStuff(39));
		}
		else{
			StartCoroutine(sceneManagerScript.FadeStuff(55));
		}
	}

	public void navToLawOffice(){
		if (!sceneManagerScript.userVisited[13] && !sceneManagerScript.userVisited[15] && (sceneManagerScript.killerID == 3 || sceneManagerScript.killerID == 4)){
			StartCoroutine(sceneManagerScript.FadeStuff(13));
		}
		else if (!sceneManagerScript.userVisited[23] && !sceneManagerScript.userVisited[24] && sceneManagerScript.userVisited[25] && (sceneManagerScript.killerID == 5 || sceneManagerScript.killerID == 6)){
			StartCoroutine(sceneManagerScript.FadeStuff(23));
		}
		else if (!sceneManagerScript.userVisited[28] && !sceneManagerScript.userVisited[30] && sceneManagerScript.userVisited[27]){
			StartCoroutine(sceneManagerScript.FadeStuff(28));
		}
		else if (!sceneManagerScript.userVisited[41] && (sceneManagerScript.userVisited[37] || sceneManagerScript.userVisited[38]) && sceneManagerScript.userVisited[39]){
			StartCoroutine(sceneManagerScript.FadeStuff(41));
		}
		else{
			StartCoroutine(sceneManagerScript.FadeStuff(56));
		}
	}

}
