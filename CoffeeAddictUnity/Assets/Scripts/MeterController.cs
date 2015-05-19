using UnityEngine;
using System.Collections;

public class MeterController : MonoBehaviour {

	public RectTransform VisibleMeter;

	public void MoveMeter(int meter)
	{
		if(meter > 0)
		{
			float percentage = (float)meter/100f;

			float pos = (VisibleMeter.rect.width * (1f - percentage));

			VisibleMeter.transform.localPosition = new Vector3(-pos, VisibleMeter.localPosition.y, VisibleMeter.localPosition.z);
		}
	}
}
