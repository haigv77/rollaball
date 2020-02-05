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

    void Start ()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText ();
        winText.text = "";
        isStartGame = false;
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
                    //Debug.Log(inputManager.cubeList.IndexOf(objet));
                    other.gameObject.SetActive(false);
                    inputManager.cubeList.RemoveAt(inputManager.cubeList.IndexOf(objet));

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
            winText.text = "You Win!";
            isStartGame = false;
        }
    }
}
