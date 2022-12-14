using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MainMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public LoadingScreen loadingScreen;
    public GameObject SettingMenuUI;
    [Header("Button Event System")]
    [SerializeField] GameObject firstButton;

    [Header("Scene and Quest Info Data")]
    [SerializeField] SceneInfo sceneInfo;
    [SerializeField] SceneInfo initialSceneInfo;
    [SerializeField] QuestData questData;
    [SerializeField] QuestData initialQuestData;
    
    private void Start() {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(firstButton);
    }
    public void PlayGame()
    {
        ResetSceneInfoData();
        loadingScreen.gameObject.SetActive(true);
        Time.timeScale = 1f;
        loadingScreen.LoadScene("Home");
    }

    public void SettingGame()
    {
        SettingMenuUI.SetActive(true);
        Time.timeScale = 1f;
        GameIsPaused = true;
        this.gameObject.SetActive(false);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    private void OnEnable() {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(firstButton);
    }

    public void ResetSceneInfoData(){
        sceneInfo.items.Clear();// = new Dictionary<string, CollectibleItem>();
        sceneInfo.itemInButtons.Clear(); // = new Dictionary<string, ItemButton>();
        sceneInfo.itemNameInInventory.Clear(); // = null;

        sceneInfo.gameTime = initialSceneInfo.gameTime;
        sceneInfo.money = initialSceneInfo.money;
        sceneInfo.dayTime = initialSceneInfo.dayTime;
        sceneInfo.timeScale = initialSceneInfo.timeScale;
        sceneInfo.playerStamina = initialSceneInfo.playerStamina;
        sceneInfo.isRain = initialSceneInfo.isRain;
        sceneInfo.lifePoint = initialSceneInfo.lifePoint;
        sceneInfo.isOpenMessage = initialSceneInfo.isOpenMessage;
        
        foreach (Quest quest in questData.quests){
            quest.amountGiven = 0;
            quest.completed = false;
            quest.notCompleted = false;
        }
    }
}
