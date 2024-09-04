using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    public static Player Instance;

    private Rigidbody rb;
    [SerializeField] public float speed = 20f;
    private float horizontalInput;

    // Jump
    [SerializeField] float jumpForce = 100f;
    private bool isGrounded = false;
    private Animator animator;

    bool isAlive = true;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) {
            Jump();
        }

        if (transform.position.y < -5) {
            Die();
        }
    }

    void FixedUpdate()
    {
        if (!isAlive) return;

        Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
        Vector3 horizontalMove = transform.right * horizontalInput * speed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + horizontalMove + forwardMove);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground")) {
            isGrounded = true;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground")) {
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground")) {
            isGrounded = false;
        }
    }

    void Jump()
    {
        animator.SetTrigger("Jump");
        rb.AddForce(Vector3.up * jumpForce);
    }

    public void Die()
    {
        isAlive = false;
        GameOver();
    }

    public void GameOver()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
