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

    //Audio
    AudioSource audioSource;
    public AudioClip[] audioClips;
    public bool audioPlayedOnce;

    //Star
    public Animator floatAnim;

    void Start() {
		rock = GetComponent<Rigidbody>();
		player = GetComponent<Rigidbody>();
		anim = GetComponent<Animator>();
		isNearRock = false;
		isTurnedOver = false;
        audioSource = GetComponent<AudioSource>();
        // openText = "Press T.";
    }

	// When player presses "t" the rock turns over
	void Update() {
		// check if player is near rock and rock isn't turned over yet
		if (isNearRock && isTurnedOver == false) {
			// noooo looping
			if(Input.GetKeyDown("x"))
			{
                //trigger animations
				anim.SetTrigger("isTurnedOver");
				isTurnedOver = true;
                floatAnim.SetTrigger("float");
                //reset
                player.gameObject.GetComponent<StarCollector>().interacted = false;

                if (!audioPlayedOnce)
                {
                    audioSource.PlayOneShot(audioClips[0], 0.7f);
                    audioSource.PlayOneShot(audioClips[1], 1.0f);
                    audioPlayedOnce = true;
                }
            }
		}
	}

	void OnTriggerEnter(Collider other) {
		if(other.gameObject.CompareTag("Player")) {
			isNearRock = true;
            other.gameObject.GetComponent<StarCollector>().isNearRock = true;
		}
	}

	void OnTriggerExit(Collider other) {
		if(other.gameObject.CompareTag("Player")) {
			isNearRock = false;
            other.gameObject.GetComponent<StarCollector>().isNearRock = false;
		}
	}
	
}
