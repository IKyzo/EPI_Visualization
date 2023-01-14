using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelInfo : MonoBehaviour
{
    [Tooltip("The name of the artist who made the model.")]
    public string artistName;
    [Tooltip("The name of the project the model was made for.")]
    public string projectName;
    [Tooltip("The name of the model/prop.")]
    public string modelName;
    [Tooltip("A short description about what the model was made for.")]
    [TextArea]
    public string description;
    [Tooltip("The model you want to display\nThe model should be a child of the gameobject this script is attached to.")]
    public GameObject model;
    [Tooltip("Whether or not you can see the underside of the model.\nUncheck the box if you don't want the underside seen.")]
    public bool shouldSeeUnderside = true;
}
