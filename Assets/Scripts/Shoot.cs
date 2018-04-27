using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shoot : MonoBehaviour {
   
    [SerializeField]
    float pullSpeed;
    [SerializeField]
    GameObject arrowPrefab;
    [SerializeField]
    GameObject arrow;
    //[SerializeField]
     int numberOfArrow = 10;
    [SerializeField]
    GameObject bow;
    bool arrowSlotted = false;
    float pullAmount = 0;

    [SerializeField]
    AudioSource stringSound;
    [SerializeField]
    AudioSource fireSound;
   
   
    // for taking text value from editor
    [SerializeField]
    Text arrowLeft;
    [SerializeField]
    Text gameOver;

    // Use this for initialization
    void Start () {
        SpawnArrow();
        

    }
	
	// Update is called once per frame
	void Update () {
        ShootLogic();
        arrowLeft.text = "ARROW LEFT: " + numberOfArrow.ToString();

    }

    void SpawnArrow()
    {
        if(numberOfArrow > 0)
        {
            arrowSlotted = true;
            arrow = Instantiate(arrowPrefab, transform.position, transform.rotation) as GameObject;
            arrow.transform.parent = transform;
        }
    }

    void ShootLogic()
    {
       
        if (numberOfArrow > 0)
        {
            if (pullAmount > 100)
                pullAmount = 100;

            SkinnedMeshRenderer _bowSkin = bow.transform.GetComponent<SkinnedMeshRenderer>();
            SkinnedMeshRenderer _arrowSkin = arrow.transform.GetComponent<SkinnedMeshRenderer>();
            Rigidbody _arrowRigidB = arrow.transform.GetComponent<Rigidbody>();
            ProjectileAddForce _arrowProjectile = arrow.transform.GetComponent<ProjectileAddForce>();
            //string sound play
            if (Input.GetMouseButtonDown(0))
                stringSound.Play();
            if (Input.GetMouseButton(0))
            {
                pullAmount += Time.deltaTime * pullSpeed;
                //to stop string sound
                if (pullAmount >= 100)
                    stringSound.Stop();
             
            }

            if (Input.GetMouseButtonUp(0))
            {
                //firesound when mouse button is up
                fireSound.Play();
                //when arrow is released
                stringSound.Stop();
                arrowSlotted = false;
                _arrowRigidB.isKinematic = false;
                arrow.transform.parent = null;
              //  _arrowProjectile.enabled = true;
                _arrowProjectile.shootForce = _arrowProjectile.shootForce * ((pullAmount / 300) + 0.5f);
                numberOfArrow -= 1;
               
                pullAmount = 0;

                _arrowProjectile.enabled = true;

            }
            _bowSkin.SetBlendShapeWeight(0, pullAmount);
            _arrowSkin.SetBlendShapeWeight(0, pullAmount);
           // _arrowProjectile.enabled = true;
            if (Input.GetMouseButtonDown(0) && arrowSlotted == false)
                SpawnArrow();
        }

        else
        {
            gameOver.text = "Game Over";
        }

    }
}
