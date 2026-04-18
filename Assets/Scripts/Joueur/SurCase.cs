using UnityEngine;

public class SurCase : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
    }


    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        CaseScript caseScript = collision.GetComponent<CaseScript>(); // Référence au components qui possèdent le script CaseScript

        if (caseScript != null)
        {
            caseScript.ActiverCase(); // Déclenchement de la fonction de l'autre script
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        CaseScript caseScript = collision.GetComponent<CaseScript>();

        if (caseScript != null)
        {
            caseScript.DesactiverCase();
        }
    }
}
