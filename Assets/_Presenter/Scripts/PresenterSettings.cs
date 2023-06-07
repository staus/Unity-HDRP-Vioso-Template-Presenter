using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PresenterSettings : MonoBehaviour
{
  public bool renderDebugScreens = false;

  ActivateDisplays labLabActivateDisplays;
  public List<ChapterSettings> chaptersList;

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
    if (Input.GetKeyUp(KeyCode.UpArrow)) {
      PreviousChapter();
    }
    if (Input.GetKeyUp(KeyCode.DownArrow)) {
      NextChapter();
    }

    if (Input.GetKeyUp(KeyCode.LeftArrow)) {
      if (!chaptersList[currentChapter].lockPreviousChapter){
        PreviousChapter();
      }
    }
    if (Input.GetKeyUp(KeyCode.RightArrow)) {
      if (!chaptersList[currentChapter].lockNextChapter){
        NextChapter();
      }
    }
  }

  void PreviousChapter() {
    if (currentChapter > 0) {
      currentChapter--;
      SetChapter();
    }
  }

  void NextChapter() {
    if (currentChapter < chaptersList.Count - 1) {
      currentChapter++;
      SetChapter();
    }
  }

  void SetChapter() {
    int index = 0;
    foreach (ChapterSettings chapter in chaptersList) {
      if (currentChapter == index) {
        chapter.gameObject.SetActive(true);
      }
      else {
        chapter.gameObject.SetActive(false);
      }
      index++;
    }
  }
}
