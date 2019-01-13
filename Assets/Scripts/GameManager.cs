using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public GameObject currentCheckPoint;

    private PlayerController player;

    private GameObject objects;

    public GameObject prefabObjects;

	// Use this for initialization
	void Start () {
        player = FindObjectOfType<PlayerController>();
        objects = GameObject.FindWithTag("Objects");
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.R)) {
            RespawnPlayer();
        }
	}

    public void RespawnPlayer() {

        Vector3 temp = new Vector3(0, 0, -4.0f);
        player.transform.position = currentCheckPoint.transform.position;
        player.transform.position += temp;
        player.jumpCount = 5;
        Vector3 pos = objects.transform.position;
        Quaternion rot = objects.transform.rotation;
        Destroy(objects);
        objects = Instantiate(prefabObjects, pos, rot);
        if (!player.facingRight) {
            player.Flip();
        }
    }
}
