using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PenManager : MonoBehaviour
{
    public static bool drawingOnSurface = false;

    public void DrawOnSurface()
	{
		drawingOnSurface = true;
	}
	public void DrawOnSpace()
	{
		drawingOnSurface = false;
	}
	public void OnClickRemoveAll()
	{
		SceneManager.LoadScene(1);
	}
}
