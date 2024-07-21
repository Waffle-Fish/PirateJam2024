
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Unity.VisualScripting;

public class EnemyHeath : MonoBehaviour
{
 [SerializeField]
private int health = 100;
private int CurrentHealth;
private itemdrop getItem;

    // Start is called before the first frame update
    void Start()
    {
        CurrentHealth = health;
        
        getItem = GetComponent<itemdrop>();
    }

   private void OnCollisionEnter(Collision other)
   {
    if (other.gameObject.CompareTag ("player"))
    {
        TakeDamage(20);
    }
    void TakeDamage (int damage)
    {
        CurrentHealth -= damage;
       
    }

    {    if (getItem != null)
                {
                    getItem.DropItem();
                    Debug.Log("Dropped an Item " + getItem);
                }
                Destroy(gameObject);
    }
   }
   
}