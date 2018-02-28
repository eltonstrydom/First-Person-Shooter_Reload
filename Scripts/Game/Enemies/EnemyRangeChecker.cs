using UnityEngine;

public class EnemyRangeChecker: MonoBehaviour  {

	bool isInRange;

	void OnEnable()
	{
		isInRange = false;
	}



	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player")
			isInRange = true;
	}
	void OnTriggerExit(Collider other)
	{if (other.gameObject.tag == "Player")
		isInRange = false;
	}

	public  bool MeleeCheckRange()
	{
		return isInRange;
	}



}
