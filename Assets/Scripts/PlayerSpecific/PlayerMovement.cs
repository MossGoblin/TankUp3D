using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] GameMaster master;
    [SerializeField] float baseSpeed;
    [SerializeField] float currentSpeed;
    [SerializeField] float baseRotationSpeed;
    [SerializeField] float currentRotationSpeed;
    private Transform playerTransform;
    [SerializeField] Transform groundCheck;
    [SerializeField] float groundDistance;
    [SerializeField] LayerMask groundMask;
    [SerializeField] Tank playerTank;
    Vector3 velocity;
    public const float gravity = -9.81f;
    public float gravityFactor;
    private bool isGrounded;
    // refs
    Rigidbody rb;
    [SerializeField] CharacterController controller;

    void Awake()
    {
        playerTank = master.player.tank;
    }
    void Start()
    {
        controller = GetComponent<CharacterController>();
        playerTransform = GetComponent<Transform>();
        int startPositionW = master.gridMaster.width / 2;
        int startPositionD = master.gridMaster.depth / 2;
        Vector3 newPosition = new Vector3(startPositionW, 0f, startPositionD);
        playerTransform.position = newPosition;
        currentSpeed = baseSpeed;
        currentRotationSpeed = baseRotationSpeed;

    }

    // Update is called once per frame
    void Update()
    {
        // factorize speed
        currentSpeed = baseSpeed - playerTank.speedFactor * 0.1f;
        currentRotationSpeed = baseRotationSpeed - playerTank.rotationSpeedFactor * 0.1f;

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        float inputX = Input.GetAxis("Horizontal");
        float inputZ = Input.GetAxis("Vertical");

        playerTransform.Rotate(Vector3.up * inputX * currentRotationSpeed);

        Vector3 moveVector = transform.forward * inputZ;
        controller.Move(moveVector * currentSpeed * Time.deltaTime);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        else
        {
            velocity.y += gravity * gravityFactor * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);
        }
    }
}
