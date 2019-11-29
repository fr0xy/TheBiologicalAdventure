using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectil : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerEnter2D (Collider2D trig) {
        Debug.Log(trig.gameObject.tag);
        if (trig.gameObject.tag == "Projectil") {
            StartCoroutine(GameObject.FindGameObjectWithTag("Script").GetComponent<Player_Health>().Die());
        }
        if (trig.gameObject.tag == "Object") {
            int value = trig.gameObject.GetComponent<objectGet>().value;
            Debug.Log("Valeur: " + value);
            if (value == 0) {
                DataManagement.dataManagement.erlen = true;
            } else if (value == 1) {
                DataManagement.dataManagement.micro = true;
            } else if (value == 2) {
                DataManagement.dataManagement.pipette = true;
            } else if (value == 3) {
                DataManagement.dataManagement.plasmide = true;
            }
            trig.gameObject.SetActive(false);
        }
    }
}
