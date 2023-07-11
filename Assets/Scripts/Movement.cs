using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Vector3 movement;
    [SerializeField] private float movementSpeed = 5f;
    [SerializeField] private float rotationSpeed = 720f;
    [SerializeField] private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        CharacterMovementRotation();
    }

    private void CharacterMovementRotation()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        movement = new Vector3(horizontal, 0f, vertical);
        movement.Normalize();

        transform.Translate(movement * movementSpeed * Time.deltaTime, Space.World);

        if(movement != Vector3.zero)
        {
            animator.SetBool("Running", true);
            Quaternion toRotation = Quaternion.LookRotation(movement, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
        else
        {
            animator.SetBool("Running", false);
        }
    }

}
