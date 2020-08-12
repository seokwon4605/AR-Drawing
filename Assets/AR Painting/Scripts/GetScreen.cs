using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Security.AccessControl;
using UnityEngine;

public class GetScreen : MonoBehaviour
{
#if !Unity_Editor
	private static AndroidJavaClass m_ajc = null;
	private static AndroidJavaClass AJC
	{
		get
		{
			if (m_ajc == null)
			{
				m_ajc = new AndroidJavaClass("com.CQRE.ARPainting");
			}
			return m_ajc;

		}
	}
#endif
	public static string GetLastScreenshotPath()
	{
		string saveDir;
#if !Unity_Editor && Unity_Android
		saveDir = AJC.CallStatic<string>("GetMediaPath", "Shine Bright");
#else
		saveDir = Application.persistentDataPath;
#endif
		string[] files = Directory.GetFiles(saveDir, ".png");
		if(files.Length > 0)
		{
			return files[files.Length - 1];
		}
		return null;
	}
}
