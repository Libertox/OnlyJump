using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoaderScene
{
    public static void LoadScene(Scence target) => SceneManager.LoadScene(target.ToString());

    public static void LoadTheSameScene() => SceneManager.LoadScene(SceneManager.GetActiveScene().name);

}
public enum Scence
{
    MainMenu,
    Level_1,
    Level_2,
    Level_3,
    RecordMode
}