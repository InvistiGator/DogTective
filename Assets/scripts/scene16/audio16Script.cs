using UnityEngine;
using System.Collections;

public class audio16Script : MonoBehaviour {
	//
	public AudioSource audio;

	public AudioClip decisionResolution;
	public AudioClip decisionPrompt;
	public AudioClip click;

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

	public void playClick() {
		audio.clip = click;
		audio.Play();
	}

}
