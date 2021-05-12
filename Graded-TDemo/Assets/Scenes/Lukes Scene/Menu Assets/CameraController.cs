using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraController : MonoBehaviour
{

    public Vector3[] Target;
    public int zoom = 50;
    public int normal = 60;
    public float smooth = 20;

    bool isZoomedOnSettings;
    bool isZoomedOnHeadLine;
    bool isZoomedOnInterviews;
    bool isZoomedOnInterviewsList;

    GameObject canvas;

    void Start()
    {
        canvas = GameObject.Find("Canvas");
    }

    void Update()
    {
        if (isZoomedOnSettings)
        {
            Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, 2.5f, 0.0125f);
            canvas.transform.position = Vector3.Lerp(canvas.transform.position, Target[1], 0.0125f);
        }

        if (isZoomedOnHeadLine)
        {
            Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, 2.5f, 0.0125f);
            canvas.transform.position = Vector3.Lerp(canvas.transform.position, Target[2], 0.0125f);
        }

        if (isZoomedOnInterviews)
        {
            Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, 2.5f, 0.0125f);
            canvas.transform.position = Vector3.Lerp(canvas.transform.position, Target[3], 0.0125f);
        }

        if (isZoomedOnInterviewsList)
        {
            Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, 2.5f, 0.0125f);
            canvas.transform.position = Vector3.Lerp(canvas.transform.position, Target[4], 0.0125f);
        }


        if (!isZoomedOnSettings && !isZoomedOnHeadLine && !isZoomedOnInterviews && !isZoomedOnInterviewsList)
        {
            Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, 5, 0.0125f);
            canvas.transform.position = Vector3.Lerp(canvas.transform.position, Target[0], 0.0125f);
        }

        if (Input.GetMouseButtonDown(1))
        {
            isZoomedOnSettings = false;
            isZoomedOnHeadLine = false;
            isZoomedOnInterviews = false;
            isZoomedOnInterviewsList = false;
        }
    }
    public void SelectSettings()
    {
        isZoomedOnSettings = true;
    }

    public void SelectHeadLine()
    {
        isZoomedOnHeadLine = true;
    }

    public void SelectInterviews()
    {
        //isZoomedOnInterviews = true;

        if(isZoomedOnInterviews)
        {
            isZoomedOnInterviewsList = true;
            isZoomedOnInterviews = false;
        }
        else
        {
            isZoomedOnInterviews = true;
        }
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
