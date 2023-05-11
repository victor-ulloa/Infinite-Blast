using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour, PlayerControls.ITouchActions
{

    [SerializeField] float speed = 10f;
    // [SerializeField] float speedMultiplier = 0.1f;

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
        // Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
        // rb.MovePosition(rb.position + forwardMove);

    }

    private void Update()
    {

    }


    public void OnPrimaryContact(InputAction.CallbackContext context)
    {
        if (context.started) {
            Debug.Log("STARTED");
        }
        if (context.canceled) {
            Debug.Log("CANCELED");
        }

    }
}
