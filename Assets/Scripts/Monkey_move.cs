using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monkey_move : MonoBehaviour
{
    public int playerSpeed = 10;
    private bool facingRight = true;
    public int playerJumpPower = 1250;
    private float moveX;
    public bool isGrounded;
    public float distanceToBottomOfPlayer = 0.73f;
    public AudioClip JumpClip;
    public AudioSource MusicSource;
    void Update() {
        PlayerMove ();
        PlayerRaycast();
    }
    
    void PlayerMove() {
        //CONTROLS
        moveX = Input.GetAxis("Horizontal");
        if ((Input.GetButtonDown("Jump") || Input.GetKeyDown("up")) && isGrounded == true) {
            Jump();
        }
        //Annimation
        if (moveX != 0) {
            GetComponent<Animator>().SetBool("IsRunning", true);
        }
        else {
            GetComponent<Animator>().SetBool("IsRunning", false);
        }
        //Player direction
        if (moveX < 0.0f && facingRight == true) {
            FlipePlayer();
        }
        else if (moveX > 0.0f && facingRight == false) {
            FlipePlayer();
        }
        //Physics
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2 (moveX * playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
    }
    void Jump() {
        MusicSource.clip = JumpClip;
        MusicSource.Play();
        //Jump
        GetComponent<Rigidbody2D>().AddForce (Vector2.up * playerJumpPower);
        GetComponent<Animator>().SetBool("IsJumping", true);
        isGrounded = false;
    }
    void FlipePlayer() {
        facingRight = !facingRight;
        GetComponent<SpriteRenderer>().flipX = !GetComponent<SpriteRenderer>().flipX;
    }
    void OnCollisionEnter2D (Collision2D col) {
        if (col.gameObject.tag == "Enemy" && this.gameObject.transform.position.y > col.gameObject.transform.position.y  + 1.5f) {
            killEnemy(col);
        }
        if (col.gameObject.tag == "Enemy" && this.gameObject.transform.position.y <= col.gameObject.transform.position.y  + 1.5f) {
            StartCoroutine(GameObject.FindGameObjectWithTag("Script").GetComponent<Player_Health>().Die());
        }
        if (col.gameObject.tag == "Boss" && this.gameObject.transform.position.y > col.gameObject.transform.position.y  + 1.5f) {
            killBoss(col);
        }
        if (col.gameObject.tag == "Boss" && this.gameObject.transform.position.y <= col.gameObject.transform.position.y  + 1.5f) {
            StartCoroutine(GameObject.FindGameObjectWithTag("Script").GetComponent<Player_Health>().Die());
        }
    }
    void PlayerRaycast () {
        float width = this.GetComponent<BoxCollider2D>().size.x;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down);
        RaycastHit2D hit2 = Physics2D.Raycast(new Vector2(transform.position.x - width / 2, transform.position.y), Vector2.down);
        RaycastHit2D hit3 = Physics2D.Raycast(new Vector2(transform.position.x + width / 2, transform.position.y), Vector2.down);
        if (hit.collider != null) {
            // if (hit.distance < distanceToBottomOfPlayer && hit.collider.tag == "Enemy") {
            //     killEnemy(hit);
            // }
            // if (hit.distance < distanceToBottomOfPlayer && hit.collider.tag == "Boss") {
            //     killBoss(hit);
            // }
            if (hit.distance < distanceToBottomOfPlayer && hit.collider.tag == "Destroying") {
                hit.collider.gameObject.GetComponent<Destroy>().DestroyIt();
            }
            if (hit.distance < distanceToBottomOfPlayer && hit.collider.tag != "Enemy") {
                GetComponent<Animator>().SetBool("IsJumping", false);
                isGrounded = true;
            }
            else {
                GetComponent<Animator>().SetBool("IsJumping", true);
                isGrounded = false;
            }
        } 
        // else if (hit2.collider != null) {
        //     if (hit2.distance < distanceToBottomOfPlayer && hit2.collider.tag == "Enemy") {
        //         killEnemy(hit2);
        //     }
        //     if (hit2.distance < distanceToBottomOfPlayer && hit2.collider.tag == "Boss") {
        //         killBoss(hit2);
        //     }
        // } else if (hit3.collider != null) {
        //     if (hit3.distance < distanceToBottomOfPlayer && hit3.collider.tag == "Enemy") {
        //         killEnemy(hit3);
        //     }
        //     if (hit3.distance < distanceToBottomOfPlayer && hit3.collider.tag == "Boss") {
        //         killBoss(hit3);
        //     }
        // }
    }
    void killEnemy(Collision2D col) {
        GetComponent<Rigidbody2D>().AddForce (Vector2.up * 1000);
        col.gameObject.GetComponent<Rigidbody2D>().AddForce (Vector2.right * 200);
        col.gameObject.GetComponent<Rigidbody2D>().freezeRotation = false;
        col.gameObject.GetComponent<Rigidbody2D>().gravityScale = 10;
        col.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        if (col.gameObject.GetComponent<EnemyMove>())
            col.gameObject.GetComponent<EnemyMove>().enabled = false;
    }
    void killBoss(Collision2D col) {
        GetComponent<Rigidbody2D>().AddForce (Vector2.up * 1000);
        col.gameObject.GetComponent<Boss_Health>().loseLife();
        if (col.gameObject.GetComponent<Boss_Health>().life <= 0) {
            col.gameObject.GetComponent<Rigidbody2D>().AddForce (Vector2.right * 200);
            col.gameObject.GetComponent<Rigidbody2D>().freezeRotation = false;
            col.gameObject.GetComponent<Rigidbody2D>().gravityScale = 10;
            col.gameObject.GetComponent<PolygonCollider2D>().enabled = false;
            col.gameObject.GetComponent<BossMove>().enabled = false;
        } else {
            col.gameObject.GetComponent<BossMove>().IncreaseSpeed(2);
            StartCoroutine(flashBoss(col, 2f, 0.2f));
        }
    }
    IEnumerator flashBoss(Collision2D col, float flashTime, float flashSpeed)
 {
     float flashingFor = 0;
     while(flashingFor < flashTime)
     {
          flashingFor += Time.deltaTime;
          yield return new WaitForSeconds(flashSpeed);
          flashingFor += flashSpeed;
          if(col.gameObject.GetComponent<SpriteRenderer>().enabled == false)
          {
                col.gameObject.GetComponent<SpriteRenderer>().enabled = true;
          }
          else
          {
                col.gameObject.GetComponent<SpriteRenderer>().enabled = false;
          }
     }
 }
}
