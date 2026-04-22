using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class HoverBoutons : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    // Ce que j'veux afficher au :hover et :active
    public GameObject visuelHover;
    public GameObject visuelActive;

    public Animator anim; // Par l'inspecteur, je glisse l'enfant qui a l'Animator

    AudioSource audioSource;
    public AudioClip vocalHover;
    public AudioClip vocalActive;


    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        // Caché au lancement du jeu
        if (visuelHover != null)
        {
            visuelHover.SetActive(false);
        }
        if (visuelActive != null)
        {
            visuelActive.SetActive(false);
        }
    }

    // Quand la souris HOVER sur le collider du parent
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (visuelHover != null)
        {
            visuelHover.SetActive(true);
        }

        if (anim != null)
        {
            anim.SetBool("animHover", true);
        }

        if (audioSource != null && vocalHover != null)
        {
            audioSource.clip = vocalHover;
            audioSource.Play();
        }
    }

    // Quand la souris SORT du collider du parent
    public void OnPointerExit(PointerEventData eventData)
    {
        if (visuelHover != null)
        {
            visuelHover.SetActive(false);
        }

        if (anim != null)
        {
            anim.SetBool("animHover", false);
            anim.CrossFade("Désactivé", 0.05f); // Interruption immédiate, + fluide qu'une transition de retour dans l'animator
        }

        if (audioSource != null && audioSource.isPlaying)
        {
            if (SceneManager.GetActiveScene().name == "Selecteur de jeux")
            {
                audioSource.Stop(); // L'énoncé du titre a besoin d'arrêter sec, pas le reste
            }
        }
    }

    public void Update()
    {
        // Debug.Log(anim.GetBool("animHover"));
    }





    // Quand la souris CLIQUE dessus
    public void visuelClicSouris() // Que j'active grâce au Event Trigger du parent
    {
        if (visuelActive != null)
        {
            visuelActive.SetActive(true);
        }

        if (audioSource != null && vocalActive != null)
        {
            audioSource.clip = vocalActive;
            audioSource.Play();
        }
    }
}
