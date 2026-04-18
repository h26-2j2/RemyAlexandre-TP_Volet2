using UnityEngine;

public class CaseScript : MonoBehaviour
{
    public SpriteRenderer chiffre0; // Premier chiffre par l'inspecteur
    public SpriteRenderer chiffre00; // Deuxième chiffre, s'il y en a un
    public SpriteRenderer globe;
    Animator anim;
    public int nombre;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {

    }

    public void ActiverCase()
    {


        Debug.Log("J'ai atteint la case " + nombre);
    }

    public void DesactiverCase()
    {

    }
}
