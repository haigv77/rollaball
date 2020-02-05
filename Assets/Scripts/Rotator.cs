using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    private Vector3 v3;

    void Start() 
    {
        v3 = new Vector3(Random.Range(0, 90), Random.Range(0, 90), Random.Range(0, 90));
    }
    // Update is called once per frame
    void Update()
    {
        transform.Rotate (v3 * Time.deltaTime);   
    }
}
