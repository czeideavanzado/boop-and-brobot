using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowUI : MonoBehaviour {

	public void Show(bool showUI)
	{
		this.gameObject.SetActive(showUI);
	}
}
