using UnityEngine;

public class CensorBehaviour : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {


        if(other.CompareTag("platform"))
        {
            GetComponentInParent<playerMovement>().grounded = true;
        }
        
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        
        if(other.CompareTag("platform"))
        {

           
            GetComponentInParent<playerMovement>().grounded = false;
            
        }

    }
}
