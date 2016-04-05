using UnityEngine;
using System.Collections;

public class audio27Script : MonoBehaviour {
	//
	public AudioSource audio;

	public AudioClip typing;

	// Use this for initialization
	void Awake () {
		audio = GetComponent<AudioSource>();
	}
	void Start(){
		
	}

	public void playTyping() {
		audio.clip=typing;
		audio.Play();
	}

}
