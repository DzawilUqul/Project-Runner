using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float leftRightSpeed;
    public Rigidbody rb;
    private bool isGrounded;
    public GameManager gameManager;
    [SerializeField] private float leftSide;
    [SerializeField] private float rightSide;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Gerakkan Dino ke depan secara otomatis
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            if (this.gameObject.transform.position.x > leftSide)
            {
                transform.position += new Vector3(-leftRightSpeed * Time.deltaTime, 0, 0);
            }
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            if (this.gameObject.transform.position.x < rightSide)
            {
                transform.position += new Vector3(leftRightSpeed * Time.deltaTime, 0, 0);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }

        if (collision.gameObject.tag == "Obstacle")
        {
            // Memanggil fungsi GameOver dari GameManager
            gameManager.GameOver();
        }
    }
}
