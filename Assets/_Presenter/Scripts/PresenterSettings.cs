using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PresenterSettings : MonoBehaviour
{
  public bool renderDebugScreens = false;

  ActivateDisplays labLabActivateDisplays;
  public List<GameObject> scenesList;

  int currentScene = 0;

  void Awake()
  {
    labLabActivateDisplays = GameObject.FindObjectOfType<ActivateDisplays>();
    if (!renderDebugScreens) {
      labLabActivateDisplays.transform.GetChild(0).gameObject.SetActive(false);
    }

    SetScene();
  }

  void Update () {
    if (Input.GetKeyUp(KeyCode.LeftArrow)) {
        if (currentScene > 0) {
            currentScene--;
            SetScene();
        }
    }
    if (Input.GetKeyUp(KeyCode.RightArrow)) {
        if (currentScene < scenesList.Count - 1) {
            currentScene++;
            SetScene();
        }
    }
  }

  void SetScene() {
    int index = 0;
    foreach (GameObject scene in scenesList) {
      if (currentScene == index) {
        scene.SetActive(true);
      }
      else {
        scene.SetActive(false);
      }
      index++;
    }
  }
}
