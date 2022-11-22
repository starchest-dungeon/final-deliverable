using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRotate : MonoBehaviour {

    public SpriteRenderer fireRender;
    public GameObject player;
    private Vector2 mouse;

    void Start() {
        
    }


    void Update() {

        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        difference.Normalize();
        float rotation_z = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotation_z - 90);
        
        /*
        reference: https://answers.unity.com/questions/640162/detect-mouse-in-right-side-or-left-side-for-player.html
        */
        mouse = new Vector2(Input.mousePosition.x, Screen.height - Input.mousePosition.y);

        var playerScreenPoint = Camera.main.WorldToScreenPoint(player.transform.position);
        if(mouse.x < playerScreenPoint.x) {
            fireRender.flipY = true;
        } else {
            fireRender.flipY = false;
        }
    }
}
