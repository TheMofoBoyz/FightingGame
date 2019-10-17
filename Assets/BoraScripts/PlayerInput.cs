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
        translation = Input.GetAxis(_cHorizontal) * Time.deltaTime * moveSpeed;
        transform.position += new Vector3(translation, 0, 0);

        Vector3 clampedPosition = transform.position;
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, 0f, 1.5f);
        transform.position = clampedPosition;
    }
}
