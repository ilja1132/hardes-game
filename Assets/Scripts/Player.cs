using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Vector3 moveDirection = new Vector3();
        moveDirection.x = Input.GetAxisRaw("Horizontal");
        moveDirection.z = Input.GetAxisRaw("Vertical");
        
        moveDirection.Normalize();

        rb.velocity = moveDirection * speed;
        if(moveDirection != Vector3.zero)transform.forward = moveDirection; // rotates player along AWSD
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name.Contains("Enemy"))
        {
            transform.position = Vector3.zero; // new Vectors(0,0,0)
        }
    }
}
