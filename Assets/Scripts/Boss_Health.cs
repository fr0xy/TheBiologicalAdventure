using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Health : MonoBehaviour
{
    public int life;
    private float timeLeft = 0;
    public GameObject objectToGet;
    public Dialogue dialogue;
    public int value;
    void Update()
    {
        timeLeft -= Time.deltaTime;
        if (gameObject.transform.position.y <= -10) {
            Destroy(gameObject);
        }
    }
    public void loseLife() {
        if (timeLeft <= 0) {
            life--;
            timeLeft = 1f;
        }
        if (life == 0 && objectToGet) {
            GameObject tmp = (GameObject) Instantiate(objectToGet, this.transform.position, Quaternion.Euler(new Vector3(0,0,0)));
            tmp.GetComponent<objectGet>().value = value;
            GameObject.FindGameObjectWithTag("Player").GetComponent<EndLevel>().ObjectToGet = tmp;
        }
        if (life == 0 && dialogue.name != "") {
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        }
    }
}
