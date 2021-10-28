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
    private string triggerButton;

    public float moveSpeed = 20;

    public bool canSmoothRotate = false;
    public float rotateSpeed = 20;

    public bool canTeleport;
    public Transform teleportingHand;
    public LineRenderer line;
    public Vector3 curveHeight;
    public int lineResolution;

    private void Awake()
    {
        verticalAxis = "XRI_Left_Primary2DAxis_Vertical";
        horizontalAxis = "XRI_Left_Primary2DAxis_Horizontal";
        triggerButton = "XRI_Left_Trigger";
    }
    // Start is called before the first frame update
    void Start()
    {
        line.positionCount = lineResolution;
    }

    // Update is called once per frame
    void Update()
    {
        var verticalValue = Input.GetAxis(verticalAxis);
        var horizontalValue = Input.GetAxis(horizontalAxis);
        if (canSmoothMove)
            SmoothMove(verticalValue);
        if (canSmoothRotate)
            SmoothRotate(horizontalValue);
        if (canTeleport)
            Teleport();
        
    }

    void SmoothMove(float axisValue)
    {
        Vector3 lookDirection = new Vector3(head.forward.x, 0, head.forward.z);
        lookDirection.Normalize();

        XRRig.position += Time.deltaTime * lookDirection * axisValue * moveSpeed * -1;
    }

    void SmoothRotate(float axisValue)
    {
        XRRig.Rotate(Vector3.up, rotateSpeed * Time.deltaTime * axisValue);
    }

    void Teleport()
    {
        Ray ray = new Ray(teleportingHand.position, teleportingHand.forward);

        if(Physics.Raycast(ray, out RaycastHit hit))
        {
            line.enabled = true;

            Vector3 startPoint = teleportingHand.position;
            Vector3 endPoint = hit.point;
            Vector3 midPoint = ((endPoint - startPoint)/2 ) + startPoint;
            midPoint += curveHeight;

            for(int i=0; i<lineResolution; i++)
            {
                float t = i / (float)lineResolution;
                Vector3 startToMid = Vector3.Lerp(startPoint, midPoint, t);
                Vector3 midToEnd = Vector3.Lerp(midPoint, endPoint, t);

                Vector3 curvePosition = Vector3.Lerp(startToMid,midToEnd,t);

                line.SetPosition(i, curvePosition);
            }

            //Straight Line!
            //line.SetPosition(0,teleportingHand.position);
            //line.SetPosition(1, hit.point);
        }

        if (Input.GetButtonDown(triggerButton))
        {
            XRRig.position = hit.point;
        }
    }
}
