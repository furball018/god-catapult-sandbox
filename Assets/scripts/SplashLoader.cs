using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SplashLoader : MonoBehaviour {
    public int levelIndexToLoad;

	IEnumerator Start () {
        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene(levelIndexToLoad);
	}
}
