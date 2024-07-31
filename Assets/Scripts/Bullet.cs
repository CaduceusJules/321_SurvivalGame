using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // speed of the bullet
    [SerializeField] private float speed = 50.0f;
    // how long the bullet remains in the scene until it is destroyed (in seconds)
    [SerializeField] private float lifeTime = 1.0f;

    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // destroy the bullet after the specified lifeTime
        Destroy(gameObject, lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        // sets the velocity in the direction of the front of the bullet
        rb.velocity = transform.up * speed;
    }
}
