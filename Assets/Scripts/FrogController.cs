/*
Source file name: FrogController.cs
Author: Mark Jerome Villamor
Last Modified by: Mark Jerome Villamor
Date Last Modified: 20-10-2017
Program Description: This script controls the movement of the frog
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogController : MonoBehaviour {

	//public variables
	[SerializeField]
	private float speed = 5f;
	[SerializeField]
	private float startY = 1110;
	[SerializeField]
	private float endY = -1110;
	[SerializeField]
	private float startX;
	[SerializeField]
	private float endX;

	//private variables
	private Transform _transform;
	private Vector2 _currentPos;

	// Use this for initialization
	void Start () {
		_transform = gameObject.GetComponent<Transform> ();
		_currentPos = _transform.position;
		Reset ();
	}
	
	// Update is called once per frame
	void Update () {
		_currentPos = _transform.position;
		//move right to left
		_currentPos -= new Vector2 (speed,0);

		//check for reset
		if (_currentPos.x < endX) {
			Reset ();
		}
		_transform.position = _currentPos;
	}

	//reset position of frog
	private void Reset() {
		float y = Random.Range (startY, endY);
		float dx = Random.Range (100,0);
		_currentPos = new Vector2 (startX + dx, y);
	}
}
