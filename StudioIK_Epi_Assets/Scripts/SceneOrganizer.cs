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
      var scene = SceneManager.LoadSceneAsync(sceneName);
      scene.allowSceneActivation = false;

      loaderCanvas.SetActive(true);


      do {
         await Task.Delay(100);
         loadingCircle.rectTransform.eulerAngles = new Vector3(0f, 0f, -90f);

      } while(scene.progress < 0.9f);
      
      await Task.Delay(5000);
      scene.allowSceneActivation = true;
      loaderCanvas.SetActive(false);
   }









}
