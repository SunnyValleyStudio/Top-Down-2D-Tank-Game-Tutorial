using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public SaveSystem saveSystem;

    private void Awake()
    {
        SceneManager.sceneLoaded += Initialize;
        DontDestroyOnLoad(gameObject);
    }

    private void Initialize(Scene scene, LoadSceneMode sceneMode)
    {
        Debug.Log("Loaded GM");
        var playerInput = FindObjectOfType<PlayerInput>();
        if (playerInput != null)
            player = playerInput.gameObject;
        saveSystem = FindObjectOfType<SaveSystem>();
        if (player != null && saveSystem.LoadedData != null)
        {
            var damagable = player.GetComponentInChildren<Damagable>();
            damagable.Health = saveSystem.LoadedData.playerHealth;
        }
    }

    public void LoadLeve()
    {
        if (saveSystem.LoadedData != null)
        {
            SceneManager.LoadScene(saveSystem.LoadedData.sceneIndex);
            return;
        }
        LoadNextLevel();
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void SaveData()
    {
        if (player != null)
            saveSystem.SaveData(SceneManager.GetActiveScene().buildIndex + 1, player.GetComponentInChildren<Damagable>().Health);
    }
}
