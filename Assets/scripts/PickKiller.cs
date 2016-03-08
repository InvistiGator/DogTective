using UnityEngine;
using System.Collections;

public class PickKiller : MonoBehaviour {

	static public int randomizedKiller;


	//the actual meto to pick the killer
	public int pickKillerRand(){
	//Random rnd = new Random();
		//generate a random number from 0 to 6
		randomizedKiller = Random.Range(0,7);
		//randomizedKiller = 
		return randomizedKiller;
	}

	public int getRandomizedKiller(){
		//return the int stored in randomizedKiller: int
		return randomizedKiller; 
	}
}
