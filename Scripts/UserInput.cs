using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInput : MonoBehaviour
{
    public static bool isOnAuto = false;
    public delegate void ClickAction();
    public static event ClickAction AutoRotateClicked;

    [Tooltip("Place object named 'UserCameraBase' here. \nBaseForRotation > UserCameraBase")]
    public Transform cameraUserBaseLoc;
    [Tooltip("Place object named 'AutoCameraBase' here. \nBaseForRotation > AutoCameraBase")]
    public Transform cameraAutoBaseLoc;
    [Tooltip("Place object named 'Main Camera' here. \nBaseForRotation > Main Camera")]
    public new Transform camera;
    [Tooltip("Helps determine how fast an object rotates.\nThe higher the number, the faster it rotates")]
    public float speed = 250f;
    [Tooltip("Helps determine how much you can zoom in and out with the scrollwheel")]
    public float maxClamp = 2.5f;
    [Tooltip("How quickly the camera ascends and descends.\nThe higher the number, the faster you go up and down.")]
    public float climbSpeed = 4;
    [Tooltip("How quickly the camera zooms in with the scrollwheel")]
    public float scrollSpeed = 2.5f;
    [Tooltip("Helps determine how fast an object auto rotates.\nThe lower the number, the slower it rotates")]
    public float autoRotateFractionAmount = 5f;

    private ModelOrganizer organizer;
    private Transform children;
    private float zoomAmount = 0f;
    private bool hasStarted = false;

    private void Start()
    {
        if (this.transform.childCount >= 2)
        {
            children = this.transform.GetChild(0);
            organizer = children.GetComponent<ModelOrganizer>();
        }
    }

    void Update ()
    {
        if (!isOnAuto)
        {
            MouseInput();
            CheckKeyInput();
        }
        else
        {
            AutoRotate();
        }
	}

    public void ChangeAuto()
    {
        if(isOnAuto)
        {
            isOnAuto = false;
            hasStarted = false;
            camera.transform.position = cameraUserBaseLoc.transform.position;
            camera.transform.rotation = cameraUserBaseLoc.transform.rotation;
            children.rotation = new Quaternion(0f, 0f, 0f, 0f);
        }
        else
        {
            isOnAuto = true;
            hasStarted = false;
            camera.transform.position = cameraAutoBaseLoc.transform.position;
            camera.transform.rotation = cameraAutoBaseLoc.transform.rotation;
            children.rotation = new Quaternion(0f, 0f, 0f, 0f);
        }
        AutoRotateClicked();
    }

    private void MouseInput()
    {
        if (Input.GetKey(KeyCode.Mouse0))
            {
            children.Rotate(new Vector3(0, -1 * Input.GetAxis("Mouse X"), 0) * Time.deltaTime * speed, Space.World);
            if (ModelOrganizer.models[ModelOrganizer.listPtr].GetComponent<ModelInfo>().shouldSeeUnderside)
            {
                while (children.transform.rotation.z >= 0f && children.transform.rotation.z <= 30f )
                {
                    children.Rotate(new Vector3(Input.GetAxis("Mouse Y"), 0, 0) * Time.deltaTime * speed, Space.World);
                }
                
            }
            zoomAmount += Input.GetAxis("Mouse ScrollWheel");
            zoomAmount = Mathf.Clamp(zoomAmount, -maxClamp, maxClamp);
            float translate = Mathf.Min(Mathf.Abs(Input.GetAxis("Mouse ScrollWheel")),
                maxClamp - Mathf.Abs(zoomAmount));
            camera.transform.Translate(0, 0, translate * scrollSpeed * Mathf.Sign(
                Input.GetAxis("Mouse ScrollWheel")));
        }
        
    }

    private void CheckKeyInput()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            organizer.BackOneModel();
            children.rotation = new Quaternion(0f, 0f, 0f, 0f);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            organizer.ForwardOneModel();
            children.rotation = new Quaternion(0f, 0f, 0f, 0f);
        }

        if(Input.GetKeyDown(KeyCode.W))
        {
            camera.transform.position = cameraUserBaseLoc.transform.position;
            zoomAmount = 0;
        }

        if(Input.GetKeyDown(KeyCode.S))
        {
            children.rotation = new Quaternion(0f, 0f, 0f, 0f);
        }

        if(Input.GetKey(KeyCode.Q))
        {
            camera.transform.position += camera.transform.up * climbSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.E))
        {
            if (!ModelOrganizer.models[ModelOrganizer.listPtr].GetComponent<ModelInfo>().shouldSeeUnderside
                && camera.transform.position.y > 0)
            {
                camera.transform.position -= camera.transform.up * climbSpeed * Time.deltaTime;
                if(camera.transform.position.y < 0)
                {
                    camera.transform.position = cameraUserBaseLoc.transform.position;
                }
            }
            else if(ModelOrganizer.models[ModelOrganizer.listPtr].GetComponent<ModelInfo>().shouldSeeUnderside)
            {
                camera.transform.position -= camera.transform.up * climbSpeed * Time.deltaTime;
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    private void AutoRotate()
    {
        if(!hasStarted && children.eulerAngles.y > 1)
        {
            hasStarted = true;
        }
        children.Rotate(Vector3.up * (speed/autoRotateFractionAmount) * Time.deltaTime);
        if(children.eulerAngles.y >= 0 && children.eulerAngles.y < 1 && hasStarted)
        {
            organizer.ForwardOneModel();
            children.rotation = new Quaternion(0f, 0f, 0f, 0f);
            hasStarted = false;
        }
    }
}
