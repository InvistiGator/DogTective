using UnityEngine;
using System.Collections;

public class audio29Script : MonoBehaviour {
	//
	public AudioSource audio;

	public AudioClip knocking;
	public AudioClip doorOpening;
	public AudioClip doorClosingQuickly;

	// Use this for initialization
	void Awake () {
		audio = GetComponent<AudioSource>();
	}
	void Start(){
		
	}

	public void playKnocking() {
		audio.clip=knocking;
		audio.Play();
	}
	public void playDoorOpen() {
		audio.clip=doorOpening;
		audio.Play();
	}
	public void playDoorClose() {
		audio.clip=doorClosingQuickly;
		audio.Play();
	}

}
