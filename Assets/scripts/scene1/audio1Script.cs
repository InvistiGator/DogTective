using UnityEngine;
using System.Collections;

public class audio1Script : MonoBehaviour {
	//
	public AudioSource audio;

	/*public AudioClip decisionPrompt;
	public AudioClip decisionRes;
	public AudioClip bloodEvent;*/

	public AudioClip clockTicking;
	public AudioClip doorOpenQuickly;
	public AudioClip doorCloseQuickly;
	public AudioClip phoneVibrating;

	// Use this for initialization
	void Awake () {
		audio = GetComponent<AudioSource>();
	}
	void Start(){
		
	}
	/*public void playDecisionPrompt(){
		audio.clip = decisionPrompt;
		audio.Play();
	}
	public void playDecisionRes(){
		audio.clip = decisionRes;
		audio.Play();
	}
	public void playBloodEvent(){
		audio.clip = bloodEvent;
		audio.Play();	
	}*/
	public void playDoorOpen(){
		audio.clip = doorOpenQuickly;
		audio.Play();	
	}

	public void playDoorClose(){
		audio.clip = doorCloseQuickly;
		audio.Play();	
	}

	public void playClockTick(){
		audio.clip = clockTicking;
		audio.Play();	
	}

	public void playPhoneVibrating(){
		audio.clip = phoneVibrating;
		audio.Play();	
	}
	
}
