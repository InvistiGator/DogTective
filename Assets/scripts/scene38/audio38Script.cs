using UnityEngine;
using System.Collections;

public class audio38Script : MonoBehaviour {
	//
	public AudioSource audio;

	public AudioClip decisionPrompt;
	public AudioClip decisionRes;

	// Use this for initialization
	void Awake () {
		audio = GetComponent<AudioSource>();
	}
	void Start(){
		
	}

	public void playDecisionPrompt() {
		audio.clip=decisionPrompt;
		audio.Play();
	}
	public void playDecisionRes() {
		audio.clip=decisionRes;
		audio.Play();
	}

}
