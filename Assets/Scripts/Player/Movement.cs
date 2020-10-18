using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    public Rigidbody body;
    public float walkSpeed = 10;

    PlayerControls controls;
    Vector2 move;
    Vector2 look;
    bool fire = false;

    void Awake()
    {
        controls = new PlayerControls();

        controls.Gameplay.Move.performed += ctx => move = ctx.ReadValue<Vector2>();
        controls.Gameplay.Move.canceled  += ctx => move = Vector2.zero;

        controls.Gameplay.Look.performed += ctx => look = ctx.ReadValue<Vector2>();
        controls.Gameplay.Look.canceled  += ctx => look = Vector2.zero;

        controls.Gameplay.Fire.performed += ctx => fire = true;
        controls.Gameplay.Fire.canceled  += ctx => fire = false;
    }


    void FixedUpdate()
    {
        body.AddForce(new Vector3(move.x, 0, move.y) * walkSpeed);
    }

    void OnEnable()
    {
        controls.Gameplay.Enable();
    }

    void OnDisable()
    {
        controls.Gameplay.Disable();
    }
}
