using UnityEngine;

public class Spinning : MonoBehaviour
{
    [Header("Paramètres de vitesse")]
    public float rotationSpeed = 50f;
    public float speedChangeRate = 50f; // vitesse à laquelle la vitesse augmente ou diminue

    // 1 = tourne vers la droite, -1 = tourne vers la gauche
    private float direction = 1f;

    void Update()
    {
        // 1. Touche 'A' : accélère la rotation
        if (Input.GetKey(KeyCode.Q))
        {
            rotationSpeed += speedChangeRate * Time.deltaTime;
        }

        // 2. Touche 'E' : ralentit la rotation (sans descendre sous 0)
        if (Input.GetKey(KeyCode.E))
        {
            rotationSpeed = Mathf.Max(0f, rotationSpeed - (speedChangeRate * Time.deltaTime));
        }

        // 3. Touche 'Espace' : inverse le sens de rotation
        if (Input.GetKeyDown(KeyCode.Space))
        {
            direction = -direction;
        }

        // 4. Applique la rotation
        transform.Rotate(Vector3.up * (rotationSpeed * direction * Time.deltaTime));
    }
}