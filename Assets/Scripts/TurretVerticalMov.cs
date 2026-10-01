using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class TurretVerticalMov : MonoBehaviour
{
    public GameObject torso;
    public GameObject body;


    public float sensivity = 1f;

    public DeltaControl delta { get; protected set; }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 delta = Mouse.current.delta.ReadValue();

        float mouseX = delta.x;
        float mouseY = delta.y;

        torso.transform.localEulerAngles = (torso.transform.localEulerAngles + new Vector3(0, mouseX, mouseY) * sensivity);
        body.transform.localEulerAngles = (body.transform.localEulerAngles + new Vector3(0, mouseX, 0) * sensivity);

    }
}