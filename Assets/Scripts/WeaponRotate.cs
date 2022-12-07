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
        /*
        if (transform.localScale.x == 1.1f)
         {
             Vector3 mousePos = Input.mousePosition;
             mousePos.z = 5.23f;
 
             Vector3 gunPos = Camera.main.WorldToScreenPoint(transform.position);
             mousePos.x = mousePos.x - objectPos.x;
             mousePos.y = mousePos.y - objectPos.y;
 
             float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
             transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
         }
         else if (transform.localScale.x == -1.1f)
         {
             Vector3 mousePos = Input.mousePosition;
             mousePos.z = 5.23f;
 
             Vector3 gunPos = Camera.main.WorldToScreenPoint(transform.position);
             mousePos.x = mousePos.x - objectPos.x;
             mousePos.y = mousePos.y - objectPos.y;
 
             float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
             transform.rotation = Quaternion.Euler(new Vector3(0, 0, -angle));
         }*/
        
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        difference.Normalize();
        float rotation_z = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotation_z - 90);
        
        //
        //reference: https://answers.unity.com/questions/640162/detect-mouse-in-right-side-or-left-side-for-player.html
        //
        mouse = new Vector2(Input.mousePosition.x, Screen.height - Input.mousePosition.y);

        var playerScreenPoint = Camera.main.WorldToScreenPoint(player.transform.position);
        if(mouse.x < playerScreenPoint.x) {
            fireRender.flipY = true;
        } else {
            fireRender.flipY = false;
        }
        /*
        if (player.transform.localScale.x == 1.1f) {
            fireRender.flipX = false;
        } else if (player.transform.localScale.x == -1.1f) {
            fireRender.flipX = true;
        }*/
    }
}
