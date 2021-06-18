using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plyrMovement : MonoBehaviour
{
    //CharacterController controller;
    Rigidbody rb;

    //Variables related to movement
    [SerializeField] Transform cam; //Holds a reference to the main camera
    [SerializeField] float moveSpeed;
    private Vector2 moveAxis;
    private Vector3 moveDir; //Holds the direction that the player will move on the ground as a Vector3, where the Y axis will always be 0 and the X and Z axis are from the Vector2 movement
    private Vector3 relativeMoveDir;
    private float targetAngle; //The angle that the player will face in the direction that they're moving
    private float angle; //The angle that the player direction will be updated to based on their current angle, the target angle, and the turn speed
    [SerializeField] float turnSpeed;
    [SerializeField] float turnSmoothTime;

    private InputManager controls;
    // Start is called before the first frame update

    void Awake()
    {
        controls = new InputManager();
        cam = Camera.main.transform;
    }
    void Start()
    {
        //controller = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    private void Movement()
    {
        moveAxis = controls.Player.Movement.ReadValue<Vector2>();
        Debug.Log("MoveAxis: " + moveAxis + ", Input Axis: " + controls.Player.Movement.ReadValue<Vector2>());
        moveDir = new Vector3(moveAxis.x,0f,moveAxis.y);
        if(moveDir.magnitude >= 0.1f)
        {
            Rotation();
            relativeMoveDir = Quaternion.Euler(0f,targetAngle,0f) * Vector3.forward;
            //controller.Move(relativeMoveDir.normalized * moveSpeed * Time.deltaTime);
            rb.MovePosition(rb.position + (relativeMoveDir.normalized * moveSpeed * Time.deltaTime));
        }
    }

    private void Rotation()//Rotation handles the rotation of the player
    {
        targetAngle = Mathf.Atan2(moveDir.x,moveDir.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
        angle = Mathf.SmoothDampAngle(transform.eulerAngles.y,targetAngle, ref turnSpeed,turnSmoothTime);
        transform.rotation = Quaternion.Euler(0f, angle, 0f);
    }
    private void OnEnable()
    {
        controls.Enable();
    }
    private void OnDisable()
    {
        controls.Disable();
    }
}
