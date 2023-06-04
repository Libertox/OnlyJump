using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OnlyJump.UI;

public class LoadGame : MonoBehaviour
{
    [SerializeField] private GameObject gameManager;
    [SerializeField] private FadeImage fadeImage;
    [SerializeField] private float waitTime;

    private void Start() => StartCoroutine(Loading());
   
    private IEnumerator Loading()
    {
        yield return new WaitForSeconds(waitTime);
        if(!GameManager.Instance)
            Instantiate(gameManager);

        fadeImage.FadeFromBlack();
        LoaderScene.LoadScene(Scence.MainMenu);
    }
}
