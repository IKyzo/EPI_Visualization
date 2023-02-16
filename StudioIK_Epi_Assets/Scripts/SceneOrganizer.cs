using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneOrganizer : MonoBehaviour
{
   public static SceneOrganizer instance;

   [SerializeField] private GameObject loaderCanvas;
   [SerializeField] private Image loadingCircle;
   private bool loadingAnimation = false;
   private float loadingAngle=-1f;
   private float loadingSpeed=100f;


   private void Awake() {
      if(instance == null)
      {
         instance = this;
         DontDestroyOnLoad(gameObject);
      }
      else
      {
         DestroyImmediate(gameObject);
      }
      //angles = loadingCircle.rectTransform.eulerAngles;
   }


   public async void LoadScene(string sceneName)
   {
      Debug.Log("Loading Scene");
      loadingAngle=-1f;
      var scene = SceneManager.LoadSceneAsync(sceneName);
      scene.allowSceneActivation = false;

      loaderCanvas.SetActive(true);
      loadingAnimation=true;
      //await Task.Delay(5000);
      if(scene.progress > 0.9f)
      {
         loadingAnimation=false;
      }
      
      
      scene.allowSceneActivation = true;
      loaderCanvas.SetActive(false);
      Debug.Log("Loading Scene Done");
   }


   private void Update() {
      if(loadingAnimation)
      {
         loadingAngle += Time.deltaTime * loadingSpeed * -1;
         loadingCircle.rectTransform.eulerAngles = new Vector3(0f, 0f, loadingAngle);
      }

   }









}
