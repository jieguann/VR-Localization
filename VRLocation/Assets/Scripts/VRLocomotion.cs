using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRLocomotion : MonoBehaviour
{
    public bool canSmoothMove = false;

    private string verticalAxis;
    private string horizontalAxis;

    private void Awake()
    {
        verticalAxis = "XRI_Left_Primary2DAxis_Vertical";
        horizontalAxis = "XRI_Left_Primary2DAxis_Horizontal";
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var verticalValue = Input.GetAxis(verticalAxis);
    }
}
