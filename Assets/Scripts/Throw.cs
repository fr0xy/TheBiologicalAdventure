using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throw : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ObjectPrefab;
    public float ofcetTop = 1;
    public float ofcetRight = 0.5f;
    public float secondBetweenThrow = 2f;
    private float timeLeft;
    public float lifeTime = 2f;
    void Start()
    {
        timeLeft = secondBetweenThrow;
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0) {
            timeLeft = secondBetweenThrow;
            ThrowKnife();
        }
    }
    public void ThrowKnife () {
        if (this.gameObject.GetComponent<SpriteRenderer>().flipX == true) {
            ofcetRight = -ofcetRight;
        }
        Vector3 startPosition = new Vector3(transform.position.x + ofcetRight, transform.position.y + ofcetTop, transform.position.z);
        GameObject tmp = (GameObject) Instantiate(ObjectPrefab, startPosition, Quaternion.Euler(new Vector3(0,0,-90)));
        tmp.GetComponent<ThrowObject>().lifeTime = lifeTime;
        if (this.gameObject.GetComponent<SpriteRenderer>().flipX == false) {
            tmp.GetComponent<ThrowObject>().Initialize(Vector2.right);
        } else {
            tmp.GetComponent<SpriteRenderer>().flipY = true;
            tmp.GetComponent<ThrowObject>().Initialize(Vector2.left);
        }
    }
}
