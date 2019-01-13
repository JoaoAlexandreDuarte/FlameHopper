using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour {

    public PlayerController player;
    private bool isActive = true;
    Animator anim;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

        if (name == "Image1") {
            isActive = player.jumpCount >= 1 ? true : false;
            anim.SetBool("active", isActive);
        } else if (name == "Image2") {
            isActive = player.jumpCount >= 2 ? true : false;
            anim.SetBool("active", isActive);
        } else if (name == "Image3") {
            isActive = player.jumpCount >= 3 ? true : false;
            anim.SetBool("active", isActive);
        } else if (name == "Image4") {
            isActive = player.jumpCount >= 4 ? true : false;
            anim.SetBool("active", isActive);
        } else if (name == "Image5") {
            isActive = player.jumpCount >= 5 ? true : false;
            anim.SetBool("active", isActive);
        }
	}
}
