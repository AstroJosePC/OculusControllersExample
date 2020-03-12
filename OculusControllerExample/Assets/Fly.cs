using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Malimbe.PropertySerializationAttribute;
using Malimbe.XmlDocumentationAttribute;
using Malimbe.MemberClearanceMethod;
using Zinnia.Action;


public class Fly : MonoBehaviour
{

    // #region Movement Settings
    //[field: Header("Movement Settings")]
    public GameObject cameraRig;
    
    public GameObject head;
    
    public FloatAction leftTrigger;

    public FloatAction rightTrigger;


    [Range(1.0f, 10.0f)]
    public float flyingSpeed = 1.0f;
    [Range(0.05f, 0.2f)]
    public float tolerangeFly = 0.1f;
    //#endregion


    // private float flyingSpeeed = 1.0f;
    private bool isFlying = false;


    // Update is called once per frame
    void Update()
    {   
        if (leftTrigger.Value > tolerangeFly)
        {
            FlyIfFlying(false);
        }
        else if (rightTrigger.Value > tolerangeFly)
        {
            FlyIfFlying(true);
        }
    }

    void FlyIfFlying(bool forward)
    {
        Vector3 flyDirection = Vector3.forward;
        if (forward)
            cameraRig.transform.position += flyDirection.normalized * flyingSpeed * leftTrigger.Value;
        else
            cameraRig.transform.position -= flyDirection.normalized * flyingSpeed * rightTrigger.Value;
    }

}
