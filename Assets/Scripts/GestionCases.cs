using UnityEngine;

public class GestionCases : MonoBehaviour
{
    Rigidbody2D rb;

    public int nombre;

    public void DetecterCase()
    {
        Debug.Log("Je suis arrivé à la case " + nombre);
    }



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

   
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
}
