using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EzySlice;

public class cutter : MonoBehaviour
{
    Material mat;
    GameObject cuttingObj;
    playerMovement mov;

    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("canCut"))
        {
            cuttingObj = other.gameObject;
            mat = other.GetComponent<MeshRenderer>().material;
        }
    }

    void Update()
    {
        if (cuttingObj != null)
        {
            SlicedHull cutted = cut(cuttingObj,mat);
            GameObject cuttedUpper = cutted.CreateUpperHull(cuttingObj,mat);
            cuttedUpper.AddComponent<MeshCollider>().convex = true;
            cuttedUpper.AddComponent<Rigidbody>();
            
            Rigidbody upperRig = cuttedUpper.GetComponent<Rigidbody>();
            upperRig.AddForce(new Vector3(-650,0,0));

            cuttedUpper.layer = LayerMask.NameToLayer("cutted");
            
            GameObject cuttedLower = cutted.CreateLowerHull(cuttingObj,mat);
            cuttedLower.AddComponent<MeshCollider>().convex = true;
            cuttedLower.AddComponent<Rigidbody>();
            cuttedLower.layer = LayerMask.NameToLayer("cutted");
            Rigidbody lowerRig = cuttedLower.GetComponent<Rigidbody>();
            lowerRig.AddForce(new Vector3(650,0,0));
            
            Destroy(cuttingObj);

        }
    }

    private SlicedHull cut(GameObject obj, Material mat = null)
    {
        return obj.Slice( transform.position , transform.up , mat);
    }
}
