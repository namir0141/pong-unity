using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour {

	public void Play_Button(int id)
	{
		SceneManager.LoadScene(id);
	}
}
