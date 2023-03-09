using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastScript : MonoBehaviour
{
    // Start is called before the first frame update
    Camera cam;
    public LayerMask sphere;
    public LayerMask cube;
    public LayerMask cylinder;

    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 100f;
        mousePos = cam.ScreenToWorldPoint(mousePos);
        Debug.DrawRay(transform.position, mousePos - transform.position, Color.yellow);

        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("onHIT");
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100, cube))
            {
                Debug.Log(hit.transform.name);
                hit.transform.GetComponent<Renderer>().material.color = Color.red;
            } else if (Physics.Raycast(ray, out hit, 100, sphere))
            {
                Debug.Log(hit.transform.name);
                hit.transform.GetComponent<Renderer>().material.color = Color.blue;
            } else if (Physics.Raycast(ray, out hit, 100, cylinder))
            {
                Debug.Log(hit.transform.name);
                hit.transform.GetComponent<Renderer>().material.color = Color.grey;
            }

        }
    }
}
