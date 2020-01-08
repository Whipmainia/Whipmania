using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Whip : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
