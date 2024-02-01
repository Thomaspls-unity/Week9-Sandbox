using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField] private GameObject doorVisual;

    private MeshRenderer doorVisualRenderer;
    private Color defaultDoorColour;
    private Animator doorVisualAnim;
    // Start is called before the first frame update
    void Start()
    {
        doorVisualRenderer = doorVisual.GetComponent<MeshRenderer>();
        defaultDoorColour = doorVisualRenderer.material.color;
        doorVisualAnim = doorVisual.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            doorVisualRenderer.material.color = Color.green;
            Debug.Log("Press E to open door");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            doorVisualRenderer.material.color = defaultDoorColour;
            doorVisualAnim.SetBool("doorOpen", false);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            doorVisualAnim.SetBool("doorOpen", true);
        }
    }
}
