using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionTrigger : MonoBehaviour
{
    public string sceneName;

    public void Trigger() {
        if (sceneName == "Quit") {
            Application.Quit();
        } else {
            SceneManager.LoadScene(sceneName);
        }
    }
}
