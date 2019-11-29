using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject TutorialUimage;
    public Sprite[] images;
    void OnTriggerEnter2D (Collider2D trig) {
        if (trig.gameObject.tag == "Tuto" && TutorialUimage != null) {
            TutorialUimage.SetActive(true);
            TutorialUimage.gameObject.GetComponent<Image>().sprite = images[trig.gameObject.GetComponent<TutorialText>().imageIdx];
        }
        if (trig.gameObject.name == "EndTutorial") {
            TutorialUimage.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
