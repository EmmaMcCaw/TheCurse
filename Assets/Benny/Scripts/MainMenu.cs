using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainMenu : MonoBehaviour
{
	public GameObject textt;

	private float flashTimer;
	private float flashTimerMAX = 0.4f;

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Return))
		{
			// next scene
		}


		flashTimer += 1 * Time.deltaTime;
		if (flashTimer > flashTimerMAX)
		{
			flashTimer = 0;
			textt.GetComponent<TextMeshProUGUI>().enabled = !textt.GetComponent<TextMeshProUGUI>().enabled;
		}
	}
}
