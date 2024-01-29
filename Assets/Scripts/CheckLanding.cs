using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckLanding : MonoBehaviour
{
    public Transform checkLandingPoint;
    public LayerMask layerMask;
    public float landingDistance;
    public Animator animator;
    public RaycastHit hit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Physics.Raycast(checkLandingPoint.position, checkLandingPoint.forward, out hit, landingDistance, layerMask))
        {
            animator.SetBool("Land", true);
        }
    }
}
