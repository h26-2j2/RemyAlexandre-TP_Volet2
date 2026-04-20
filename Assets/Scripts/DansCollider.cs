using UnityEngine;

public class DansCollider : MonoBehaviour
{
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collision) // En RENTRANT dans le collider trigger 
    {
        CaseScript caseScript = collision.GetComponent<CaseScript>(); // Référence au script CaseScript

        if (caseScript != null)
        {
            caseScript.ActiverCase(); // Déclenchement de la fonction du script CaseScript
        }
    }

    void OnTriggerExit2D(Collider2D collision) // En SORTANT du collider trigger
    {
        CaseScript caseScript = collision.GetComponent<CaseScript>();

        if (caseScript != null)
        {
            caseScript.DesactiverCase();
        }
    }
}
