using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//source: https://stackoverflow.com/questions/65816546/unity-camera-follows-player-script#:~:text=Making%20the%20camera%20following%20the,to%20be%20from%20the%20player.

public class Camera_FollowPlayer : MonoBehaviour {

    public Transform player;

    void Update () {
        transform.position = player.transform.position + new Vector3(0, 1, -5);
    }
}
