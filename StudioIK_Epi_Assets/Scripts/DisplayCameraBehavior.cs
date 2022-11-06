using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayCameraBehavior : MonoBehaviour
{

    // [TODO] ADD LIST MANAGER SCRIPT

    public Transform targetTransform;
    private float rotationSpeed = 0.25f;
    private float offset = 150f;
    private Vector3 point;
    private Vector3 initCameraPosition;


    public List<Transform> displayItems = new List<Transform>();
    private Transform currentDisplayTarget;
    private Transform nextDisplayTarget;
    private Transform previousDisplayTarget;
    private int index=0;
    // Start is called before the first frame update
    private void Awake() {
        // initilize offset 
        //offset = transform.   
        currentDisplayTarget = displayItems[index];
        nextDisplayTarget = displayItems[index+1]; 
    }
    void Start()
    {
        point = targetTransform.position;
        initCameraPosition = targetTransform.position  + new Vector3(offset, offset, 0f);   
        transform.position = initCameraPosition;
        transform.LookAt(point);
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(point, new Vector3(0f, 5f, 0f), 20 * Time.deltaTime * rotationSpeed);
        //transform.LookAt(targetTransform);
        //transform.Translate(Vector3.right * Time.deltaTime * rotationSpeed);
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            point = nextDisplayTarget.position;
            initCameraPosition = nextDisplayTarget.position + new Vector3(offset, offset, 0f); 
            transform.position = initCameraPosition;
            transform.LookAt(point);
        }
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {

        }
    }
    
}

/*
   public TargetClass target;//the target object
    private float speedMod = 10.0f;//a speed modifier
    private Vector3 point;//the coord to the point where the camera looks at
   
    void Start () {//Set up things on the start method
        point = target.transform.position;//get target's coords
        transform.LookAt(point);//makes the camera look to it
    }
   
    void Update () {//makes the camera rotate around "point" coords, rotating around its Y axis, 20 degrees per second times the speed modifier
        transform.RotateAround (point,new Vector3(0.0f,1.0f,0.0f),20 * Time.deltaTime * speedMod);
    }

*/
