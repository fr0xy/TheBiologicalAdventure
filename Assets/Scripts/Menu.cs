using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{
    public GameObject menuUI;
    public GameObject helpMenuUI;
    public void StartGame () {
        SceneManager.LoadScene("Level_1");
        DataManagement.dataManagement.LoadData();
        DataManagement.dataManagement.level = 1;
        DataManagement.dataManagement.life = 5;
        DataManagement.dataManagement.counter = 0;
        DataManagement.dataManagement.micro = false;
        DataManagement.dataManagement.erlen = false;
        DataManagement.dataManagement.pipette = false;
        DataManagement.dataManagement.plasmide = false;
        DataManagement.dataManagement.SaveData();
    }
    public void LoadHelp() {
        helpMenuUI.SetActive(true);
        menuUI.SetActive(false);
    }
    public void BackToMenuFromHelp() {
        menuUI.SetActive(true);
        helpMenuUI.SetActive(false);
    }
    public void Quit() {
        Application.Quit();
    }
}
