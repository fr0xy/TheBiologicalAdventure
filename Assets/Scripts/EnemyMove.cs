using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour {

    public int enemySpeed;
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
        RaycastHit2D hit = Physics2D.Raycast (transform.position, new Vector2 (xMoveDir, 0));
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(xMoveDir, 0) * enemySpeed;
        // if (hit.collider && hit.distance < 0.5f && hit.collider.tag == "Player") {
        //     Debug.Log(hit.collider.gameObject.name);
        //     StartCoroutine(GameObject.FindGameObjectWithTag("Script").GetComponent<Player_Health>().Die());
        //     // hit.collider.gameObject.GetComponent<Player_Health>().Die();
        //     // Destroy(hit.collider.gameObject);
        // }
        Flip();
    }
    void Flip () {
        if (gameObject.transform.position.x > endX)
        {
            // GetComponent<SpriteRenderer>().flipX = true;
            this.gameObject.transform.localScale = new Vector3(-0.4f, 0.4f, 1);
            xMoveDir = -1;
        }
        if (gameObject.transform.position.x < startX)
        {
            // this.gameObject.transform.Rotate(0,0,0);
            this.gameObject.transform.localScale = new Vector3(0.4f, 0.4f, 1);
            // GetComponent<SpriteRenderer>().flipX = false;
            xMoveDir = 1;
        }
    }
}