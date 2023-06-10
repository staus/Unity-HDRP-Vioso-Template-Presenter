using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TimelineCollection : MonoBehaviour
{
    ChapterSettings parentChapter;

    PlayableDirector[] timelines;
    int currentTimeline = -1;

    void Awake() {
        parentChapter = GetComponentInParent<ChapterSettings>();
        timelines = GetComponentsInChildren<PlayableDirector>();
    }

    void Start() {
        //SetTimeline();
    }
    void OnEnable() {
        ResetTimelines();
    }
    void OnDisable() {
        ResetTimelines();
    }
    void ResetTimelines() {
        LockChapterLeftRightNavigation();
        for(int i = 0; i < timelines.Length; i++) {
            timelines[i].playOnAwake = false;
            timelines[i].Stop();
            timelines[i].time = 0;
            timelines[i].Evaluate();
            timelines[i].Pause();
            Debug.Log("Stop Timeline");
        }
    }

    void Update () {
        if (Input.GetKeyUp(KeyCode.LeftArrow)) {
            if (currentTimeline > -1) {
                currentTimeline--;
                SetTimeline();
            }
        }
        if (Input.GetKeyUp(KeyCode.RightArrow)) {
            if (currentTimeline < timelines.Length - 1) {
                currentTimeline++;
                SetTimeline();
            }
        }
    }

    void SetTimeline() {
        LockChapterLeftRightNavigation();
        for(int i = 0; i < timelines.Length; i++) {
            if (currentTimeline == i) {
                timelines[i].time = 0f;
                timelines[i].Play();
            }
            else if (currentTimeline > i){
                // This timeline is in the past
                // Jump to end so states match
                timelines[i].time = timelines[i].duration;
                timelines[i].Evaluate();
                timelines[i].Pause();
            }
            else if (currentTimeline < i){
                // This timeline is in the future
                // Make sure it's reset
                timelines[i].time = 0f;
                timelines[i].Evaluate();
                timelines[i].Pause();
            }
        }
    }

    void LockChapterLeftRightNavigation() {
        if (currentTimeline == -1) {
            // Allow for going backwards using arrow up/down
            parentChapter.lockPreviousChapter = false;
        }
        else {
            parentChapter.lockPreviousChapter = true;
        }

        if (currentTimeline == timelines.Length - 1) {
            // Allow for going forwards using arrow up/down
            parentChapter.lockNextChapter = false;
        }
        else {
            parentChapter.lockNextChapter = true;
        }
    }
    
}
