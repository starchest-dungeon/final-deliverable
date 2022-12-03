using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
source: https://www.youtube.com/watch?v=qkBlPiUNslI
*/

public class KeyMovement : MonoBehaviour {

    private bool isFollowing;
    public float followSpeed;
    public Transform followTarget;

    void Start() {
        //isFollowing = true;
    }

    void Update() {
        if (isFollowing) {
            transform.position = Vector3.Lerp(transform.position, followTarget.position, followSpeed * Time.deltaTime);
        }
    }

    void OnTriggerEnter2D(Collider2D col) {
        if (!isFollowing) {
            ProtagonistBehaviour thePlayer = FindObjectOfType<ProtagonistBehaviour>();
            followTarget = thePlayer.transform;
            thePlayer.followingKey = this;
            isFollowing = true;
        }
    }
}
