﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionRock : MonoBehaviour
{
	private Rigidbody rock;
	private Rigidbody player;
	private Animator anim;	
	private bool isNearRock;
	public static bool isTurnedOver;
	// public String openText;

	void Start() {
		rock = GetComponent<Rigidbody>();
		player = GetComponent<Rigidbody>();
		anim = GetComponent<Animator>();
		isNearRock = false;
		isTurnedOver = false;
		// openText = "Press T.";
	}

	// When player presses "t" the rock turns over
	void Update() {
		// check if player is near rock and rock isn't turned over yet
		if (isNearRock && isTurnedOver == false) {
			// noooo looping
			if(Input.GetKeyDown("x"))
			{
				anim.SetTrigger("isTurnedOver");
				isTurnedOver = true;
			}
		}
	}

	void OnTriggerEnter(Collider other) {
		if(other.gameObject.CompareTag("Player")) {
			isNearRock = true;
		}
	}

	void OnTriggerExit(Collider other) {
		if(other.gameObject.CompareTag("Player")) {
			isNearRock = false;
		}
	}
	
}
