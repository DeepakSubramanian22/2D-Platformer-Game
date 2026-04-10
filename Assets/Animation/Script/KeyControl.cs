using UnityEngine;

public class KeyControl : MonoBehaviour

{
 private void OnCollisionEnter2D(Collision2D collision){
     if (collision.gameObject.GetComponent<PlayerController>() != null)
     {
         PlayerController player = collision.gameObject.GetComponent<PlayerController>(); 
         player.PickKey();
         Destroy(gameObject);
     }
 }
}