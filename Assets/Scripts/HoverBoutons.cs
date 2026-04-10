using UnityEngine;
using UnityEngine.EventSystems;

public class HoverBoutons : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    // Ce que j'veux afficher au :hover et :active
    public GameObject visuelHover; 
    public GameObject visuelActive; 

    void Start()
    {
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

    // Quand la souris entre sur le collider du parent
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (visuelHover != null)
        {
            visuelHover.SetActive(true);
        }
    }

    // Quand la souris sort du collider du parent
    public void OnPointerExit(PointerEventData eventData)
    {
        if (visuelHover != null)
        {
            visuelHover.SetActive(false);
        }
    }






    // Quand la souris clique dessus
    public void visuelClicSouris() // Que j'active grâce au Event Trigger du parent
    {
        if (visuelActive != null)
        {
            visuelActive.SetActive(true);
        }
    }
}
