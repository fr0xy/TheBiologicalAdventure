using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
public class DataManagement : MonoBehaviour
{
    public static DataManagement dataManagement;
    public int level;
    public int counter;
    public int life;
    public bool erlen;
    public bool micro;
    public bool pipette;
    public bool plasmide;
    void Awake () {
        if (dataManagement == null) {
            DontDestroyOnLoad (gameObject);
            dataManagement = this;
        } else if (dataManagement != this) {
            Destroy(gameObject);
        }
    }
    public void SaveData() {
        BinaryFormatter BinForm = new BinaryFormatter(); // Creates a bin formatter
        FileStream file = File.Create(Application.persistentDataPath + "/gameInfo.dat"); // Creates File
        gameData data = new gameData(); //Container for data
        data.level = level;
        data.counter = counter;
        data.life = life;
        data.erlen = erlen;
        data.micro = micro;
        data.pipette = pipette;
        data.plasmide = plasmide;
        BinForm.Serialize (file, data);
        file.Close();
    }
    public void LoadData() {
        if (File.Exists (Application.persistentDataPath + "/gameInfo.dat")) {
            BinaryFormatter BinForm = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/gameInfo.dat", FileMode.Open);
            gameData data = (gameData)BinForm.Deserialize(file);
            file.Close();
            level = data.level;
            counter = data.counter;
            life = data.life;
            erlen = data.erlen;
            micro = data.micro;
            pipette = data.pipette;
            plasmide = data.plasmide;
        }
    }
}
[Serializable]
class gameData {
    public int level;
    public int counter;
    public int life;
    public bool erlen;
    public bool micro;
    public bool pipette;
    public bool plasmide;

}