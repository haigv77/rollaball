using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Renderer>().material.color = new Color(
            Random.Range(0f, 1f), 
            Random.Range(0f, 1f), 
            Random.Range(0f, 1f)
        );

        animator = GetComponent<Animator>();
        animator.Play("Idle");
    }

    // Update is called once per frame
    void Update()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            // animator.SetTrigger("RotateCube");
            animator.Play("Rotate");
        }

        // if (animator.GetCurrentAnimatorStateInfo(0).IsName("DestroyCube") && animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !animator.IsInTransition(0))
        // {
        //     gameObject.SetActive(false);
        //     // gameObject.Kill();
        //     transform.parent.gameObject.SetActive(false);
        //     //transform.parent.gameObject.Kill();
        // }

        if (Input.GetKeyDown(KeyCode.Space)) {
            // animator.Stop("Rotate");
            animator.SetTrigger("ChangeColorCube");
        }
    }

    // void OnTriggerEnter(Collider other) 
    // {
    //     if (other.gameObject.CompareTag ("Player")) {
    //         // animator.SetTrigger("DestroyCube");
    //         transform.parent.gameObject.SetActive(false);
    //         transform.parent.gameObject.Kill();
    //     }
    // }
}
