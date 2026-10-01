using UnityEngine;

public class Mover2D : MonoBehaviour
{
    public float speed = 1;
    InputSystem_Actions input;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        input = new InputSystem_Actions();
        input.Enable();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 dir =input.Player.Move.ReadValue<Vector2>();

        transform.position = transform.position += dir * Time.deltaTime * speed;
    }
}
