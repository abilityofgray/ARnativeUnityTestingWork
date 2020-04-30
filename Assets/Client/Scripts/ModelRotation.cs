using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelRotation : MonoBehaviour
{

    [Header("Rotate Settings")]
    public float Speed;

    public enum RotateDirection {

        Left, Right,
        Up,Down

    }

    public RotateDirection RotationDirection;

    Vector3 rotateDirectionVector;

    private void Start()
    {

        InitModelRotateDirect();

    }

    //3D Model Rotate Direction
    void InitModelRotateDirect() {

        switch(RotationDirection) {

            case RotateDirection.Down:

                rotateDirectionVector = Vector3.down;

            break;

            case RotateDirection.Up:

                rotateDirectionVector = Vector3.up;

            break;

            case RotateDirection.Left:

                rotateDirectionVector = Vector3.left;

            break;

            case RotateDirection.Right:

                rotateDirectionVector = Vector3.right;

            break;

        }

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        float deltaTime = Time.deltaTime;
        transform.Rotate(rotateDirectionVector * Speed * deltaTime);

    }

}
