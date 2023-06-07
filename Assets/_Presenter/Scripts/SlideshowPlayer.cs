using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideshowPlayer : MonoBehaviour
{
    int currentSlide = 0;
    List<GameObject> slidesList = new List<GameObject>();
    Transform canvas;

    ChapterSettings parentChapter;

    void Start() {
        parentChapter = GetComponentInParent<ChapterSettings>();
        canvas = transform.GetChild(0);
        foreach (Transform slide in canvas) {
            slidesList.Add (slide.gameObject);
        }
        SetSlide();
    }

    void Update () {
        if (Input.GetKeyUp(KeyCode.LeftArrow)) {
            if (currentSlide > 0) {
                currentSlide--;
                SetSlide();
            }
        }
        if (Input.GetKeyUp(KeyCode.RightArrow)) {
            if (currentSlide < slidesList.Count - 1) {
                currentSlide++;
                SetSlide();
            }
        }
    }
    void SetSlide() {
        LockChapterLeftRightNavigation();
        int index = 0;
        foreach (GameObject slide in slidesList) {
            if (currentSlide == index) {
                slide.SetActive(true);
            }
            else {
                slide.SetActive(false);
            }
            index++;
        }
    }

    void LockChapterLeftRightNavigation() {
        if (currentSlide == 0) {
            // Allow for going backwards using arrow up/down
            parentChapter.lockPreviousChapter = false;
        }
        else {
            parentChapter.lockPreviousChapter = true;
        }

        if (currentSlide == slidesList.Count - 1) {
            // Allow for going forwards using arrow up/down
            parentChapter.lockNextChapter = false;
        }
        else {
            parentChapter.lockNextChapter = true;
        }
    }
}
