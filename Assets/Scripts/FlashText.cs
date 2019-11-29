using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FlashText : MonoBehaviour
{
    private float reference = 1f;
    private float timeLeft = 1f;
    void Update()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0) {
            this.gameObject.GetComponent<Text>().enabled = !this.gameObject.GetComponent<Text>().enabled;
            timeLeft = reference;
        }
        if (Input.GetKeyDown(KeyCode.Space)) {
            SceneManager.LoadScene("Menu");
        }
    }
}
