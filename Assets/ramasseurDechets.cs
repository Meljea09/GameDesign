using UnityEngine;

public class RamasseurDeDechets : MonoBehaviour
{
    public float speed = 5f;

    void Update()
    {
        // Déplacement du personnage
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        transform.position += movement * speed * Time.deltaTime;

        // Optionnel : Rotation vers la direction de mouvement
        if (movement != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movement, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, 360 * Time.deltaTime);
        }
    }
}

