using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubePlayer : MonoBehaviour
{
    public GameObject cube1;
    public GameObject cube2;

    private Vector3 target;

    // Transforms to act as start and end markers for the journey.
    public Transform startMarker;
    public Transform endMarker;

    // Movement speed in units per second.
    public float speed = 0.1F;

    // Time when the movement started.
    private float startTime;

    // Total distance between the markers.
    private float journeyLength;

    // Start is called before the first frame update
    void Start()
    {
        // target = cube2.transform.position;
        // // Quaternion a = new Quaternion(target.position);
        // transform.position = cube1.transform.position;

        // Keep a note of the time the movement started.

        startMarker = cube1.transform;
        endMarker = cube2.transform;

        startTime = Time.time;

        // Calculate the journey length.
        journeyLength = Vector3.Distance(startMarker.position, endMarker.position);
    }

    // Update is called once per frame
    void Update()
    {
        // if (Input.GetKey(KeyCode.LeftArrow)) {
           
        //     transform.position = Vector3.MoveTowards(transform.position, target, 5 * Time.deltaTime);
        // }

         // Distance moved equals elapsed time times speed..
        float distCovered = (Time.time - startTime) * speed;

        // Fraction of journey completed equals current distance divided by total distance.
        float fractionOfJourney = distCovered / journeyLength;

        // Set our position as a fraction of the distance between the markers.
        transform.position = Vector3.Lerp(startMarker.position, endMarker.position, fractionOfJourney);
        transform.rotation = Quaternion.Lerp(startMarker.rotation, endMarker.rotation, fractionOfJourney);
    }
}
