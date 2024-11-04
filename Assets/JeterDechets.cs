using UnityEngine;

public class JeterDechets : MonoBehaviour
{
    public Transform poubelle;
    public float speed = 2f;
    public float distanceToPoubelle = 1f;
    private bool isThrowing = false;

    void Update()
    {
        // Si le personnage n'est pas encore à la poubelle, se diriger vers elle
        if (!isThrowing)
        {
            Vector3 direction = (poubelle.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;

            // Rotation vers la poubelle
            Quaternion toRotation = Quaternion.LookRotation(direction, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, 360 * Time.deltaTime);

            // Vérifie si proche de la poubelle
            if (Vector3.Distance(transform.position, poubelle.position) <= distanceToPoubelle)
            {
                isThrowing = true;
                StartCoroutine(JeterDechetRoutine());
            }
        }
    }

    private System.Collections.IEnumerator JeterDechetRoutine()
    {
        // Animation simulée de jeter le déchet
        yield return new WaitForSeconds(1f); // Temps d’attente pour "jeter"
        Debug.Log("Déchet jeté !");
        isThrowing = false; // Retour au comportement par défaut ou départ
    }
}

