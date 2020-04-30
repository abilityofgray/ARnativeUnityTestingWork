using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnSwitchCamera : MonoBehaviour
{
    Button bnt_cameraSwith;

    public PhoneCamera PhoneCamera;
    // Start is called before the first frame update
    void Start()
    {

        if (TryGetComponent<Button>(out Button bnt))
        {

            bnt.onClick.AddListener(CameraSwitch);

        }

    }

    void CameraSwitch() {

        PhoneCamera.SwitchCamera();

    }
}
