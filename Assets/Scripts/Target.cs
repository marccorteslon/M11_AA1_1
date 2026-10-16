using UnityEngine;
using TMPro;

public class Target : MonoBehaviour
{

    public GameObject targetFix;
    public GameObject targetBreak;

    public TextMeshProUGUI texto;

    float counter = 0;
    float maxCounter = 3;

    int points = 0;

    bool broken = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Respawn();
    }

    // Update is called once per frame
    void Update()
    {
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
        Debug.Log(counter);

        texto.text = points.ToString();
    }

    void ShootedAt()
    {
        if (!broken)
        {
            Debug.Log("Destroyed");
            GameObject instance = Instantiate(targetBreak, transform.position + transform.forward * 0, transform.rotation);
            Destroy(targetFix);
            broken = true;
            points += 100;
        }
    }

    void Respawn()
    {
        Destroy(targetBreak);
        GameObject instance = Instantiate(targetFix, transform.position + transform.forward * 0, transform.rotation);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            ShootedAt();
        }
    }
}
