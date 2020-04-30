using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnExitApp : MonoBehaviour
{

    Button _btn_exit;

    // Start is called before the first frame update
    void Awake()
    {

        if (TryGetComponent<Button> (out Button button))
        {

            button.onClick.AddListener(ExitApplication);

        }

    }

    void ExitApplication() {
       
        Application.Quit();

    }

}
