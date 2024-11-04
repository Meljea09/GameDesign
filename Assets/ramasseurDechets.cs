using UnityEngine;

public class RamasseurDeDechets : MonoBehaviour
{
    public float speed = 5f;           // Vitesse de déplacement du personnage
    public LayerMask trashCanLayer;     // Layer des poubelles pour la détection

    void Update()
    {
        DeplacerPersonnage();
    }

    // Fonction pour déplacer le personnage principal
    void DeplacerPersonnage()
    {
        // Récupérer les entrées de l’utilisateur
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Calculer le vecteur de mouvement
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        
        // Déplacer le personnage selon la direction et la vitesse
        transform.position += movement * speed * Time.deltaTime;

        // Tourner le personnage dans la direction du mouvement
        if (movement != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movement, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, 360 * Time.deltaTime);
        }
    }

    // Fonction appelée lorsqu'on entre en collision avec un objet "Trigger"
    private void OnTriggerEnter(Collider other)
    {
        // Vérifie si l’objet en collision est dans la layer "TrashCan"
        if (((1 << other.gameObject.layer) & trashCanLayer) != 0)
        {
            Debug.Log("Trash can detected! Checking for trash...");
            // Ici, vous pouvez ajouter le code pour ramasser les déchets ou d'autres interactions
        }
    }
}

