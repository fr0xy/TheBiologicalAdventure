using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelStart : MonoBehaviour
{
    public GameObject StartImageUI;
    public float timeLeft = 2f;
    private bool isLoaded = false;
    public string levelName;
    
    void Update() {
        if (!isLoaded && DataManagement.dataManagement.level != 0) {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Monkey_move>().enabled = false;
            isLoaded = true;
        }
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0) {
            StartImageUI.SetActive(false);
            GameObject.FindGameObjectWithTag("Player").GetComponent<Monkey_move>().enabled = true;
            this.enabled = false;
        }
    }
}
