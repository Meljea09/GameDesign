using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RamasseurDeDechets : MonoBehaviour
{
    public float moveSpeed = 3.0f;               // Vitesse de déplacement du personnage
    public float rotationSpeed = 100.0f;         // Vitesse de rotation du personnage
    public GameObject messagePanel;               // Panneau pour afficher les messages
    private TextMeshProUGUI messagePanelText;    // Texte à afficher sur le panneau
    private float messageDisplayTime = 5.0f;     // Durée d'affichage du message
    private float messageTimer = 0f;              // Chronomètre pour gérer l'affichage

    private Rigidbody rb;                         // Composant Rigidbody du personnage

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        // Récupère le panneau de message et son composant Text
        if (messagePanel != null)
        {
            messagePanelText = messagePanel.GetComponentInChildren<TextMeshProUGUI>();
            messagePanel.SetActive(false);  // Masque le panneau de message par défaut
        }
        else
        {
            Debug.LogError("MessagePanel non trouvé ! Assurez-vous de l'avoir ajouté dans le Canvas.");
        }
    }

    void Update()
    {
        // Déplacement du personnage avec les touches fléchées ou WASD
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;
        
        if (direction.magnitude >= 0.1f)
        {
            // Calcul de la direction et de la rotation
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.Euler(0, targetAngle, 0);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotationSpeed);
            
            // Déplacement en avant
            rb.MovePosition(transform.position + direction * moveSpeed * Time.deltaTime);
        }

        // Cache le panneau de message une fois le temps écoulé
        if (messagePanel.activeSelf && Time.time > messageTimer)
        {
            messagePanel.SetActive(false);
        }

        // Positionne le panneau de message au-dessus du personnage
	      if (messagePanel.activeSelf)
	{
	    Vector3 panelPosition = transform.position + new Vector3(0, 1.5f, 0); // Ajustez la hauteur si nécessaire
	    messagePanel.transform.position = panelPosition;
	}
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Affiche un message selon l'objet rencontré
        if (collision.gameObject.CompareTag("TrashCan"))
        {
            DisplayMessage("Collision avec une poubelle !");
        }
        else if (collision.gameObject.name.ToLower().Contains("bench"))
        {
            DisplayMessage("Collision avec un banc !");
        }
        else if (collision.gameObject.name.ToLower().Contains("fountain"))
        {
            DisplayMessage("Collision avec une fontaine !");
        }
        else
        {
            DisplayMessage("Collision avec un objet : " + collision.gameObject.name);
        }
    }

    // Méthode pour afficher un message dans l'UI
    private void DisplayMessage(string message)
    {
        if (messagePanelText != null)
        {
            messagePanelText.text = message; // Met à jour le texte du panneau
            messagePanel.SetActive(true); // Affiche le panneau
            messageTimer = Time.time + messageDisplayTime;  // Définit le temps d'affichage du message
        }
    }
}

