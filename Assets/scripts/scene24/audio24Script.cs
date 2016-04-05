using UnityEngine;
using System.Collections;

public class audio24Script : MonoBehaviour {
	//
	public AudioSource audio;

	public AudioClip decisionResolution;
	public AudioClip decisionPrompt;

	// Use this for initialization
	void Awake () {
		audio = GetComponent<AudioSource>();
	}
	void Start(){
		
	}

	public void playDecisionRes() {
		audio.clip=decisionResolution;
		audio.Play();
	}
	public void playDecisionPrompt() {
		audio.clip=decisionPrompt;
		audio.Play();
	}

}
