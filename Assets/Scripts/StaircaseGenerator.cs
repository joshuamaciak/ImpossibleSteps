using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * This script generates staircases in order to keep the illusion of 
 * a single endless staircase. To be efficient, this generator will only
 * use four staircases, and will work like a circular queue (FIFO).
 * 		[note: this can work with only 3 flights, but then we have to worry about rotation & modifying 
 * 			    x & z position. might not be worth it]
 * When Generate() is called, the staircase at the bottom will be moved to the top.
**/
public class StaircaseGenerator : MonoBehaviour {
	public List<GameObject> staircases; 	// the staircases in this generator. there will be at most 3 
	
	private int nextStaircaseToMove = 0; 	// an index that points to the staircase at the front of the queue
	
	void Start () {

	}
	
	/**
	 * Generates a new staircase at the top of the current staircase, thereby extending entire staircase.
	 **/
	void GenerateStaircase() {
		GameObject flightToMove = staircases[nextStaircaseToMove];
		float staircaseHeight = 3f * staircases.Count; // height * numflights. todo: this should be dynamic; not hardcoded
		flightToMove.transform.localPosition += new Vector3(0, staircaseHeight , 0);
		nextStaircaseToMove = (nextStaircaseToMove + 1) % staircases.Count;
	}
}
