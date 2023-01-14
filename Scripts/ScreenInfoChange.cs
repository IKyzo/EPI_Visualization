using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenInfoChange : MonoBehaviour
{
    [Tooltip("Place object named 'ArtistName' here. \nBaseForRotation > Main Camera > Canvas > ConstantPanel > ArtistProjectPanel > ArtistName")]
    public Text artistName;
    [Tooltip("Place object named 'ProjectName' here. \nBaseForRotation > Main Camera > Canvas > ConstantPanel > ArtistProjectPanel > ProjectName")]
    public Text projectName;
    [Tooltip("Place object named 'DescriptionName' here. \nBaseForRotation > Main Camera > Canvas > ConstantPanel > ArtistProjectPanel > ModelName")]
    public Text modelName;
    [Tooltip("Place object named 'DescriptionName' here. \nBaseForRotation > Main Camera > Canvas > ConstantPanel > DescriptionName")]
    public Text description;
	
	void Update ()
    {
        artistName.text = ModelOrganizer.models[ModelOrganizer.listPtr].
            GetComponent<ModelInfo>().artistName.ToString();
        projectName.text = ModelOrganizer.models[ModelOrganizer.listPtr].
            GetComponent<ModelInfo>().projectName.ToString();
        modelName.text = ModelOrganizer.models[ModelOrganizer.listPtr].
            GetComponent<ModelInfo>().modelName.ToString();
        description.text = ModelOrganizer.models[ModelOrganizer.listPtr].
            GetComponent<ModelInfo>().description.ToString();

    }
}
