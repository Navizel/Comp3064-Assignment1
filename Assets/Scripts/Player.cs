/*
Source file name: Player.cs
Author: Mark Jerome Villamor
Last Modified by: Mark Jerome Villamor
Date Last Modified: 20-10-2017
Program Description: This script allows player to move around the game
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player {
	static private Player _instance;
	static public  Player Instance {
		get {
			if (_instance == null) {
				_instance = new Player ();
			}
			return _instance;
		}
	}

	private Player() {
	
	}

	public GameController gCtrl;

	private int _score = 0;
	private int _life = 3;

	public int Score {
		get{ return _score; }
		set{
			_score = value;
			gCtrl.updateUI();
		}
	}

	public int Life {
		get{ return _life; }
		set {
			_life = value;

			if (_life <= 0) {
				gCtrl.gameOver ();
			} else {
				gCtrl.updateUI ();
			}
		}
	}
}
