/*
Source file name: BackgroundController.cs
Author: Mark Jerome Villamor
Last Modified by: Mark Jerome Villamor
Date Last Modified: 20-10-2017
Program Description: This script controls the movement of the background
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour {

	[SerializeField]
	private float speed = 5f;
	[SerializeField]
	private float startX;
	[SerializeField]
	private float endX;


	private Transform _transform;
	private Vector2 _currentPos;

	// Use this for initialization
	void Start () {
		_transform = gameObject.GetComponent<Transform> ();
		_currentPos = _transform.position;
		Reset ();
	}

	//background move
	// Update is called once per frame
	void Update () {
		_currentPos = _transform.position;
		_currentPos -= new Vector2 (speed, 0);

		if (_currentPos.x < endX) {
			Reset ();
		}
		_transform.position = _currentPos;
		
	}

	//resets background position
	private void Reset() {
		_currentPos = new Vector2 (startX, 0);
	}
}
