using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveControl : MonoBehaviour
{
    private Rigidbody rb;
    public bool isGrounded = true;
    private Vector3 direction;
    public float speed = 5, jumpForce = 5;
    public float currentSpeed;
    [HideInInspector] public bool isActing = false;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 6)
        {
            isGrounded = true;
        }
    }
    private void Awake()
    {
        Cursor.visible = false;
        currentSpeed = speed;
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal") * -1;
        float moveVertical = Input.GetAxis("Vertical") * -1;
        direction = new Vector3(moveVertical, 0.0f, moveHorizontal);
        direction = transform.TransformDirection(direction);
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded || Input.GetKey(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
            isGrounded = false;
        }
    }
    private void FixedUpdate()
    {
        if (!isActing)
        {
            Cursor.visible = false;
            rb.MovePosition(transform.position + direction * Time.deltaTime * currentSpeed);
        }
    }
}
