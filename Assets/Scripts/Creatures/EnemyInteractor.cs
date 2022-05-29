using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInteractor : MonoBehaviour
{
	[SerializeField] private Enemy enemy;

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.TryGetComponent(out IDamageable damageable))
		{
			enemy.canMove = false;
			enemy.Attack(damageable);
		}
	}

	private void OnTriggerExit(Collider other)
	{
		//enemy.ChangeState(Enemy.EnemyState.follow);
		enemy.canMove = true;
	}


	//[SerializeField] private Enemy enemy;

	//[SerializeField] private float attackTime;

	//private bool ishitting;

	//protected override void Update()
	//{
	//	base.Update();
	//	Debug.Log(ishitting);
	//}

	//protected override void Interact(GameObject hit)
	//{
	//	base.Interact(hit);
	//	ishitting = true;
	//	StartCoroutine(AttackTimer(hit));
	//}

	//IEnumerator AttackTimer(GameObject hit)
	//{
	//	if (hit.TryGetComponent(out IDamageable damageable))
	//	{
	//		enemy.Attack(damageable);
	//	}
	//	ishitting = false;
	//	yield return Helpers.GetWait(attackTime);
	//}
}
