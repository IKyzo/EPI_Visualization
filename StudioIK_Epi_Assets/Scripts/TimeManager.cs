using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


public class TimeManager : MonoBehaviour
{
    public UIDocument uiroot;
    public VisualElement root;
    private Button buttonTimeCycle;


    public GameObject directionLight;
    private Vector3 dayTime = new Vector3(35f, 130f, 0f);
    private Vector3 nightTime = new Vector3(200f, 130f, 0f);
    private bool timeControl=false;
    private float interpolation=0f;

    private void Awake() {
        root = uiroot.GetComponent<UIDocument>().rootVisualElement;
        buttonTimeCycle =root.Q<Button>("TimeCycle");
    }
    // Update is called once per frame
   private void OnEnable()
   {
    buttonTimeCycle.clicked += () => changeTime();
   }

   private void changeTime()
   {
        timeControl=true;
   }

   private void Update() {
        if(timeControl)
        {
            directionLight.transform.eulerAngles = new Vector3(Mathf.Lerp(dayTime.x, nightTime.x, interpolation), 130f, 0f);
            interpolation += 0.2f * Time.deltaTime;
            if(interpolation>1f)
            {
                timeControl=false;
                interpolation=0f;
            }
            
        }
   }
}
