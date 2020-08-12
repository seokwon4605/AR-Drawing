using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class PickUpScreenshot : MonoBehaviour
{
    CaptureScene cs;
    public Image pickUpImage;

	public void OnClickPickUp()
	{
		PickUpAndShowit();
	}

    void PickUpAndShowit()
	{
		print("사진 불러오기");
        string pathToFile = GetScreen.GetLastScreenshotPath();
        if(pathToFile == null)
		{
            return;
		}
		Texture2D texture = GetScreenshotImage(pathToFile);
		Sprite sp = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
		pickUpImage.enabled = true;
		pickUpImage.GetComponent<Image>().sprite = sp;
	}

	Texture2D GetScreenshotImage(string filePath)
	{
		Texture2D texture = null;
		byte[] fileBytes;
		if (File.Exists(filePath))
		{
			fileBytes = File.ReadAllBytes(filePath);
			texture = new Texture2D(2, 2, TextureFormat.RGB24, false);
			texture.LoadImage(fileBytes);
		}
		return texture;
	}
}
