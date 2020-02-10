using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swat : MonoBehaviour
{
    private Animator animator;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.CompareTag ("Wall"))
        {
            animator.SetTrigger("swatHit");
        }

    }
}
