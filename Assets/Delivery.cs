using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] Color32 hasPackageColor = new Color32 (1, 1, 1, 1);
    [SerializeField] Color32 noPackageColor = new Color32 (1, 1, 1, 1);
    [SerializeField] float destroyDelay = 0.5f;
    bool hasPackage = false;

    SpriteRenderer spriteRenderer;

    private void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        // Collision2D other - is the other object that we bumped into
        Debug.Log("Oops! I bumped into something!");
    }

    void OnTriggerEnter2D(Collider2D other) {
        
        // Debug.Log("Wow! I passed a Trigger!");
        
        // if (the thing we trigger is the package)
        // {
        //      then print "package picked up" to the console;
        // }

        if (other.tag == "Package" && !hasPackage)
        {
            Debug.Log("Package picked up");
            hasPackage = true;
            Destroy(other.gameObject, destroyDelay);
            spriteRenderer.color = hasPackageColor;
        }
        if (other.tag == "Customer" && hasPackage)
        {
            Debug.Log("Delivered package");
            hasPackage = false;
            spriteRenderer.color = noPackageColor;
        }
    }
}
