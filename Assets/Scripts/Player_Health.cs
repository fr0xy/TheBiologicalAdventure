using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player_Health : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    public GameObject LifeUi;
    public AudioClip GainLifeClip;
    public AudioClip LoseLifeClip;
    public AudioSource MusicSource;
    private bool isDying = false;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        DataManagement.dataManagement.LoadData(); // DevOnly
    }
    void Update() {
        LifeUi.gameObject.GetComponent<Text>().text = ("Life: " + DataManagement.dataManagement.life);
        if (player.transform.position.y <= -10 && isDying == false) {
            isDying = true;
            StartCoroutine(Die());
        }
    }
    public IEnumerator Die () {
        // SceneManager.LoadScene("Level_1");
        MusicSource.clip = LoseLifeClip;
        MusicSource.Play();
        DataManagement.dataManagement.life--;
        DataManagement.dataManagement.SaveData();
        Time.timeScale = 0f;
        yield return new WaitWhile(()=> MusicSource.isPlaying);
        Time.timeScale = 1f;
        if (DataManagement.dataManagement.life <= 0) {
            SceneManager.LoadScene("GameOver");
        } else {
            SceneManager.LoadScene("Level_" + DataManagement.dataManagement.level);
        }
    }
    public void GainLife () {
        MusicSource.clip = GainLifeClip;
        MusicSource.Play();
        DataManagement.dataManagement.life++;
        Debug.Log("Life : " + DataManagement.dataManagement.life);
    }
}
