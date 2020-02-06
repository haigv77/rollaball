using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Text countText;
    public Text winText;

    public InputManager inputManager;

    private Rigidbody rb;
    private int count;
    private bool isStartGame = false;

    private Animator animator;

    void Start ()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText ();
        winText.text = "";
        isStartGame = false;

        animator = GetComponent<Animator>();
    } 

    void Update () {
        int count = inputManager.cubeList.Count;
        // Debug.Log(count);
        if (count > 0) {
            if (!isStartGame) {
                isStartGame = true;
                winText.text = "";
            }
            
            GameObject cube = inputManager.cubeList[0];
            Vector3 target = cube.transform.position;
            //Debug.Log(count + " - " + target);

            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
            //animator.ResetTrigger("GrowUp");
            animator.SetTrigger("Run");
        } else {
            // animator.ResetTrigger("GrowUp");
            animator.ResetTrigger("Run");
            animator.SetTrigger("Idle");
        }

        
    }

    // void FixedUpdate()
    // {
    //     float moveHorizontal = Input.GetAxis("Horizontal");
    //     float moveVertical = Input.GetAxis("Vertical");

    //     Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

    //     rb.AddForce(movement * speed);
    // }

    void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.CompareTag ("Pick Up"))
        {
            //inputManager.cubeList.RemoveAt(0);
            foreach(GameObject objet in inputManager.cubeList) {

                if(GameObject.ReferenceEquals(other.gameObject, objet)) {

                    Color c = other.gameObject.GetComponent<Renderer>().material.GetColor("_Color");
                    GetComponent<Renderer>().material.color = c;
                    // Debug.Log("color: "+c);

                    // animator.ResetTrigger("Run");
                    animator.ResetTrigger("GrowUp");
                    animator.SetTrigger("GrowUp");

                    //Debug.Log(inputManager.cubeList.IndexOf(objet));
                    // other.gameObject.SetActive(false);
                    inputManager.cubeList.RemoveAt(inputManager.cubeList.IndexOf(objet));
                    //objet.Kill();

                    count = count + 1;
                    SetCountText ();

                    break;
                }
            }
        }
    }

    void SetCountText ()
    {
        countText.text = "Count: " + count.ToString ();
        if (isStartGame && inputManager.cubeList.Count == 0)
        {
            winText.text = "Score: " + count.ToString ();
            isStartGame = false;
        }
    }
}
