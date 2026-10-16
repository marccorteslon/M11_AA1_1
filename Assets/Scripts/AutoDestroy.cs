using UnityEngine;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class AutoDestroy : MonoBehaviour
{

    // Este script es para que las balas y dianas no se queden infinitamente en escena

    float counter = 0;
    float maxCounter = 3;


    // Update is called once per frame
    void Update()
    {
        counter += Time.deltaTime;
        if (counter >= maxCounter)
        {
            Destroy(gameObject);
            counter = 0;
        }
    }
}
