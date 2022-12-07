using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AmmoText : MonoBehaviour {

    public FirearmBehaviour weapon;
    public TextMeshProUGUI text;

    void Start() {
        UpdateAmmoTest();
    }

    void Update() {
        UpdateAmmoTest();
    }

    public void UpdateAmmoTest() {
        text.text = $"bullets: {weapon.currentClip}        bullet storage: {weapon.currentAmmo}";
    }
}
