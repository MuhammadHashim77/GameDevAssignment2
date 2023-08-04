using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Vector3 movement;
    [SerializeField] private float movementSpeed = 5f;
    [SerializeField] private float rotationSpeed = 720f;
    private AudioSource source;
    [SerializeField] private AudioClip movementSound;

    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        source = GetComponent<AudioSource>();
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

        movement = new Vector3(horizontal, 0f, vertical) * movementSpeed * Time.deltaTime;
        movement.Normalize();

        transform.Translate(movement * movementSpeed * Time.deltaTime, Space.World);

        if(movement != Vector3.zero)
        {
            animator.SetBool("Walk", true);
            Quaternion toRotation = Quaternion.LookRotation(movement, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);

            if (!source.isPlaying)
            {
                source.clip = movementSound;
                source.Play();
            }
        }
        else
        {
            animator.SetBool("Walk", false);

            if (source.isPlaying)
            {
                source.Stop();
            }
        }
    }

    private void Animation()
    {
        if(Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift))
        {
            animator.SetBool("Running", true);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            animator.SetBool("Jump", true);
        }
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.Space))
        {
            animator.SetBool("LongJump", true);
        }
        if (Input.GetKey(KeyCode.C))
        {
            animator.SetBool("Crouch", true);
        }

        if (Input.GetKey(KeyCode.M))
        {
            animator.SetBool("Dance", true);
        }
        else
        {
            animator.SetBool("Dance", false);
        }
    }

}
