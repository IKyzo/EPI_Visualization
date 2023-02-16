using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class InteriorUI : MonoBehaviour
{
    private VisualElement root;
    private VisualElement menuList;
    private VisualElement menuIcon;
    private Button menuButton;

    private void Awake() {
        root = GetComponent<UIDocument>().rootVisualElement;
        menuList = root.Q<VisualElement>("Container");
        menuIcon = root.Q<VisualElement>("ContainerMenu");
        menuButton = menuIcon.Q<Button>("MenuIcon");
    }

    private void OnEnable() {
        menuButton.clicked += () => check();    
    }



    private void check()
    {
        switch (menuList.visible)
        {
            case true:
                menuList.visible=false; 
                break;
            case false:
                menuList.visible=true;
                menuList.style.width = (root.worldBound.size.x/100)*30 ;
                break;
        }
    }
}
