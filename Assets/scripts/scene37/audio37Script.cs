using UnityEngine;
using System.Collections;

public class audio37Script : MonoBehaviour {
	//
	public AudioSource audio;

	public AudioClip decisionPrompt;
	public AudioClip decisionRes;
	public AudioClip ticking;

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
	public void playTicking() {
		audio.clip=ticking;
		audio.Play();
	}

}
