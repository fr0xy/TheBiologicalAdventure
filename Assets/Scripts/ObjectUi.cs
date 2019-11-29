using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectUi : MonoBehaviour
{
    public int objectNumber;
    // Update is called once per frame
    void Update()
    {
        if (objectNumber == 0) {
            if (DataManagement.dataManagement.erlen) {
                this.GetComponent<Image>().enabled = true;
            }
        } else if (objectNumber == 1) {
            if (DataManagement.dataManagement.micro) {
                this.GetComponent<Image>().enabled = true;
            }
        } else if (objectNumber == 2) {
            if (DataManagement.dataManagement.pipette) {
                this.GetComponent<Image>().enabled = true;
            }
        } else if (objectNumber == 3) {
            if (DataManagement.dataManagement.plasmide) {
                this.GetComponent<Image>().enabled = true;
            }
        }
    }
}
