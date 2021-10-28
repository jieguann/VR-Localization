using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LearpTest : MonoBehaviour
{
    [SerializeField]public Transform PointA;
    [SerializeField] public Transform PointB;
    [SerializeField] public Transform PointC;
    [SerializeField] public Transform PointX;

    [SerializeField] public Transform pointP;
    [SerializeField] public Transform pointQ;

    [Range(0.0f,1.0f)]
    public float lerpPosition;

    //private float timer;
    // Start is called before the first frame update
    void Start()
    {
        lerpPosition = 0;  
    }

    // Update is called once per frame
    void Update()
    {/*
        if(lerpPosition <= 1f)
        {
            lerpPosition += Time.deltaTime;
        }
        else
        {
            lerpPosition = 0;
        }
        */
        lerpPosition = lerpPosition <= 1 ? (lerpPosition += Time.deltaTime) : 0;

        pointP.position = Vector3.Lerp(PointA.position, PointB.position, lerpPosition);
        pointQ.position = Vector3.Lerp(PointB.position, PointC.position, lerpPosition);
        
    }


}
