using UnityEngine;

public class Whip : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Destroyable")
        {
            Destroy(other.gameObject);
        }

        if(other.gameObject.tag == "Enemy")
        {
            other.GetComponent<EnemyHealth>().HurtEnemy(1);
        }
    }
}
