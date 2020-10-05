using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController controller;

    //[Header movement]
    public float speed = 8f;
    public float sprintSpeed = 16f;
    public float gravity = -10f;
    public float jumpHeight = 3f;

    //[Header health]
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;

    public Level01Controller levelController;

    //[Header Weapon]
    [SerializeField] AudioClip _weaponFire = null;
    [SerializeField] GameObject _weaponParticles;
    public ParticleSystem _particles;

    //[Header GroundChecks]
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    Vector3 velocity;
    bool isGrounded;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    public void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if(Input.GetKeyDown(KeyCode.LeftShift) && isGrounded)
        {
            Sprint();
        }

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        //if getkeydown left mouse button is clicked Fire();
        if (Input.GetKeyDown(KeyCode.Mouse0) && isGrounded)
        {
            Fire();
        }
        if (Input.GetKeyUp(KeyCode.Mouse0) && isGrounded)
        {
            _weaponParticles.SetActive(false);
        }

        if (currentHealth < 0)
        {
            PlayerDied();
        }
    }

    private void Sprint()
    {
        speed = sprintSpeed;
        Debug.Log("You are sprinting!");
    }
    
     private void Fire()
     {
        //trigger particle effect
        //bool currentIsActive = _weaponParticles.activeSelf;
        //_weaponParticles.SetActive(!currentIsActive);

        _weaponParticles.SetActive(true);

        AudioHelper.PlayClip2D(_weaponFire, 1);
     }

    public void TakeDamage()
    {
        currentHealth -= 10;
        healthBar.SetHealth(currentHealth);
        Debug.Log("You took damage!");
    }

    public void PlayerDied()
    {
        Debug.Log("You died!");
        levelController.RetryMenu();
    }
}
