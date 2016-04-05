using UnityEngine;
using System.Collections;

public class audio42Script : MonoBehaviour {
	//
	public AudioSource audio;

	public AudioClip decisionPrompt;
	public AudioClip decisionRes;
	public AudioClip doorOpeningQuickly;

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
	public void playDoorOpen() {
		audio.clip=doorOpeningQuickly;
		audio.Play();
	}

}
