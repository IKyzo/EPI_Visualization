using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayCameraBehavior : MonoBehaviour
{

    // [TODO] ADD LIST MANAGER SCRIPT, CLEAN THIS CODE , BRUH

    public Transform targetTransform;
    private float rotationSpeed = 0.25f;
    private float offset = 150f;
    [SerializeField]private Vector3 point;
    [SerializeField]private Vector3 initCameraPosition;


    public List<Transform> displayItems = new List<Transform>();
    [SerializeField]private Transform currentDisplayTarget;
    [SerializeField]private Transform nextDisplayTarget;
    [SerializeField]private Transform previousDisplayTarget;
    [SerializeField]private int indexDisplay=0;
    private bool displayMode = true;
    private bool animateCamera = false;


    // Lerp Stuff
    float timeElapsed = 0;
    float lerpDuration = 3;
    float startValue=0;
    float endValue=10;
    float valueToLerp;
    Vector3 cameraStartingPosition;
    Vector3 cameraOffsetPosition;
    int cameraDirection;

    private void Awake() {
        // initilize offset 
        //offset = transform.   
        currentDisplayTarget = displayItems[indexDisplay];
        nextDisplayTarget = displayItems[indexDisplay+1]; 

    }
    void Start()
    {
        point = currentDisplayTarget.position;
        initCameraPosition = currentDisplayTarget.position  + new Vector3(0f, offset, offset - 10f);   
        transform.position = initCameraPosition;
        transform.LookAt(point);
        cameraStartingPosition = transform.position;
        //Debug.Log("List count is : "+ displayItems.Count);
    }

    // Update is called once per frame
    void Update()
    {

        //if (timeElapsed < lerpDuration)
        //{
        //    valueToLerp = Mathf.Lerp(startValue, endValue, timeElapsed / lerpDuration);
        //    timeElapsed += Time.deltaTime;
        //    Debug.Log("Value to lerp = " + valueToLerp);
        //}
        if (displayMode)
        {
            transform.RotateAround(point, new Vector3(0f, 5f, 0f), 20 * Time.deltaTime * rotationSpeed);
        }
        //transform.LookAt(targetTransform);
        //transform.Translate(Vector3.right * Time.deltaTime * rotationSpeed);
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {

            if (UpdateDisplay(1) == 1)
            {
                // update the Display Targets
                if (indexDisplay != displayItems.Count)
                {
                    currentDisplayTarget = displayItems[indexDisplay];
                    if (indexDisplay != displayItems.Count - 1)
                    {
                        nextDisplayTarget = displayItems[indexDisplay + 1];
                    }
                    previousDisplayTarget = displayItems[indexDisplay - 1];
                }
                point = currentDisplayTarget.position;
                cameraOffsetPosition = transform.position;
                // Translation Part 
                displayMode = false;
                animateCamera = true;
                cameraDirection = 1;

             
            
            }

        }
		if (Input.GetKeyDown(KeyCode.LeftArrow))
		{
            if (UpdateDisplay(-1) == 1)
            {
                // update the Display Targets
                currentDisplayTarget = displayItems[indexDisplay];
                if (indexDisplay != 0)
                {
                    previousDisplayTarget = displayItems[indexDisplay - 1];
                }
                nextDisplayTarget = displayItems[indexDisplay + 1];
                point = currentDisplayTarget.position;
                cameraOffsetPosition = transform.position;

                // Translation Part 
                displayMode = false;
                animateCamera = true;
                cameraDirection = -1;


                //initCameraPosition = previousDisplayTarget.position + new Vector3(0f, offset, offset - 10f);
                //transform.position = initCameraPosition;
                //transform.LookAt(point);
                
                
                
                
                //if (indexDisplay != 0)
                //{
                //    currentDisplayTarget = displayItems[indexDisplay];
                //    if (indexDisplay != displayItems.Count + 1)
                //    {
                //        previousDisplayTarget = displayItems[indexDisplay - 1];
                //    }
                //    nextDisplayTarget = displayItems[indexDisplay+1];
                //}
            }
		}
        if (animateCamera)
        {
            cameraStartingPosition = transform.position;
            CameraTransition( cameraDirection );
        }

    }
    void CameraTransition(int direction)
    {
        Vector3 cameraEndingPosition;
        if (direction == 1)
        {
            cameraEndingPosition = currentDisplayTarget.position;
        }
        else if (direction == -1)
        {
            cameraEndingPosition = currentDisplayTarget.position;
        }
        else { Debug.Log("Error : direction input  - CameraTransition"); cameraEndingPosition = new Vector3(0, 0, 0); }
        if (timeElapsed < lerpDuration - 2)
        {
            timeElapsed +=  Time.deltaTime;
            //transform.position = Vector3.Lerp(cameraStartingPosition, new Vector3(cameraEndingPosition.x, cameraEndingPosition.y + offset, cameraEndingPosition.z + offset - 10f), timeElapsed / lerpDuration);
            transform.position = Vector3.Lerp(cameraStartingPosition, new Vector3(cameraOffsetPosition.x + (150f * direction), cameraOffsetPosition.y, cameraOffsetPosition.z), timeElapsed / lerpDuration);
            Debug.Log("Time Elapsed : " + timeElapsed);
        }
        else
        {
            displayMode = true;
            animateCamera = false;
            if (direction == 1)
            { point = currentDisplayTarget.position;
                initCameraPosition = currentDisplayTarget.position + new Vector3(0f, offset, offset - 10f);
                //transform.position = initCameraPosition;
                transform.LookAt(point);
            }
            else
            { 
                point = currentDisplayTarget.position;
                transform.LookAt(point);
            }
            timeElapsed = 0;
        }
    }
    int UpdateDisplay(int listAdvancement) // 1 = Change || 0 = No Change
    {

		if (listAdvancement==1)
		{
            if (indexDisplay == displayItems.Count - 1)
            {
                return 0;
            }
            else
            {
                indexDisplay++;
                return 1;
            }

		}
		else if (listAdvancement==-1)
		{
            if (indexDisplay == 0)
            {
                return 0;
            }
            else
            {
                indexDisplay--;
                return 1;
            }
		}
        else
		{
            Debug.Log("Update Display Input not valid");
            return 0;
		}




        // Managing limits in the list :
        // 3 items = limit is 3
        //if (indexDisplay!= 0 && listAdvancement==-1)
        //{
        //    currentDisplayTarget = displayItems[indexDisplay + listAdvancement];
        //    return 1;
        //}
        //if (indexDisplay!=0 && indexDisplay != displayItems.Count)
        //{
        //    nextDisplayTarget = displayItems[indexDisplay + listAdvancement];
        //    return 1;
        //}
        //if (indexDisplay != 0)
        //{
        //    previousDisplayTarget = displayItems[indexDisplay - listAdvancement];
        //    return 1;
        //}
        //Debug.Log("Returning 0");
        //return 0;
        
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
