using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VictoryScreen : MonoBehaviour
{
    public void SetUp() {
        gameObject.SetActive(true);
    }

    public void RestartButton() {
        SceneManager.LoadScene("Game");
    }

    public void ExitButton() {
        SceneManager.LoadScene("MainMenu");
    }
}
