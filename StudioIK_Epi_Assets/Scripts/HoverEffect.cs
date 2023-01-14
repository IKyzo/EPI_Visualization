using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverEffect : MonoBehaviour
{
    public Renderer cube;
    public GameObject sign;
    private Color colorActive;
    private Color colorInactive;

    private void Start() {
      colorActive = cube.material.color;
      colorInactive = cube.material.color;
      colorActive.a=0.3f;
      
    }
    // Start is called before the first frame update
   private void OnMouseOver() {
     sign.SetActive(true);
     cube.material.color = colorActive;
     //cube.SetColor("_Color", _color);
     
   }
   private void OnMouseExit() {
    sign.SetActive(false);
    cube.material.color = colorInactive;
   }
}
