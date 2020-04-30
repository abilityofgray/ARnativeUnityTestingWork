using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenOrientationListener : MonoBehaviour
{
    RectTransform _canvas;
    public PhoneCamera PhoneCamera;
    

    void Awake()
    {

        SetOrientation();

    }

    private void OnRectTransformDimensionsChange()
    {

        SetOrientation();

    }

    //Check Screen Device Orientation On Awake And When RectTrans Change Event
    public void SetOrientation() {

        if (Screen.width > Screen.height) {

            PhoneCamera.RepositionModel();

        }

        if (Screen.width < Screen.height) {

            PhoneCamera.RepositionModel();

        }

    }
}
