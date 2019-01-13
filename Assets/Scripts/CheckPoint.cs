using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour {

    public GameManager gm;
    public PlayerController player;
    Animator anim;

    // Use this for initialization
    void Start() {
        gm = FindObjectOfType<GameManager>();
        player = FindObjectOfType<PlayerController>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update () {
		if (gameObject != gm.currentCheckPoint) {
            anim.SetBool("active", false);
        }
	}

    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.name == "Player") {
            gm.currentCheckPoint = gameObject;
            player.jumpCount = 5;
            anim.SetBool("active", true);
        }
    }

    private void OnTriggerStay2D(Collider2D collision) {
        if (collision.name == "Player") {
            player.jumpCount = 5;
        }
    }
}
