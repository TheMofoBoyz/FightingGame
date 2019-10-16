using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField]
    private string _cHorizontal;
    [SerializeField]
    float moveSpeed;

    private float translation;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        translation = Input.GetAxis(_cHorizontal) * moveSpeed;

        translation *= Time.deltaTime;
        transform.position += new Vector3(translation, 0, 0);
    }
}
