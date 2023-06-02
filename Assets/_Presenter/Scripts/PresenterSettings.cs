using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PresenterSettings : MonoBehaviour
{
  public bool renderDebugScreens = false;

  ActivateDisplays labLabActivateDisplays;
  public List<GameObject> chaptersList;

  int currentChapter = 0;

  void Awake()
  {
    labLabActivateDisplays = GameObject.FindObjectOfType<ActivateDisplays>();
    if (!renderDebugScreens) {
      labLabActivateDisplays.transform.GetChild(0).gameObject.SetActive(false);
    }

    SetChapter();
  }

  void Update () {
    if (Input.GetKeyUp(KeyCode.LeftArrow)) {
        if (currentChapter > 0) {
            currentChapter--;
            SetChapter();
        }
    }
    if (Input.GetKeyUp(KeyCode.RightArrow)) {
        if (currentChapter < chaptersList.Count - 1) {
            currentChapter++;
            SetChapter();
        }
    }
  }

  void SetChapter() {
    int index = 0;
    foreach (GameObject chapter in chaptersList) {
      if (currentChapter == index) {
        chapter.SetActive(true);
      }
      else {
        chapter.SetActive(false);
      }
      index++;
    }
  }
}
