using UnityEngine;

public class CameraSuiveuse : MonoBehaviour
{
    public Transform personnagePrincipal;  // Référence au personnage principal
    public Vector3 offset = new Vector3(0, 5, -7);  // Position de décalage de la caméra
    public float smoothSpeed = 0.125f;  // Vitesse de suivi pour des mouvements plus fluides

    void LateUpdate()
    {
        if (personnagePrincipal != null)
        {
            // Position souhaitée de la caméra (position du personnage + décalage)
            Vector3 positionDesiree = personnagePrincipal.position + offset;
            
            // Applique un lissage pour des mouvements de caméra plus fluides
            Vector3 positionLisse = Vector3.Lerp(transform.position, positionDesiree, smoothSpeed);
            
            // Mettre à jour la position de la caméra
            transform.position = positionLisse;

            // Regarder vers le personnage principal
            transform.LookAt(personnagePrincipal);
        }
    }
}

