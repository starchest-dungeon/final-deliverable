using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

/*
source: https://www.youtube.com/watch?v=qkBlPiUNslI
*/

public class BossDoorLogic : MonoBehaviour {

    private ProtagonistBehaviour thePlayer;

    public TilemapRenderer door;
    public TilemapCollider2D doorCol;

    public bool doorOpen, waitingToOpen;

    void Start() {
        thePlayer = FindObjectOfType<ProtagonistBehaviour>();
    }

    void Update() {
        if (waitingToOpen) {
            if (Vector3.Distance(thePlayer.followingKey.transform.position, transform.position) < 0.1f) {
                waitingToOpen = false;
                doorOpen = true;

                door.GetComponent<Renderer>().enabled = false;
                doorCol.GetComponent<TilemapCollider2D>().enabled = false;

                thePlayer.followingKey.gameObject.SetActive(false);
                thePlayer.followingKey = null;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D col) {
        if (col.tag == "Player") {
            if (thePlayer.followingKey != null) {
                thePlayer.followingKey.followTarget = transform;
                waitingToOpen = true;
            }
        }
    }
}
