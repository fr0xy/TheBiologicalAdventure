using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatFormMove : MonoBehaviour {

    public float speed = 1f;
    public int xMoveDir;
    private float startX;
    public float endX;

 // Use this for initialization
 void Start () {
        xMoveDir = 1;
        startX = gameObject.transform.position.x;
        if (endX < startX) {
            endX = startX + 4;
        }
 }
 
 // Update is called once per frame
 void Update () {
        Flip();
        gameObject.transform.position = new Vector3( gameObject.transform.position.x + speed, gameObject.transform.position.y, gameObject.transform.position.z); 
    }
    void Flip () {
        if (gameObject.transform.position.x > endX || gameObject.transform.position.x < startX)
        {
            speed = speed * -1;
        }
    }
}