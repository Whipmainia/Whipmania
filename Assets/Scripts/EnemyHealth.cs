using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
	public int enemyHealth;
	void Update()
	{
		if (enemyHealth <= 0)
		{
			Destroy(gameObject);
		}
	}

	public void HurtEnemy(int damageToGive)
	{
		enemyHealth -= damageToGive;
	}
}
