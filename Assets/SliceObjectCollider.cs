using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EzySlice;


public class SliceObjectCollider : MonoBehaviour
{
    
    GameObject objectToUse;
     
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            objectToUse.transform.position= Vector3.Lerp(objectToUse.transform.position, transform.position, 5);
            
        } 
        if (Input.GetMouseButtonDown(1)){
            SlicedHull GMB = Slice(objectToUse);
            GameObject GMU = GMB.CreateUpperHull(objectToUse, objectToUse.GetComponent<MeshRenderer>().material);
            GMU.AddComponent<MeshCollider>().convex = true;
            GMU.AddComponent<Rigidbody>();
            GMU.layer = 2;
            GameObject GML = GMB.CreateLowerHull(objectToUse, objectToUse.GetComponent<MeshRenderer>().material);
            GML.AddComponent<MeshCollider>().convex = true;
            GML.AddComponent<Rigidbody>();
            GML.layer = 2;
            Destroy(objectToUse);
        }
       
       
    }
    
     void OnTriggerEnter(Collider other)
    {
        
        objectToUse = other.gameObject;
        
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == objectToUse)
        {
            objectToUse = null;
        }
    }
    public SlicedHull Slice(GameObject obj)
    {
        return obj.Slice(transform.position, transform.up);
    }

}
