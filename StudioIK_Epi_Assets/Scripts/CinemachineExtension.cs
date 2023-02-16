using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CinemachineExtension : MonoBehaviour
{
    public CinemachineFreeLook cinemachineController;
    private bool activate=false;
    // Start is called before the first frame update
    void Start()
    {
        //cinemachineController.m_YAxis.m_SpeedMode=0f;
        cinemachineController.m_YAxis.m_MaxSpeed=0f; // 1
        cinemachineController.m_XAxis.m_MaxSpeed=0f; // 300 ?
        
        //cinemachineController.m_XAxis.m_SpeedMode=0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Mouse0))
        {
            activate=true;
            UpdateCinemachine();
        }
        else
        {
            cinemachineController.m_YAxis.m_MaxSpeed=0f; // 1
            cinemachineController.m_XAxis.m_MaxSpeed=0f; // 300 ?    
        }
        
    }

    private void UpdateCinemachine()
    {
        cinemachineController.m_YAxis.m_MaxSpeed=1f; // 1
        cinemachineController.m_XAxis.m_MaxSpeed=300f; // 300 ?
    }
}
