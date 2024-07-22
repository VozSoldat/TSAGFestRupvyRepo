
using UnityEngine;

public class ExitPress : MonoBehaviour
{
    public void startExit()
    {
        Application.Quit();
        // if (UnityEditor.EditorApplication.isPlaying)
        // {
        //     UnityEditor.EditorApplication.isPlaying = false;
        // }
    }
}
