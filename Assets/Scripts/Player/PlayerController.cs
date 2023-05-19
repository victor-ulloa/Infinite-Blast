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

    [Header("Audio")]
    [SerializeReference] AudioClip fuelSfx;
    [SerializeReference] AudioClip crashSfx;

    PlayerControls input;
    Rigidbody rb;
    Animator animator;
    Vector3 startPosition;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        input = new PlayerControls();
    }

    private void Start()
    {
        startPosition = transform.position;
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
        Vector3 forwardMove = transform.right * speed * Time.fixedDeltaTime;
        if (isTouchDown)
        {
            rb.AddForce(transform.up * verticalSpeed * Time.fixedDeltaTime, ForceMode.Force);
        }
        rb.MovePosition(rb.position + forwardMove);
        GameManager.instance.distance = (int)(transform.position.x - startPosition.x);

    }

    public void OnPrimaryContact(InputAction.CallbackContext context)
    {
        if (!hasStarted)
        {
            rb.useGravity = true;
            hasStarted = true;
        }
        if (context.started)
        {
            if (fuelSfx)
            {
                GameManager.instance.AudioManager.Play(fuelSfx);
            }
            isTouchDown = true;
        }
        if (context.canceled)
        {
            GameManager.instance.AudioManager.Stop();
            isTouchDown = false;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (crashSfx)
        {
            // check that is playing fully after crash
            GameManager.instance.AudioManager.Play(crashSfx);
        }
        GameManager.instance.GameOver();
    }
}
