using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 사용자가 터치를 하면 증강현실에 그림을 그리고싶다.
public class Draw : MonoBehaviour
{
	public static Draw instance;
	private void Awake()
	{
		instance = this;
	}
	public GameObject spacePenPoint;
	public GameObject surfacePenPoint;
	public GameObject stroke;
	public Slider[] colorSliders;
	public Slider brushSlider;
	public bool mouseLookTesting;

	public static bool drawing = false;

	[HideInInspector]
	public Transform penPoint;

	float h = 0;
	float v = 0;
	Color colorFromUI;
	// Update is called once per frame
	void Update()
	{
		colorFromUI = new Color(colorSliders[0].value * 5, colorSliders[1].value * 5, colorSliders[2].value * 5);
		if (mouseLookTesting)
		{
			h += 2 * Input.GetAxis("Mouse X");
			v -= 2 * Input.GetAxis("Mouse Y");

			transform.eulerAngles = new Vector3(h, v, 0);
		}
		if (PenManager.drawingOnSurface)
		{
			EnableSurfacePenPoint();
		}
		else
		{
			Enable3DSpacePenPoint();
		}
	}

	private void Enable3DSpacePenPoint()
	{
		penPoint = spacePenPoint.transform;

		surfacePenPoint.GetComponentInChildren<MeshRenderer>().enabled = false;
		spacePenPoint.GetComponentInChildren<MeshRenderer>().enabled = true;
		spacePenPoint.GetComponentInChildren<Renderer>().material.color = colorFromUI;
	}

	private void EnableSurfacePenPoint()
	{
		penPoint = surfacePenPoint.transform;

		surfacePenPoint.GetComponentInChildren<MeshRenderer>().enabled = true;
		spacePenPoint.GetComponentInChildren<MeshRenderer>().enabled = false;
		surfacePenPoint.GetComponentInChildren<Renderer>().material.color = colorFromUI;
	}

	public void StartPen()
	{
		GameObject currentPen;
		drawing = true;
		currentPen = Instantiate(stroke, penPoint.transform.position, penPoint.transform.rotation) as GameObject;
		currentPen.GetComponent<Stroke>().strokeColor = colorFromUI;
	}
	public void EndPen()
	{
		drawing = false;
	}
}
