using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideshowPlayer : MonoBehaviour
{
    int currentSlide = 0;
    List<GameObject> slidesList = new List<GameObject>();
    Transform canvas;
    void Start() {
        canvas = transform.GetChild(0);
        foreach (Transform slide in canvas) {
            slidesList.Add (slide.gameObject);
        }
        SetSlide();
    }

    void Update () {
        if (Input.GetKeyUp(KeyCode.UpArrow)) {
            if (currentSlide > 0) {
                currentSlide--;
                SetSlide();
            }
        }
        if (Input.GetKeyUp(KeyCode.DownArrow)) {
            if (currentSlide < slidesList.Count - 1) {
                currentSlide++;
                SetSlide();
            }
        }
    }
    void SetSlide() {
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
}
