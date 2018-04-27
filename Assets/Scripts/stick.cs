using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stick : MonoBehaviour {
    // Use this for initialization
    void Start () {
        //rigidB = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter(Collider other)
    {
        
        //other.gameObject.transform.parent = gameObject.transform;
        
        if (other.gameObject.tag == "arrow")
        {
            Debug.Log("enter From inside");
            var xys = other.gameObject.transform;
            xys.parent = transform;
            //transform.GetComponent<ProjectileAddForce>().enabled = false;
            //rigidB.velocity = Vector3.zero;
            //rigidB.useGravity = false;
            //rigidB.isKinematic = true;



            //Embed();

        }
    }
   //void Embed()
   // {
   //     transform.GetComponent<ProjectileAddForce>().enabled = false;
   //     rigidB.velocity = Vector3.zero;
   //     rigidB.useGravity = false;
   //     rigidB.isKinematic = true;


   // }
}
