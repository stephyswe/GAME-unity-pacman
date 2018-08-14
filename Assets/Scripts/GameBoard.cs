﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBoard : MonoBehaviour {

	private static int boardWidth = 28;
	private static int boardHeight = 36;

	public int totalPellets = 0;
	public int score = 0;

	public GameObject[,] board = new GameObject[boardWidth, boardHeight];

	// Use this for initialization
	void Start () {

		// Getting all Objects in the Scene
		Object[] objects = GameObject.FindObjectsOfType(typeof(GameObject));

		// Looping over all Objects
		foreach (GameObject o in objects)
		{
			// Get current position of the Object iterating over 
			Vector2 pos = o.transform.position;

			// Checks name of the Object that was Found - Pellets = Empty.
			if (o.name != "PacMan" && o.name != "Nodes" && o.name != "NonNodes" 
									&& o.name != "Maze" && o.name != "Pellets" && o.name != "bottom_left_corner_single") {
				
				// If Object is a Tile Component [ Pellet, Node or Portal ]
				if (o.GetComponent<Tile> () != null ) {

					// If Object is (Super) Pellet - Increase totalPellets by 1. 
					if (o.GetComponent<Tile> ().isPellet || o.GetComponent<Tile> ().isSupperPellet) {
						totalPellets++;
					}
				}

				// Adding Object to Board array at pos x and y where it occurs			
				board [(int)pos.x, (int)pos.y] = o;
			} else {
				Debug.Log ("Found PacMan at: " +pos);
			}
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
