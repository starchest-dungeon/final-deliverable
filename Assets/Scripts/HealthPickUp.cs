using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUp : MonoBehaviour
{
    public Player player;
    public int heal = 2;

    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag.Equals("Player")) {
            player.Heal(2);
            Destroy(gameObject);
        }
    }
}
