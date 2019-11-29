using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Player_Coin_Counter : MonoBehaviour
{
    // Start is called before the first frame update
    public int counter = 0;
    public GameObject counterUI;
    public AudioClip MusicClip;
    public AudioSource MusicSource;

    // Update is called once per frame
    void Start () { 
        DataManagement.dataManagement.LoadData(); // DevOnly
        counter = DataManagement.dataManagement.counter;
    }
    void Update()
    {
        counterUI.gameObject.GetComponent<Text>().text = "" + (counter * 5) + "%";
    }

    void OnTriggerEnter2D (Collider2D trig) {
        if (trig.gameObject.tag == "Coin") {
            MusicSource.clip = MusicClip;
            MusicSource.Play();
            counter++;
            if (counter >= 20) {
                counter = 0;
                GameObject.FindGameObjectWithTag("Script").GetComponent<Player_Health>().GainLife();
            }
            Destroy (trig.gameObject);
        }
    }
}
