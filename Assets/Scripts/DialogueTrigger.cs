using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public void TriggerDialogue() {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
    void OnTriggerEnter2D (Collider2D trig) {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
    void OnTriggerExit2D (Collider2D trig) {
        this.gameObject.SetActive(false);
    }
}
