using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CountdownToPlay : MonoBehaviour
{
	public GameObject Countdown; // text(number) GameObject

	public int sumTime;

	public GameObject next;

	void Start()
	{
		StartCoroutine("countDown");
	}

	public IEnumerator countDown()
	{
		while (sumTime >= 0)
		{
			if (sumTime > 0)
			{
				Countdown.GetComponent<Text>().text = sumTime.ToString();
				yield return new WaitForSeconds(1); // 1 second for real world
				sumTime--;
			}
			else if (sumTime == 0)
			{
				next.SetActive(true);
				yield break;
			}
		}
	}
}