using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour, PlayerControls.ITouchActions
{

    [SerializeField] float speed = 10f;
    [SerializeField] float verticalSpeed = 10f;
    [SerializeField] bool isTouchDown;
    [SerializeField] bool hasStarted;

    [SerializeField] LayerMask groundMask;

    PlayerControls input;
    Rigidbody rb;
    Animator animator;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        input = new PlayerControls();
    }

    private void OnEnable()
    {
        input.Touch.SetCallbacks(this);
        input.Enable();
    }

    private void OnDisable()
    {
        input.Touch.SetCallbacks(null);
        input.Disable();
    }

    private void FixedUpdate()
    {
        if (!hasStarted) { return; }
        Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime  * 0;
        if (isTouchDown) {
            rb.AddForce(transform.up * verticalSpeed * Time.fixedDeltaTime, ForceMode.Force);
        }
        // rb.MovePosition(rb.position + forwardMove);

    }

    private void Update()
    {

    }


    public void OnPrimaryContact(InputAction.CallbackContext context)
    {
        if (!hasStarted) { hasStarted = true; }
        if (context.started) {
            isTouchDown = true;
        }
        if (context.canceled) {
            isTouchDown = false;
        }

    }
}
