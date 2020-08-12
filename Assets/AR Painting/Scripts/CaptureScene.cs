using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

// 캡쳐버튼을 눌렀을 때 카메라셔터소리가 나오게 하고싶다.
public class CaptureScene : MonoBehaviour
{
	public static CaptureScene instance;
	private void Awake()
	{
		instance = this;
	}
	public Image blinkImage;
	public Canvas option;
	string fileName = "PNG";
	string date = DateTime.Now.ToString("MM-dd-hh-mm");
	void Start()
	{
		blinkImage.enabled = false;
	}
	public void OnClickCaptureButton()
	{
#if Unity_Editor
		StartCoroutine("TakeScreenShot");
#else
		StartCoroutine("CaptureScreenMob");
#endif
	}

	IEnumerator TakeScreenShot()
	{
		yield return new WaitForEndOfFrame();
		option.enabled = false;

		yield return new WaitForEndOfFrame();

		string myFilename = "myScreenshot_" + date + ".png";
		string myDefaultLocation = Application.persistentDataPath;
		string subFolderName = "PNG";


		if (!System.IO.Directory.Exists(myDefaultLocation + "/" + subFolderName))
		{
			System.IO.Directory.CreateDirectory(myDefaultLocation + "/" + subFolderName);
		}

		ScreenCapture.CaptureScreenshot(myDefaultLocation + "/" + subFolderName + "/" + myFilename);

		option.enabled = true;

		blinkImage.enabled = true;
		yield return new WaitForSeconds(0.3f);
		blinkImage.enabled = false;
	}
	IEnumerator CaptureScreenMob()
	{
		yield return new WaitForEndOfFrame();
		option.enabled = false;

		yield return new WaitForEndOfFrame();

		Texture2D ss = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
		ss.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
		ss.Apply();

		print("" + NativeGallery.SaveImageToGallery(ss, fileName, "Screenshot_" + date + ".png"));
		ScreenCapture.CaptureScreenshot(fileName + "/" + ss + ".png");

		option.enabled = true;

		blinkImage.enabled = true;
		yield return new WaitForSeconds(0.3f);
		blinkImage.enabled = false;
	}
}
