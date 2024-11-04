using UnityEngine;

public class DeplacementAleatoire : MonoBehaviour
{
    public float speed = 2f;
    public float changeDirectionInterval = 3f;
    private Vector3 randomDirection;
    private float timer;

    void Start()
    {
        // Initialise la direction aléatoire
        ChangeDirection();
    }

    void Update()
    {
        // Déplacement dans la direction actuelle
        transform.position += randomDirection * speed * Time.deltaTime;
        timer += Time.deltaTime;

        // Changer de direction après un intervalle
        if (timer >= changeDirectionInterval)
        {
            ChangeDirection();
            timer = 0f;
        }
    }

    void ChangeDirection()
    {
        // Génère une direction aléatoire
        float randomX = Random.Range(-1f, 1f);
        float randomZ = Random.Range(-1f, 1f);
        randomDirection = new Vector3(randomX, 0f, randomZ).normalized;
    }
}

