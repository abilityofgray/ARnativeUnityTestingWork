using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhoneCamera : MonoBehaviour
{
    private bool camAvailable;
    private WebCamTexture backCam;
    private Texture defaultBackground;
    private int DeviceCameraIndex;
    private int CurrentCameraIndex;

    public RawImage Background;
    public AspectRatioFitter Fitter;
    public GameObject Model;
    

    WebCamDevice[] devices;
    float biggerModelSideSize;
    Vector3 modelSize;

    void Start()
    {
        
        defaultBackground = Background.texture;
        devices = WebCamTexture.devices;
        

        if (Model.GetComponentInChildren<MeshRenderer>() != null)
        {

            MeshRenderer modelMesh = Model.GetComponentInChildren<MeshRenderer>();
            modelSize = modelMesh.bounds.size;

        }

        if (devices.Length == 0) {

            
            camAvailable = false;
            return;

        }

        for (int i = 0; i < devices.Length; i++)
        {


            
            if (!devices[i].isFrontFacing)
            {
                
                CurrentCameraIndex = i;
                backCam = new WebCamTexture(devices[i].name, 
                    Screen.width, 
                    Screen.height);
                RepositionModel();
            }

            if (backCam == null)
            {

                
                return;

            }
            
            backCam.Play();
            Background.texture = backCam;

            camAvailable = true;
        }
        
        
    }

    public void RepositionModel() {
        
        FindBiggerModelSide();

        //check if 3d model exist
        if (Model != null) {

            //TODO: Take screen side compare from ScreenOrientation
            if (Screen.width > Screen.height)
            {

                float leftScreenSide = (Screen.width / 4) / 10 - 10f;

                Model.transform.position = new Vector3(biggerModelSideSize + 15f,
                   Model.transform.position.y,
                   -1735f);

            }
            else
            {

                float leftScreenSide = Screen.width / 4;
                Model.transform.position = new Vector3(biggerModelSideSize / 2,
                    Model.transform.position.y,
                    -1700f);

            }

        }

     }

    //Compare Model Bounds
    void FindBiggerModelSide() {

        if (modelSize.x > modelSize.z) {

            biggerModelSideSize = modelSize.x;

        }

        if (modelSize.x < modelSize.z)
        {

            biggerModelSideSize = modelSize.z;

        }

        if (modelSize.x == modelSize.z) {

            biggerModelSideSize = modelSize.x;

        }

    }

    public void SwitchCamera() {

        if (devices.Length > 0) {

            CurrentCameraIndex += 1;
            CurrentCameraIndex %= devices.Length;
            
            DeviceCameraIndex = CurrentCameraIndex;
            backCam = new WebCamTexture(devices[CurrentCameraIndex].name,
                    Screen.width,
                    Screen.height);

                
            if (backCam == null)
            {

               return;

            }

            backCam.Play();
            Background.texture = backCam;

            camAvailable = true;

        }

        RepositionModel();

    }

    void Update()
    {

        if (!camAvailable)
            return;

        float ratio = (float)backCam.width / (float)backCam.height;
        Fitter.aspectRatio = ratio;

        float scaleY = backCam.videoVerticallyMirrored ? -1f : 1f;
        Background.rectTransform.localScale = new Vector3(1f, scaleY, 1f);

        int orient = -backCam.videoRotationAngle;
        Background.rectTransform.localEulerAngles = new Vector3(0, 0, orient);

    }
    //TODO: CleanUp if not using it all
    void CameraTexturePlay()
    {

        backCam.Play();
        Background.texture = backCam;

        camAvailable = true;

    }
    //TODO: CleanUp if not using it all
    void CameraTextureRefresh()
    {

        Background.texture = backCam;

    }
    //TODO: CleanUp if not using it all
    void CameraTextureStop()
    {

        backCam.Stop();
        Background.texture = backCam;

    }

}
