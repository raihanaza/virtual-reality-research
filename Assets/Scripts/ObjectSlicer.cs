// much thanks to Valem Tutorials in his video Remaking Fruit Ninja

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EzySlice; // slicing objects package import, name of asset folder 

public class ObjectSlicer : MonoBehaviour
{
    public float slicedObjectInitialVelocity = 100;
    public Material slicedMaterial; // helps to render sliced object so not just pink 
    public Transform startSlicingPoint;
    public Transform endSlicingPoint;
    public LayerMask sliceableLayer;
    public VelocityEstimator velocityEstimator;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        UnityEngine.Vector3 slicingDirection = endSlicingPoint.position - startSlicingPoint.position;
        bool hasHit = Physics.Raycast(startSlicingPoint.position, slicingDirection, out hit, slicingDirection.magnitude, sliceableLayer);

        if (hasHit)
        {
            Slice(hit.transform.gameObject, hit.point, velocityEstimator.GetVelocityEstimate()); // when hit an object, hiting point of raycast, 
        }
    }

    void Slice(GameObject target, UnityEngine.Vector3 planePosition, UnityEngine.Vector3 slicerVelocity)
    {
        Debug.Log("object sliced!!!!");

        UnityEngine.Vector3 slicingDirection = endSlicingPoint.position - startSlicingPoint.position;
        UnityEngine.Vector3 planeNormal = UnityEngine.Vector3.Cross(slicerVelocity, slicingDirection);

        SlicedHull hull = target.Slice(planePosition, planeNormal, slicedMaterial);

        if (hull != null)
        {
            GameObject upperHull = hull.CreateUpperHull(target, slicedMaterial);
            GameObject lowerHull = hull.CreateLowerHull(target, slicedMaterial);

            CreateSlicedComponent(upperHull);
            CreateSlicedComponent(lowerHull);

            // destroy initial game object to 'slice'
            Destroy(target);
        }
    }

    void CreateSlicedComponent(GameObject slicedHull)
    {
        Rigidbody rb = slicedHull.AddComponent<Rigidbody>();
        MeshCollider collider = slicedHull.AddComponent<MeshCollider>(); 
        collider.convex = true;

        rb.AddExplosionForce(slicedObjectInitialVelocity, slicedHull.transform.position, 1); // when slicing object, makes it move in opposite direction

        Destroy(slicedHull, 4); // destroy the sliced object after 4 seconds 

    }
}
