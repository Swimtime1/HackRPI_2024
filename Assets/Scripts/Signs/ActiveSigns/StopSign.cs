using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEditor.UI;
using UnityEngine;

public class StopSign : MonoBehaviour {
	public GameObject car;
	private int stop = 0;
	public GameObject correct;
	public GameObject late;
	public GameObject early;
	private Vector3 pos;

	// Start is called before the first frame update
	void Start () {
		pos = transform.position;
	}

	// Update is called once per frame
	void Update () {
		float posX = gameObject.transform.position.x;
		float distance = Mathf.Abs (car.transform.position.x - posX);
		bool play = GameManager.gameActive;
		//Debug.Log ("play: " + play);
		if ( play == true ) {
			float gameTime = Time.time;
			Debug.Log ("distance: " + distance);
			if ( distance < 6.2 && distance > 4.42 ) {
				if ( Input.GetButtonDown ("Stop") && stop >= 0 ) {
					stop++;
					Score.scoreType++;
					StartCoroutine (turnOff (correct));
				}
			}
			else if ( distance > 6.2 ) {
				if ( Input.GetButtonDown ("Stop") && stop >= 0 ) {
					StartCoroutine (turnOff (early));
				}
			}
			else if ( distance < 4.42 ) {
				if ( Input.GetButtonDown ("Stop") && stop >= 0 ) {
					StartCoroutine (turnOff (late));
				}
			}
		}

	}
	IEnumerator turnOff ( GameObject condition ) {
		condition.SetActive (true);
		yield return new WaitForSeconds (1);
		condition.SetActive (false);
	}
}
