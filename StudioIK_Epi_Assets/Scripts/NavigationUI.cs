using UnityEngine;
using UnityEngine.UIElements;


public class NavigationUI : MonoBehaviour
{
    //public CubeController cube;
    public SceneCenter sceneController;
    private VisualElement root;
    private Button buttonNavigate;


    private void Awake() {
        root = GetComponent<UIDocument>().rootVisualElement;
        buttonNavigate = root.Q<Button>("Navigation"); 
        //transitionColor = transition.style.backgroundColor;
    }
    private void OnEnable() {
        Debug.Log("This was set");
        buttonNavigate.clicked += () => SceneOrganizer.instance.LoadScene("SecondaryScene");
        //buttonNavigate.clicked += () => Cubemap.StartRotate();
    }

}
