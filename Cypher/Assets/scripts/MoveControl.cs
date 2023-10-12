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
    [SerializeField] private TaskWindow gamemanager;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "habitationRoom" && gamemanager.ActiveTask != null)
        {
            gamemanager.ActiveTask.TaskConditions[1] = "true";
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer.ToString() == "6")
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
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        direction = new Vector3(moveHorizontal, 0.0f, moveVertical);
        direction = transform.TransformDirection(direction);
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
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
