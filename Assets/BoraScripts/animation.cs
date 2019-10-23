using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animation : MonoBehaviour
{
    [SerializeField]
    private string _cHorizontal;

    public Animator animator;
    public float InputX;
    public float InputY;

    // Start is called before the first frame update
    void Start()
    {
        animator = this.gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        InputX = Input.GetAxis(_cHorizontal);
        animator.SetFloat("InputX", InputX);
    }
}
