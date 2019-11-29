using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour
{
    public GameObject ObjectToGet;
    public Dialogue dialogue;
    private bool isPlaying = true;
    void OnTriggerEnter2D (Collider2D trig) {
        if (trig.gameObject.tag == "EndLevel") {
            if (ObjectToGet != null && ObjectToGet.activeSelf == true) {
                FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
            } else {
                if (DataManagement.dataManagement.level == 14) {
                    SceneManager.LoadScene("Credits");
                }  else {
                    saveLevel();
                }
            }
        }
    }
    void saveLevel() {
        Debug.Log("Data says level is : " + DataManagement.dataManagement.level);
        DataManagement.dataManagement.level++;
        DataManagement.dataManagement.counter = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Coin_Counter>().counter;
        DataManagement.dataManagement.SaveData();
        SceneManager.LoadScene("Level_" + DataManagement.dataManagement.level);
        Debug.Log("Data says level is now : " + DataManagement.dataManagement.level);
    }
}
