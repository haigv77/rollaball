using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // public GameObject player;
    public Camera camera1;
    public Camera camera2;

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
        // offset = transform.position - player.transform.position;
        camera1.enabled = true;
        camera2.enabled = false;

        startMarker = camera1.transform;
        endMarker = camera2.transform;

        startTime = Time.time;

        // Calculate the journey length.
        journeyLength = Vector3.Distance(startMarker.position, endMarker.position);
    }

    // Update is called once per frame
    void Update()
    {
        // Distance moved equals elapsed time times speed..
        float distCovered = (Time.time - startTime) * speed;

        // Fraction of journey completed equals current distance divided by total distance.
        float fractionOfJourney = distCovered / journeyLength;

        // Set our position as a fraction of the distance between the markers.
        camera1.transform.position = Vector3.Lerp(startMarker.position, endMarker.position, fractionOfJourney);
        camera1.transform.rotation = Quaternion.Euler(Vector3.Lerp(startMarker.rotation.eulerAngles, endMarker.rotation.eulerAngles, fractionOfJourney));
    }
}
