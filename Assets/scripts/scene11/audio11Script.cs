using UnityEngine;
using System.Collections;

public class audio11Script : MonoBehaviour {
	//
	public AudioSource audio;

	/*public AudioClip doorOpenQuickly;
	public AudioClip decisionPrompt;
	public AudioClip decisionRes;*/
	public AudioClip clockTick;
	public AudioClip var213;
	public AudioClip click;
	public AudioClip pat213;

	// Use this for initialization
	void Awake () {
		audio = GetComponent<AudioSource>();
	}
	void Start(){
		
	}
	/*public void playDoorOpen(){
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
	}*/
	public void playClockTicking() {
		audio.clip = clockTick;
		audio.Play();
	}
	public void play213Various() {
		audio.clip = var213;
		audio.Play();
	}
	public void play213() {
		audio.clip = pat213;
		audio.Play();
	}
	public void playClick() {
		audio.clip = click;
		audio.Play();
	}
}