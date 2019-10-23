using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField]
    private string _cHorizontal;
    public bool walkRight = Input.GetKeyDown(KeyCode.D);
    [SerializeField]
    float moveSpeed;

    private Animator anim;
  
    private float translation;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        translation = Input.GetAxis(_cHorizontal) * Time.deltaTime * moveSpeed;
        transform.position += new Vector3(translation, 0, 0);

        Vector3 clampedPosition = transform.position;
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, 0f, 1.5f);
        transform.position = clampedPosition;

        if (Input.anyKeyDown.Equals(walkRight))
        {
            anim.Play("Player_Walk_Forward");
        }
    }
}
