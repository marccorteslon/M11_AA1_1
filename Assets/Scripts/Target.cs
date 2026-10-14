using UnityEngine;

public class Target : MonoBehaviour
{

    public GameObject targetFix;
    public GameObject targetBreak;

    float counter = 0;
    float maxCounter = 3;

    bool broken = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

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
                counter = 3;
            }
        }
    }

    void ShootedAt()
    {
        Debug.Log("Destroyed");
        GameObject instance = Instantiate(targetBreak, transform.position + transform.forward * 0, transform.rotation);
        Destroy(targetFix);
        broken = true;
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
