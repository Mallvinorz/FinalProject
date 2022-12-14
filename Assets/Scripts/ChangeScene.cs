using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine.UI;
public class ChangeScene : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private string moveToSceneName;
    GameObject inventoryObj;
    Inventory inventory;
    private bool isOnArea = false;

    [SerializeField] private GameObject LoadingCanvas;
    [SerializeField] private Image progressBar;
    [SerializeField] private TextMesh enterText;
    [SerializeField] private string enterTextString;
    [SerializeField] private LoadingScreen loadingScreen;
    private GameObject[] plants;
    private List<Plants> plantsBehaviour;
    public PlantLocationData plantLocationData;
    private bool sceneOnLoad = false;

    [SerializeField] private SavePlantController savePlantController;

    private void Start() {
        enterText.text = enterTextString;
        // if(SceneManager.GetActiveScene().name == "Farm") InstantiateSavedPlant();

        inventoryObj = GameObject.FindGameObjectWithTag("Inventory");
        inventory = inventoryObj.GetComponent<Inventory>();

        // plants = GameObject.FindGameObjectsWithTag("Plant");
    }
    private void Update() {
        // if(plants.Length != GameObject.FindGameObjectsWithTag("Plant").Length) plants = GameObject.FindGameObjectsWithTag("Plant");
        if(isOnArea){
            //ZOOM to location
            enterText.gameObject.SetActive(true);
            if(Input.GetButton("Interact") && !sceneOnLoad) MoveScene(moveToSceneName); 
        }else{
            // ZOOM OUT
            enterText.gameObject.SetActive(false);
        }
    }
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player") isOnArea = true;
    }
    private void OnTriggerStay(Collider other) {
        if(other.gameObject.tag == "Player") isOnArea = true;
    }
    private void OnTriggerExit(Collider other) {
        if(other.gameObject.tag == "Player") isOnArea = false;
    }
    private void MoveScene(string sceneName){
        if(savePlantController) savePlantController.SaveCurrentData();
       
        sceneOnLoad = true;
        loadingScreen.LoadScene(sceneName);
    }
}
