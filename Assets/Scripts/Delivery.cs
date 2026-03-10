using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{

[SerializeField] Color32 hasPackageColor = new Color32 (1,1,1,1);
[SerializeField] Color32 noPackageColor = new Color32 (1,1,1,1);
bool hasPackage;
SpriteRenderer SpriteRenderer;
float destroyDelay = 0.5f;
void Start() {
    SpriteRenderer = GetComponent<SpriteRenderer>();    
}
//void OnCollisionEnter2D(Collision2D other) {
//    Debug.Log("Ouch!");
//}
void OnTriggerEnter2D(Collider2D other) {
    if (other.tag == "Package" && !hasPackage)
    {
        Debug.Log("Package picked up");
        hasPackage = true;
        SpriteRenderer.color = hasPackageColor;
        Destroy(other.gameObject, destroyDelay);
    }
    if (other.tag == "Customer" && hasPackage)
    {
        Debug.Log("Package delivered");
        hasPackage = false;
        SpriteRenderer.color = noPackageColor;
    }
}
}
