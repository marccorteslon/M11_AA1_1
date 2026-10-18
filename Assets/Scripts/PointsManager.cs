using UnityEngine;
using TMPro;

public class PointsManager : MonoBehaviour
{

    public TextMeshProUGUI texto;

    public int points = 0;

    // Update is called once per frame
    void Update()
    {
        texto.text = points.ToString();
    }
}
