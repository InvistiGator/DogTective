using UnityEngine;
using System.Collections;

public class audio5Script : MonoBehaviour {
	//
	public AudioSource audio;

	public AudioClip doorClose;

	// Use this for initialization
	void Awake () {
		audio = GetComponent<AudioSource>();
	}
	void Start(){
		
	}

	public void playDoorClose(){
		audio.clip = doorClose;
		audio.Play();	
	}

}
