using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

[DisallowMultipleComponent]
public class ps_PlayerMovement : MonoBehaviour
{
    //lOCALVARS
    private bool isGrounded;
    private bool isBonking;
    private Vector3 velocity;


    [Header("Statistics")]
    [SerializeField] public float speed = 10f;
    [SerializeField] public float jumpPower = 2f;
    [SerializeField] private float gravity = -9.82f;
    [SerializeField] private ps_Inventory inventory;

    //MULTIPLIERS
    private float _mult_speed    = 1f;
    private float _mult_gravity  = 2f;
    private float _mult_jump     = 1f;
    private float _T_mult_speed  = 1f;

    [Header("Object References")]
    [SerializeField] public CharacterController controller;

    [SerializeField] public Transform groundCheck;
    [SerializeField] public float groundDistance = 0.2f;
    [SerializeField] public LayerMask groundLayerMask;

    [SerializeField] public Transform bonkCheck;
    [SerializeField] public float bonkDistance = 0.2f;






    // Start is called before the first frame update
    void Start()
    {
        IsGroundedGO();
    }

    // Update is called once per frame
    void Update()
    {
        hand_Gravity();
        hand_Inputs();
        hand_Jump();
        hand_Walk();
        hand_Shooting();
    }

    //Functions
    #region SCHMOOVEMENT
    private void hand_Inputs()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * _T_mult_speed * Time.deltaTime);
    }
    #endregion

    #region WALKING
    private void hand_Walk()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl)) { _mult_speed = 0.5f; }
        if (Input.GetKeyUp(KeyCode.LeftControl)) { _mult_speed = 1f; }

        if (isGrounded) { _T_mult_speed = speed * _mult_speed; }
        else { _T_mult_speed = speed; }
    }
    #endregion

    #region JUMPING
    private void hand_Jump()
    {
        IsBonking();
        if (isGrounded && !isBonking && Input.GetButton("Jump")) {
            velocity.y = Mathf.Sqrt(jumpPower * _mult_jump * -2f * gravity);
        }
    }
    #endregion

    #region GRAVITY
    private void hand_Gravity()
    {
        IsGroundedGO();
        //Gravity
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; // ensure the player sticks to the geo
        }
        else
        {
            velocity.y += gravity * _mult_gravity * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);
        }
    }
    #endregion

    #region ISGROUNDED
    private bool IsGroundedGO() //Returns whether or not the GAME OBJECT ground check has hit the second tower.
    {
        return isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundLayerMask);
    }
    #endregion

    #region ISBONKING
    private bool IsBonking()
    {
        return isBonking = Physics.CheckSphere(bonkCheck.position, bonkDistance, groundLayerMask);
    }
    #endregion

    #region SHOOTING
    private void hand_Shooting()
    {
        if (Input.GetButton("Fire1") && inventory.heldGun != null)
        {
            inventory.heldGun.Shoot();
            
        }
    }
    #endregion

    // GETTERS AND SETTERS
    #region SETTERS_AND_GETTERS
    public float mult_speed { get { return _mult_speed; } set { _mult_speed = value; } }
    public float mult_jumpPower { get { return _mult_jump; } set { _mult_jump = value; } }
    public float mult_gravity { get { return _mult_gravity; } set { _mult_gravity = value; } }
    #endregion



}

