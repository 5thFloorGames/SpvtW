using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

public class ButtonHandling : MonoBehaviour, IPointerDownHandler {

	public Plant plant;
	public float cooldown = 5f;
    public bool cooldownOnStart = true;
    public Color activeColor;
    public Color cooldownColor;

    private Button button;
	private float timeStamp = 0;
	private GameLogic logic;

	// Use this for initialization
	void Start () {
		button = gameObject.GetComponent<Button> ();
		logic = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameLogic>();
		if (cooldownOnStart) {
			ActivateCooldown ();
		}
	}

	public void OnPointerDown(PointerEventData e){
		logic.ChangePlant (plant);
	}
	
	// Update is called once per frame
	void Update () {
		if (ResourceScript.getResources () < ResourceScript.getPlantPrice(plant) || timeStamp > Time.time) {
			button.interactable = false;
		} else {
			button.interactable = true;
		}
        updateChildImages();
	}

	void ActivateCooldown(){
		timeStamp = Time.time + cooldown;
	}

    void updateChildImages() {
        Image[] imagechildren = GetComponentsInChildren<Image>();
        Text priceText = GetComponentInChildren<Text>();

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
    }
}
