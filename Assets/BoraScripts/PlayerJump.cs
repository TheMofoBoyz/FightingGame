using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [SerializeField]
    private string _jumpButton;
    [SerializeField]
    float jumpForce;

    private bool onGround;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        onGround = true;
    }

    // Update is called once per frame
    void Update()
    {
       // if (Input.GetAxis(_jumpButton) && onGround == true)
        {
            rb.velocity = new Vector3(0f, jumpForce, 0f);
            onGround = false;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            onGround = true;
        }
    }
}
