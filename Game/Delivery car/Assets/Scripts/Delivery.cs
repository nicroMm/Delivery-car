using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] float delayToDestroy = 0f;
    [SerializeField] Color32 hasPackageColour = new Color32 (1,1,1,1);
    [SerializeField] Color32 noPackageColour = new Color32 (1,1,1,1);

    bool hasPackage;
    SpriteRenderer spriteRenderer;
    private void Start() 
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("You hit something !");    
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Package1" && !hasPackage)
        {
            Destroy(other.gameObject, delayToDestroy);
            Debug.Log("You picked up the package!");
            hasPackage = true;
            spriteRenderer.color = hasPackageColour;
        }
        else if (other.tag == "Customer1" && hasPackage)
        {
            Debug.Log("You deliver the package! Thanks!");
            hasPackage = false;
            Destroy(other.gameObject, delayToDestroy);
            spriteRenderer.color = noPackageColour;
        }
        
    }
}
  
