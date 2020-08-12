using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// 그린 그림을 저장하고 싶다.
public class SavePageGo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnClickPageSave()
	{
        print("그림을 저장하자");
		SceneManager.LoadScene(2);
	}
}
