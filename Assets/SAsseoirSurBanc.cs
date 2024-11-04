using UnityEngine;

public class SAsseoirSurBanc : MonoBehaviour
{
    public Transform banc;
    public float speed = 2f;
    public float distanceToBanc = 1f;
    private bool isSitting = false;

    void Update()
    {
        // Si le personnage n'est pas encore assis, se diriger vers le banc
        if (!isSitting)
        {
            Vector3 direction = (banc.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;

            // Rotation vers le banc
            Quaternion toRotation = Quaternion.LookRotation(direction, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, 360 * Time.deltaTime);

            // Vérifie si proche du banc
            if (Vector3.Distance(transform.position, banc.position) <= distanceToBanc)
            {
                isSitting = true;
                SAsseoir();
            }
        }
    }

    void SAsseoir()
    {
        // Simule l'action de s'asseoir (peut inclure une animation si disponible)
        transform.position = banc.position; // Positionnement sur le banc
        Debug.Log("Personne assise sur le banc.");
    }
}

