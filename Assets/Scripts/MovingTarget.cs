using UnityEngine;
using TMPro;

public class MovingTarget : MonoBehaviour
{

    public Target target;

    float counter = 0;
    float maxCounter = 3;

    int points = 0;

    public int pointsToAdd = 0;

    public float moveSpeed = 0f;

    bool movingLeft = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        if (movingLeft)
        {
            counter += Time.deltaTime;
            MoveRight();

            if (counter >= maxCounter)
            {
                movingLeft = false;
                counter = 0;
            }
        } else
        {
            counter += Time.deltaTime;
            MoveLeft();

            if (counter >= maxCounter)
            {
                movingLeft = true;
                counter = 0;
            }
        }

    }

    // Funciones para movier a la izquierda y a la derecha
    void MoveRight()
    {
        transform.position += new Vector3(0f, 0f, moveSpeed * Time.deltaTime);
    }

    void MoveLeft()
    {
        transform.position += new Vector3(0f, 0f, -moveSpeed * Time.deltaTime);
    }


    void ShootedAt()
    {
        Debug.Log("Bad target");
        target.points += pointsToAdd;
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            ShootedAt();
        }
    }
}
