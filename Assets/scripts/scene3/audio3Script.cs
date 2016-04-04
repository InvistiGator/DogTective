using UnityEngine;
using System.Collections;

public class audio3Script : MonoBehaviour {
	//
	public AudioSource audio;

	public AudioClip doorKnock;
	public AudioClip doorOpenQuickly;
	public AudioClip decisionPrompt;
	public AudioClip decisionRes;
	public AudioClip doorCloseQuickly;

	// Use this for initialization
	void Awake () {
		audio = GetComponent<AudioSource>();
	}
	void Start(){
		
	}

	public void playDoorKnock() {
		audio.clip = doorKnock;
		audio.Play();
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

	public void playDoorClose(){
		audio.clip = doorCloseQuickly;
		audio.Play();	
	}
	
}