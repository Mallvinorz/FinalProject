using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Scene Info", menuName = "FarmSim/SceneInfo", order = 0)]
public class SceneInfo : ScriptableObject {
    [SerializeField] public Dictionary<string, Vector3> listLastPostOfScene = new Dictionary<string, Vector3>();
    // Inventory datas
    [SerializeField] public Dictionary<string, CollectibleItem> items = new Dictionary<string, CollectibleItem>();
    [SerializeField] public Dictionary<string, ItemButton> itemInButtons = new Dictionary<string, ItemButton>();//items that will display in HUD game
    [SerializeField] public List<string> itemNameInInventory;//to keep tract every item name in inventory
    [SerializeField] public int gameTime;
    [SerializeField] public int money;
    [SerializeField] public float dayTime;
    [SerializeField] public int timeScale;
    [Range(0, 100)]
    [SerializeField] public float playerStamina = 100;
    [SerializeField] public bool isRain = false;
    
    [Range(0, 5)]
    [SerializeField] public int lifePoint;
    [SerializeField] public bool isOpenMessage;
  
    public void SetCurrentSceneData(string sceneName, Vector3 lastPos, Dictionary<string, CollectibleItem> items,  Dictionary<string, ItemButton> itemInButtons, List<string> itemNameInInventory){

        if(this.CheckThereLastPosScene(sceneName)){
            listLastPostOfScene[sceneName] = lastPos;//update last
        }else{
            listLastPostOfScene.Add(sceneName, lastPos);
        }
        //inventory data
        this.itemNameInInventory = itemNameInInventory;
        foreach (string name in itemNameInInventory)
        {
            this.items.Add(name, items[name].Clone());
            this.itemInButtons.Add(name, itemInButtons[name].Clone());
        }
    }

    private bool CheckThereLastPosScene(string sceneName){
        bool status = items.ContainsKey(sceneName)? true : false;
        return status;
    }

    public void SetDayTime(float time){
        this.dayTime = time;
    }
    public void SetGameTime(int time){
        this.gameTime = time;
    }

    private void ResetData(){
        this.items = null;
        this.itemInButtons = null;
        this.itemNameInInventory = null;
        this.listLastPostOfScene = null;
    }
}