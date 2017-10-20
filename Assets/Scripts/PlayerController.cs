/*
Source file name: PlayerController.cs
Author: Mark Jerome Villamor
Last Modified by: Mark Jerome Villamor
Date Last Modified: 20-10-2017
Program Description: This script allows player to move around the game
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	//public variables
	[SerializeField]
	private float speed = 10f;
	[SerializeField]
	private float upY;
	[SerializeField]
	private float downY;
	[SerializeField]
	private float leftX;
	[SerializeField]
	private float rightX;

	private Transform _transform;
	private Vector2 _currentPos;

	// Use this for initialization
	void Start () {
		_transform = gameObject.GetComponent<Transform> ();
		_currentPos = _transform.position;
	}
	
	// Update is called once per frame
	//move plane
	void Update () {
		_currentPos = _transform.position;

		float userInputY = Input.GetAxis ("Vertical");
		float userInputX = Input.GetAxis ("Horizontal");
		if (userInputY < 0) {
			_currentPos -= new Vector2 (0,speed);
		}
		if (userInputY > 0) {
			_currentPos += new Vector2 (0,speed);
		}
		if (userInputX < 0) {
			_currentPos -= new Vector2 (speed,0);
		}
		if (userInputX > 0) {
			_currentPos += new Vector2 (speed,0);
		}
		CheckBounds ();
		_transform.position = _currentPos;
	}

	//plane cant get past bounds
	private void CheckBounds(){
		if (_currentPos.y > upY) {
			_currentPos.y = upY;
		}
		if (_currentPos.y < downY) {
			_currentPos.y = downY;
		}
		if (_currentPos.x < leftX) {
			_currentPos.x = leftX;
		}
		if (_currentPos.x > rightX) {
			_currentPos.x = rightX;
		}
	}
}
