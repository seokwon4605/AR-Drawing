using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stroke : MonoBehaviour
{
	Transform penPoint;
	public Color strokeColor;
	TrailRenderer tr;
	Slider brushSize;
	// Start is called before the first frame update
	void Start()
	{
		tr = GetComponent<TrailRenderer>();
		penPoint = GameObject.FindObjectOfType<Draw>().penPoint;
		brushSize = Draw.instance.brushSlider;
	}

	// Update is called once per frame
	void Update()
	{
		if (penPoint == null)
			penPoint = GameObject.FindObjectOfType<Draw>().penPoint;

		tr.material.color = strokeColor;
		tr.startWidth = brushSize.value;
		tr.endWidth = brushSize.value;
		if (Draw.drawing && penPoint != null)
		{
			transform.position = penPoint.transform.position;
			transform.rotation = penPoint.transform.rotation;
		}
		else
		{
			enabled = false;
		}
	}
}
