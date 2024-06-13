using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EzySlice; // slicing objects package import, name of asset folder 

public class ObjectSlicer : MonoBehaviour
{
    public Transform startSlicingPoint;
    public Transform endSlicingPoint;
    public LayerMask sliceableLayer;
    public VelocityEsimator velocityEstimator;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Vector3 slicingDirection = endSlicingPoint.position - startSlicingPoint.position;
        bool hasHit = Physics.Raycast(startSlicingPoint.position, slicingDirection, out hit, slicingDirection.magnitude, sliceableLayer);

        if (hasHit)
        {
            Slice(hit.transform.gameObject, hit.point, velocityEstimator.GetVelocityEsimate()); // when hit an object, hiting point of raycast, 
        }
    }

    void Slice(GameObject target, Vector3 planePosition, Vector3 slicerVelocity)
    {
        Debug.Log("object sliced!!!!");
    }
}


