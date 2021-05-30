using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    private GameObject pivot;
    private Rigidbody rigid;
    
    void Start()
    {
        pivot = GameObject.FindGameObjectWithTag("pivot");
        rigid = GetComponent<Rigidbody>();
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("canCut"))
        {
            
        }

    }

    // Update is called once per frame
    void Update()
    {
        pivot.transform.position = this.transform.position;

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 force = new Vector3(0,850,-75);
            Vector3 pos = new Vector3(0,0,0);
            rigid.AddForce(force);
        }

    }
}
