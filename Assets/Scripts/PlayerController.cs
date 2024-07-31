using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Player variables
    
    // character movement speed
    [SerializeField] private float speed = 5.0f;

    // Weapon variables
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform bulletOrigin;

    private Rigidbody2D rb;
    // movement values for horizontal and vertical
    private float moveX;
    private float moveY;

    // position of mouse cursor
    private Vector2 mousePos;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // set movement values to keyboard input
        moveX = Input.GetAxisRaw("Horizontal");     // w/s OR up/down
        moveY = Input.GetAxisRaw("Vertical");       // a/d OR left/right
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        float angle = Mathf.Atan2(mousePos.y - transform.position.y, mousePos.x - transform.position.x) * Mathf.Rad2Deg;

        transform.localRotation = Quaternion.Euler(0, 0, angle);

        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(moveX, moveY).normalized * speed;
    }

    private void Shoot()
    {
        Instantiate(bulletPrefab, bulletOrigin.position, bulletOrigin.rotation);
    }
}
