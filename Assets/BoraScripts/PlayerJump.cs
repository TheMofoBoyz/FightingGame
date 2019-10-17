using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [SerializeField]
    private string _jumpButton;
    [SerializeField]
    float jumpForce;

    private bool isGrounded;
    private float translation;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == ("Ground"))
        {
            isGrounded = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        translation = Input.GetAxis(_jumpButton) * jumpForce;

        translation *= Time.deltaTime;
        transform.position += new Vector3(0, translation, 0);
    }
}
