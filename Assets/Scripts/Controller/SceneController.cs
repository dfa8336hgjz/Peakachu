using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void setScene(string sceneName)
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(sceneName);
    }

    public void changeBackgroundMusic(AudioClip clip)
    {
        AudioController audioController = AudioController.Instance;
        if (!audioController.IsMute())
        {
            audioController.StopBackgroundMusic();
            audioController.PlayBackgroundMusic(clip);
        }
    }

    public void changeMuteMode()
    {
        AudioController.Instance.changeVolumn();
    }

    public void quitGame()
    {

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
}
