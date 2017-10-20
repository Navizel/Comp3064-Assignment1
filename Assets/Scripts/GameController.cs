﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
	[SerializeField]
	GameObject rock;
	[SerializeField]
	GameObject rock2;
	[SerializeField]
	Text lifeLabel;
	[SerializeField]
	Text scoreLabel;
	[SerializeField]
	Text gameOverLabel;
	[SerializeField]
	Text highScoreLabel;
	[SerializeField]
	Button restartBtn;

	private void initialize() {
		Player.Instance.Score = 0;
		Player.Instance.Life = 3;

		gameOverLabel.gameObject.SetActive (false);
		highScoreLabel.gameObject.SetActive (false);
		restartBtn.gameObject.SetActive (false);
		lifeLabel.gameObject.SetActive (true);
		scoreLabel.gameObject.SetActive (true);
		StartCoroutine ("AddEnemy");
	}

	// Use this for initialization
	void Start () {
		Player.Instance.gCtrl = this;
		initialize ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void gameOver(){
		gameOverLabel.gameObject.SetActive (true);
		highScoreLabel.gameObject.SetActive (true);
		restartBtn.gameObject.SetActive (true);

		lifeLabel.gameObject.SetActive (false);
		scoreLabel.gameObject.SetActive (false);
		highScoreLabel.text = "High Score: " + Player.Instance.Score;
	}

	public void updateUI(){

		scoreLabel.text = "Score: " + Player.Instance.Score;
		lifeLabel.text = "Life: " + Player.Instance.Life;
	}

	public void RestartBtnClick() {
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}

	private IEnumerator AddEnemy(){
		int time = Random.Range (1, 10);
		yield return new WaitForSeconds ((float)time);
		Instantiate (rock);
		StartCoroutine ("AddEnemy");
	}
}