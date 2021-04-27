using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Vector3[] Target;
    public int zoom = 50;
    public int normal = 60;
    public float smooth = 20;
    bool isZoomed;

    GameObject canvas;

    void Start()
    {
        canvas = GameObject.Find("Canvas");
    }

    void Update()
    {
        if (isZoomed)
        {
            Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, 2.5f, 0.0125f);
            canvas.transform.position = Vector3.Lerp(canvas.transform.position, Target[1], 0.0125f);
        }

        if (!isZoomed)
        {
            Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, 5, 0.0125f);
            canvas.transform.position = Vector3.Lerp(canvas.transform.position, Target[0], 0.0125f);
        }

        if (Input.GetMouseButtonDown(1))
        {
            isZoomed = false;
        }
    }
    public void Select()
    {
        isZoomed = true;
    }

    /*void Update()
    {
        if (Input.GetMouseButtonDown(1) && !isZoomed)
        {
            GetComponent<Camera>().fieldOfView = Mathf.Lerp(GetComponent<Camera>().fieldOfView, normal, Time.deltaTime * smooth);
        }
       //Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, -zoom, Time.deltaTime * smooth);
    }*/
}
