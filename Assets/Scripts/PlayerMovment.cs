using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerMovment : MonoBehaviour
{
    // Private
    [SerializeField] private Rigidbody rb;
    private PlayerInput PlayerInputAction;
    private Vector2 MovementDirection = Vector2.zero;

    // Public
    public float movespeed = 5f;
    
    // Start is called before the first frame update
    void Start()
    {
        PlayerInputAction = GetComponent<PlayerInput>();

    }

    // Update is called once per frame
    void Update()
    {
        MovementDirection = PlayerInputAction.actions["Move"].ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector3(MovementDirection.x * movespeed, rb.velocity.y, MovementDirection.y * movespeed);
    }
}
