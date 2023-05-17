using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PresenterSettings : MonoBehaviour
{
    public bool renderDebugScreens = false;

    ActivateDisplays labLabActivateDisplays;

    void Start()
    {
        labLabActivateDisplays = GameObject.FindObjectOfType<ActivateDisplays>();
        labLabActivateDisplays.transform.GetChild(0).gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
