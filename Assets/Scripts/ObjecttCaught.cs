using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjecttCaught : MonoBehaviour {

    public PlayerController player;

	// Use this for initialization
	void Start () {
        player = FindObjectOfType<PlayerController>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.name == "Player") {
            if (player.jumpCount < 5) {
                player.jumpCount++;
                Destroy(gameObject);
            }
        }
    }
}
