using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    // Bit shift the index of the layer (8) to get a bit mask
    public LayerMask layerMask;
    public GameObject cube;

    public List<GameObject> cubeList;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 1000, layerMask))
            {
                if (hit.collider != null)
                {
                //    Debug.Log(hit.point);
                   cubeList.Add(cube.Spawn(hit.point + new Vector3(0.0f, 0.5f, 0.0f)));
                }
            }
        }
    }
}
