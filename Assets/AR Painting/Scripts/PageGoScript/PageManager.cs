using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.TerrainAPI;
using UnityEngine.SceneManagement;

// painting 버튼을 누르면 painting 화면으로 넘어가고 gallery버튼을 누르면 Save파일 화면으로 넘어가게하고싶다.
public class PageManager : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
            
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // paint버튼
    // Painting 씬으로 넘어가자
    public void OnClickPageGo()
	{
        print("그림을 그리자");
        SceneManager.LoadScene(1);
	}
    // gallery버튼
    // Gallery 씬으로 넘어가자
    public void OnClickPageSave()
	{
        print("그림 저장");
        SceneManager.LoadScene(2);
	}
}
