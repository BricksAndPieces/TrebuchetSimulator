using UnityEngine;
using UnityEngine.SceneManagement;

public class SimulationManager : MonoBehaviour {

    public Camera[] cams;
    public GameObject restartUI;

    private void Awake() {
        Time.timeScale = 0;
    }

    public void Play() {
        Time.timeScale = 1;
        GameObject.Find("Menu").SetActive(false);
    }

    public void SetCamera(int index) {
        foreach(Camera c in cams) {
            c.gameObject.SetActive(false);
        }

        cams[index].gameObject.SetActive(true);
    }

    public void Restart() {
        Invoke("RestartDelay", 5);
    }

    private  void RestartDelay() {
        restartUI.SetActive(true);
    }

    public void ReloadScene() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}