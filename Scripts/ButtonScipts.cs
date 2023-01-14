using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScipts : MonoBehaviour
{
    [Tooltip("Place object named 'ConstantPanel' here. \nBaseForRotation > Main Camera > Canvas > ConstantPanel")]
    public GameObject ConstantTextPanel;
    [Tooltip("Place object named 'UserControlPanel' here. \nBaseForRotation > Main Camera > Canvas > UserControlPanel")]
    public GameObject UserControlPanel;
    [Tooltip("Place object named 'DisableTextButton' here. \nBaseForRotation > Main Camera > Canvas > DisableTextButton")]
    public Button DisableTextButton;
    [Tooltip("Place object named 'AutoButton' here. \nBaseForRotation > Main Camera > Canvas > ConstantPanel > AutoButton")]
    public Button AutoModeButton;
    [Tooltip("Value between 0 and 1.\nDetermines how transparent the DisableTextButton is when text is disabled.")]
    public float disabledAlphaValue = .5f;

    private bool isTextEnabled = true;

    private void OnEnable()
    {
        UserInput.AutoRotateClicked += AutoModeButtonCall;
    }
    private void OnDisable()
    {
        UserInput.AutoRotateClicked -= AutoModeButtonCall;
    }

    public void DisableTextButtonCall()
    {
        Color textButtonColor = DisableTextButton.image.color;
        Text buttonText = DisableTextButton.GetComponentInChildren<Text>();
        if(isTextEnabled)
        {
            isTextEnabled = false;
            ConstantTextPanel.SetActive(false);
            if(!UserInput.isOnAuto)
            {
                UserControlPanel.SetActive(false);
            }
            textButtonColor.a = disabledAlphaValue;
            DisableTextButton.image.color = textButtonColor;
            buttonText.text = "Enable Text".ToString();
        }
        else
        {
            isTextEnabled = true;
            ConstantTextPanel.SetActive(true);
            if (!UserInput.isOnAuto)
            {
                UserControlPanel.SetActive(true);
            }
            textButtonColor.a = 1;
            DisableTextButton.image.color = textButtonColor;
            buttonText.text = "Disable Text".ToString();
        }
    }

    private void AutoModeButtonCall()
    {
        Text buttonText = AutoModeButton.GetComponentInChildren<Text>();
        if(!UserInput.isOnAuto)
        {
            UserControlPanel.SetActive(true);
            buttonText.text = "Auto Mode: OFF".ToString();
        }
        else
        {
            UserControlPanel.SetActive(false);
            buttonText.text = "Auto Mode: ON".ToString();
        }
    }
}
