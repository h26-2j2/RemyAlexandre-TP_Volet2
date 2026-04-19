using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class SuivreLaSouris : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer[] sprites;
    Animator anim;

    public float vitesseDeplacement; // 1f
    float directionX;
    bool enDeplacementX;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprites = GetComponentsInChildren<SpriteRenderer>();
        anim = GetComponentInChildren<Animator>();
    }


    void Update()
    {
        if (Mouse.current.leftButton.isPressed) // Tant que le CLIC gauche reste APPUYÉ
        {
            float zoneMorte = 1f; // Zone ajustable autour du centre du sujet, pour essayer d'éviter les alternations trop rapides gauches-droites si la souris clique près de celui-ci

            Vector2 PosSouris = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            float diffX = PosSouris.x - transform.position.x; // Différence positive ou négative

            if (Mathf.Abs(diffX) > zoneMorte) // La direction (gauche ou droite) est obtenue seulement si la différence est assez grande, donc si le clic est assez éloigné du centre du sujet
            {
                if (diffX > 0) //Clic à droite 
                {
                    directionX = 1; //Direction du sujet vers la droite
                }
                else if (diffX < 0) //Clic à gauche
                {
                    directionX = -1; //Direction du sujet vers la gauche
                }
            }

            enDeplacementX = true;
        }
        else
        {
            enDeplacementX = false;
        }


        foreach (SpriteRenderer sr in sprites) // Pour tous les sprites enfants
        {
            if (directionX < 0)
            {
                sr.flipX = true;
            }
            else if (directionX > 0)
            {
                sr.flipX = false;
            }
        }
    }

    void FixedUpdate()
    {
        Vector2 vel = rb.linearVelocity; // Pour manipuler le .x comme vecteur

        if (enDeplacementX)
        {
            vel.x = directionX * vitesseDeplacement; // De la vitesse dans la directionX de la souris
        }
        else
        {
            vel.x = 0f;
        }

        rb.linearVelocity = vel; // Ligne obligatoire, pour appliquer les changements au Rigidbody
    }
}
