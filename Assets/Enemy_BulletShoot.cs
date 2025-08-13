using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_BulletShoot : MonoBehaviour
{
    public float bulletSpeed; 
    public float bulletDmg;
    Rigidbody2D rb;
    private Transform target;
    private Vector2 moveDir;

    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        moveDir = new Vector2(target.position.x, target.position.y);
        //transform.rotation = moveDir;
        //transform.rotation = Quaternion.LookRotation(moveDir);
        Destroy (gameObject, 3f); 
    }

    // Update is called once per frame
    void Update()
    {
        // move the bullet towards the players last position
        transform.position = Vector2.MoveTowards(transform.position, moveDir, bulletSpeed * Time.deltaTime);
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        
    }
}
