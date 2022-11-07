using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayCameraBehavior : MonoBehaviour
{

    // [TODO] ADD LIST MANAGER SCRIPT, CLEAN THIS CODE , BRUH

    public Transform targetTransform;
    private float rotationSpeed = 0.25f;
    private float offset = 150f;
    private Vector3 point;
    private Vector3 initCameraPosition;


    public List<Transform> displayItems = new List<Transform>();
    [SerializeField]private Transform currentDisplayTarget;
    [SerializeField]private Transform nextDisplayTarget;
    [SerializeField]private Transform previousDisplayTarget;
    [SerializeField]private int indexDisplay=0;


    // Lerp Stuff



    // Start is called before the first frame update
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


        Debug.Log("List count is : "+ displayItems.Count);
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(point, new Vector3(0f, 5f, 0f), 20 * Time.deltaTime * rotationSpeed);
        //transform.LookAt(targetTransform);
        //transform.Translate(Vector3.right * Time.deltaTime * rotationSpeed);
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {

            if (UpdateDisplay(1) == 1)
            {
                point = nextDisplayTarget.position;
                initCameraPosition = nextDisplayTarget.position + new Vector3(0f, offset, offset - 10f);
                transform.position = initCameraPosition;
                transform.LookAt(point);
                // update the Display Targets
                if(indexDisplay != displayItems.Count)
                {
                    currentDisplayTarget = displayItems[indexDisplay];
                    if (indexDisplay!=displayItems.Count-1)
                    {
                        nextDisplayTarget = displayItems[indexDisplay + 1];
                    }
                    previousDisplayTarget = displayItems[indexDisplay - 1];
                }
             
            
            }

        }
		if (Input.GetKeyDown(KeyCode.LeftArrow))
		{
            if (UpdateDisplay(-1) == 1)
            {
                point = previousDisplayTarget.position;
                initCameraPosition = previousDisplayTarget.position + new Vector3(0f, offset, offset - 10f);
                transform.position = initCameraPosition;
                transform.LookAt(point);
                // update the Display Targets
                currentDisplayTarget = displayItems[indexDisplay];
                if (indexDisplay != 0)
                {
                    previousDisplayTarget = displayItems[indexDisplay - 1];
                }
                nextDisplayTarget = displayItems[indexDisplay + 1];
                
                
                
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
