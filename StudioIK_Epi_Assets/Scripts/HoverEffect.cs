using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverEffect : MonoBehaviour
{
    
    public Renderer cube;
    public GameObject sign;
    private Color colorActive;
    private Color colorInactive;
    public Transform cameraReference; 
    private Vector3 direction;
    private float rotationSpeed= 2f;
    private Quaternion lookRotation;
    private Vector3 lookRotationVector;

    private void Start() {
      colorActive = cube.material.color;
      colorInactive = cube.material.color;
      colorActive.a=0.3f;
      
    }
    // Start is called before the first frame update
   private void OnMouseOver() {
      //find the vector pointing from our position to the target
         direction = (cameraReference.position - sign.transform.position).normalized;
 
         //create the rotation we need to be in to look at the target
         lookRotation = Quaternion.LookRotation(direction);
         lookRotationVector = lookRotation.eulerAngles;
         lookRotationVector = new Vector3(0f, lookRotationVector.y+90f, 0f);
         lookRotation = Quaternion.Euler(lookRotationVector);
         //Debug.Log("Rotations xyz : "+ lookRotation.x + " / " + lookRotation.y + " / " + lookRotation.z);
         //lookRotation.eulerAngles = new Vector3(0f, lookRotation.y, 0f);
         //Debug.Log("Rotations xyz : "+ lookRotation.x + " / " + lookRotation.y + " / " + lookRotation.z);
  
 
         //rotate us over time according to speed until we are in the required rotation
         sign.transform.rotation = Quaternion.Slerp(sign.transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
        //sign.transform.eulerAngles =  Quaternion.Slerp(sign.transform.rotation, lookRotation, Time.deltaTime * rotationSpeed).eulerAngles;
      
      //sign.transform.LookAt(direction);
      //sign.transform.eulerAngles = new Vector3(0f, 90f, 0f);
      sign.SetActive(true);
      cube.material.color = colorActive;
     //cube.SetColor("_Color", _color);
     
   }
   private void OnMouseExit() {
    sign.SetActive(false);
    cube.material.color = colorInactive;
   }
}


/* 
 using UnityEngine;
 
 public class SlerpToLookAt: MonoBehaviour
 {
     //values that will be set in the Inspector
     public Transform Target;
     public float RotationSpeed;
 
     //values for internal use
     private Quaternion _lookRotation;
     private Vector3 _direction;
     
     // Update is called once per frame
     void Update()
     {
         //find the vector pointing from our position to the target
         _direction = (Target.position - transform.position).normalized;
 
         //create the rotation we need to be in to look at the target
         _lookRotation = Quaternion.LookRotation(_direction);
 
         //rotate us over time according to speed until we are in the required rotation
         transform.rotation = Quaternion.Slerp(transform.rotation, _lookRotation, Time.deltaTime * RotationSpeed);
     }
 }

*/