using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelOrganizer : MonoBehaviour
{
    [HideInInspector]
    public static List<GameObject> models;
    [HideInInspector]
    public static int listPtr;

	void Start ()
    {
        models = new List<GameObject>();
        int i = 0;
        foreach(Transform child in transform)
        {
            models.Add(child.gameObject);
            if(i != 0)
            {
                models[i].SetActive(false);
            }
            i++;
        }
        listPtr = 0;
	}

    public void BackOneModel()
    {
        if (listPtr > 0)
        {
            models[listPtr].SetActive(false);
            listPtr--;
            models[listPtr].SetActive(true);
        }
        else
        {
            models[listPtr].SetActive(false);
            listPtr = models.Count - 1;
            models[listPtr].SetActive(true);
        }
    }

    public void ForwardOneModel()
    {
        if (listPtr < (models.Count-1))
        {
            models[listPtr].SetActive(false);
            listPtr++;
            models[listPtr].SetActive(true);
        }
        else
        {
            models[listPtr].SetActive(false);
            listPtr = 0;
            models[listPtr].SetActive(true);
        }
    }
}
