using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float horizontalInput, verticalInput;

    private bool isRunning;
    private float speed;
    private bool dancing;

    [SerializeField] private float runningSpeed;
    [SerializeField] private float normalSpeed;

    private Animator animator;
    private CharacterController characterController;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        characterController = GetComponent<CharacterController>();
        speed = normalSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        WalkAndRun();
        SillyDance();
    }

    private void WalkAndRun()
    {
        Vector3 move = new Vector3(horizontalInput, 0, verticalInput);
        animator.SetFloat("verticalInput", verticalInput);
        animator.SetFloat("horizontalInput", horizontalInput);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            isRunning = true;
            speed = runningSpeed;
        }
        else
        {
            isRunning = false;
            speed = normalSpeed;
        }
        animator.SetBool("isRunning", isRunning);
        characterController.Move(move * speed * Time.deltaTime);
    }

    private void SillyDance()
    {
        if (Input.GetKey(KeyCode.RightShift) && Input.GetKey(KeyCode.T))
        {
            dancing = true;
        }
        else
        {
            dancing = false;
        }
        animator.SetBool("dancing", dancing);
    }
}
