using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectGet : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite[] sprites;
    public int value;
    void Start()
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = sprites[value];
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
