using UnityEngine;

public class Target : MonoBehaviour
{

    public GameObject targetFix;
    public GameObject targetBreak;

    private GameObject currentTarget;

    float counter = 0;
    float maxCounter = 3;

    float counterMovement = 0;
    float maxCounterMovement = 3;

    bool broken = false;

    // Puntuación
    public PointsManager manager;

    public int pointsToAdd = 0;

    //Movimiento
    public float moveSpeed = 0f;

    bool movingLeft = false;

    public bool canMove = false;


    // Start
    void Start()
    {
        Respawn();
    }

    // Update
    void Update()
    {
        // Destruir
        if (broken)
        {
            counter += Time.deltaTime;
            if (counter >= maxCounter)
            {
                Respawn();
                broken = false;
                counter = 0;
            }
        }

        // Movimiento
        if (canMove)
        {
            if (movingLeft)
            {
                counterMovement += Time.deltaTime;
                MoveRight();

                if (counterMovement >= maxCounterMovement)
                {
                    movingLeft = false;
                    counterMovement = 0;
                }
            }
            else
            {
                counterMovement += Time.deltaTime;
                MoveLeft();

                if (counterMovement >= maxCounterMovement)
                {
                    movingLeft = true;
                    counterMovement = 0;
                }
            }
        }

        // Mover las instancias junto con el padre
        currentTarget.transform.position = transform.position;
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


    // Lo que pasa al ser chocado
    void ShootedAt()
    {
        if (!broken)
        {
            if (currentTarget != null)
            {
                Destroy(currentTarget);
            }

            Debug.Log("Destroyed");
            currentTarget = Instantiate(targetBreak, transform.position + transform.forward * 0, transform.rotation);
            broken = true;
            counter = 0;
            manager.points += pointsToAdd;
        }
    }


    // Volver a aparecer
    void Respawn()
    {
        if (currentTarget != null)
        {
            Destroy(currentTarget);
        }

        currentTarget = Instantiate(targetFix, transform.position + transform.forward * 0, transform.rotation);

        broken = false;
        counter = 0f;
    }


    // Detectar colisión
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            ShootedAt();
        }
    }
}
