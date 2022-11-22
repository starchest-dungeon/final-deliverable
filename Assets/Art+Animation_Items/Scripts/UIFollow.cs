using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIFollow : MonoBehaviour
{
    public Transform objectFollow;
    RectTransform rectTransform;

    private void Awake() {
        rectTransform = GetComponent<RectTransform>();
    }

    private void Update() {
        if (objectFollow != null) {
            rectTransform.anchoredPosition = objectFollow.localPosition;
        }
    }
}
