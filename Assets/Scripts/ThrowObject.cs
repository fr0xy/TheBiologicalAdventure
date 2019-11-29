using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ThrowObject : MonoBehaviour
{
    [SerializeField]
    private float speed;
    private Rigidbody2D myRigibody;
    private Vector2 direction;
    public float lifeTime = 2f;
    // Start is called before the first frame update
    void Start()
    {
        myRigibody = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate() {
        myRigibody.velocity = direction * speed;
        lifeTime -= Time.deltaTime;
        if (lifeTime < 0) {
            Destroy(this.gameObject);
        }
    }
    public void Initialize(Vector2 direction)
    {
        this.direction = direction;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
