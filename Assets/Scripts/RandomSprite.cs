using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSprite : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite[] sprites;
    void Start()
    {
        int randomValue = Random.Range(0, sprites.Length);
        this.gameObject.GetComponent<SpriteRenderer>().sprite = sprites[randomValue];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
