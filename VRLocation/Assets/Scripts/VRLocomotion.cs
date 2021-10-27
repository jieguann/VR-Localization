using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRLocomotion : MonoBehaviour
{
    public Transform XRRig;
    public Transform head;

    public bool canSmoothMove = false;

    private string verticalAxis;
    private string horizontalAxis;

    public float moveSpeed = 20;
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
        if (canSmoothMove)
        {
            SmoothMove(verticalValue);
        }
    }

    void SmoothMove(float axisValue)
    {   

        XRRig.position += Time.deltaTime * head.forward * axisValue * moveSpeed;
    }
}
