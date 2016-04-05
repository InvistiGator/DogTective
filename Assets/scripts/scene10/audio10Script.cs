using UnityEngine;
using System.Collections;

public class audio10Script : MonoBehaviour {
	//
	public AudioSource audio;

	public AudioClip doorOpenQuickly;
	public AudioClip decisionPrompt;
	public AudioClip decisionRes;
	public AudioClip clockTick;

	// Use this for initialization
	void Awake () {
		audio = GetComponent<AudioSource>();
	}
	void Start(){
		
	}
	public void playDoorOpen(){
		audio.clip = doorOpenQuickly;
		audio.Play();	
	}
	public void playDecisionPrompt(){
		audio.clip = decisionPrompt;
		audio.Play();	
	}
	public void playDecisionResolution(){
		audio.clip = decisionRes;
		audio.Play();	
	}
	public void playClockTicking() {
		audio.clip = clockTick;
		audio.Play();
	}
}