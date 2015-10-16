using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class ButtonHandling : MonoBehaviour, IPointerDownHandler {

	public Plant plant;
    public float cooldown;
    public bool cooldownOnStart;
    public Color activeColor;
    public Color cooldownColor;

    private Button button;
	private float timeStamp = 0;
	private GameLogic logic;
    private List<Image> imagechildren;
    private Text priceText;
    private Image cooldownVisual;

    // Use this for initialization
    void Start () {
		button = gameObject.GetComponent<Button> ();
		logic = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameLogic>();

        getNecessaryThingsForUI();
  
        if (cooldownOnStart) {
			ActivateCooldown ();
		}
	}

	public void OnPointerDown(PointerEventData e){
        if (ResourceManager.getResources() >= ResourceManager.getPlantPrice(plant) && timeStamp < Time.time) {
            logic.ChangePlant(plant);
        }
	}
	
	// Update is called once per frame
	void Update () {
		if (ResourceManager.getResources () < ResourceManager.getPlantPrice(plant) || timeStamp > Time.time) {
			button.interactable = false;
		} else {
			button.interactable = true;
		}
        updateChildImages();
	}

    void getNecessaryThingsForUI() {
        Image[] allimagechildren = GetComponentsInChildren<Image>();
        imagechildren = new List<Image>();
        priceText = transform.Find("PriceText").GetComponent<Text>();
        foreach (Image img in allimagechildren) {
            if (img.name == "Cooldown") {
                cooldownVisual = img;
            } else {
                imagechildren.Add(img);
            }
        }
    }

    void ActivateCooldown(){
		timeStamp = Time.time + cooldown;
	}

    void updateChildImages() {

        if (button.interactable) {
            priceText.color = activeColor;
            foreach (Image img in imagechildren) {
                img.color = activeColor;
            }
        } else {
            priceText.color = cooldownColor;
            foreach (Image img in imagechildren) {
                img.color = cooldownColor;
            }
        }

        cooldownVisual.fillAmount = (timeStamp - Time.time)/cooldown;
    }
}
