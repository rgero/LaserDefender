﻿using UnityEngine;
using System.Collections;

public class enemy2Spawner : MonoBehaviour {

	private Vector3 position;
	public GameObject enemy2Prefab;
	public Transform childTo;
	private GameObject created;
	private float timeDelay;
	private int score;




	// Use this for initialization
	void Start () {
		created = new GameObject ();
		created.name = "Second Enemy Ships";
		childTo = created.transform;
		timeDelay = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		score = ScoreKeeper.getScore ();
		if (score >= GameConstants.ENEMY2_MIN_SPAWN_SCORE) {
			timeDelay += Time.deltaTime;
			if (childTo.childCount < 3 && timeDelay >= GameConstants.ENEMY2_SPAWN_DELAY) {
				position.x = Random.Range (GameConstants.ENEMY2_MIN, GameConstants.ENEMY2_MAX);
				position.y = Random.Range (-2.5f, GameConstants.ENEMY2_MAX); //TODO: FIX THIS. Enemies can spawn below Y threshold
				created.transform.position = position;
				GameObject enemy2Ship = Instantiate (enemy2Prefab) as GameObject;
				enemy2Ship.transform.parent = childTo;
				if (enemy2Ship.transform.position != position) {
					enemy2Ship.transform.position = position;
				}
				timeDelay = 0f;
			}
		}
	}
}
