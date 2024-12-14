using UnityEngine;

public class Shield : MonoBehaviour
{
    //Collisions
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Enemy"))
        {
            //Disable shield
            gameObject.SetActive(false);
        }
    }
}
