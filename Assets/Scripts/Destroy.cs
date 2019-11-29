using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    public static float timeLeftIni = 2;
    public float timeActiveAgain = 2;
    bool destroying = false;
    public float timeLeft = timeLeftIni;
    public void DestroyIt() {
        destroying = true;
    }
    void Update() {
        if (destroying == true) {
            timeLeft -= Time.deltaTime;
            if(timeLeft < 0) {
                // this.gameObject.SetActive(false);
                this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            }
            if (timeLeft < -timeActiveAgain) {
                timeLeft = timeLeftIni;
                this.gameObject.GetComponent<BoxCollider2D>().enabled = true;
                this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
                destroying = false;
            }
        }
    }
}
