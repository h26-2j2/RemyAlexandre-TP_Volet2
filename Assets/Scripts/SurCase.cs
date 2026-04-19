using UnityEngine;

public class SurCase : MonoBehaviour
{
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collision) // En RENTRANT dans le collider de la case
    {
        CaseScript caseScript = collision.GetComponent<CaseScript>(); // Référence au script CaseScript

        if (caseScript != null)
        {
            caseScript.ActiverCase(); // Déclenchement de la fonction de l'autre script
        }
    }

    void OnTriggerExit2D(Collider2D collision) // En SORTANT du collider de la case
    {
        CaseScript caseScript = collision.GetComponent<CaseScript>();

        if (caseScript != null)
        {
            caseScript.DesactiverCase();
        }
    }
}
