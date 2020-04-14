using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using TMPro;

[ExecuteAlways]
public class MenuItem : MonoBehaviour, 
						IPointerEnterHandler, 
						IPointerExitHandler,
						IPointerClickHandler {

	[SerializeField]
	private string text = "Menu Item";

	[SerializeField]
	private Gradient neutralGradient = new Gradient();

	[SerializeField]
	[Range(0, 1)]
	private float neutralGradientBias = 0;

	[SerializeField]
	private Gradient selectedGradient = new Gradient();

	[SerializeField]
	[Range(-2f, 2f)]
	private float neutralOverlayXOffset = 1f;

	[SerializeField]
	[Range(-2f, 2f)]
	private float neutralOverlayYOffset = 0f;

	[SerializeField]
	[Range(-2f, 2f)]
	private float selectedOverlayXOffset = 1f;

	[SerializeField]
	[Range(-2f, 2f)]
	private float selectedOverlayYOffset = 0f;

	[SerializeField]
	private bool isSelected = false;

	public TextMeshProUGUI[] neutralGUIItems = new TextMeshProUGUI[0];
	public TextMeshProUGUI[] selectedGUIItems = new TextMeshProUGUI[0];

	public UnityEvent OnClick;

	private TextMeshProUGUI[] guiTextItems = new TextMeshProUGUI[0];

	private Animator animator;

	void Start() {
		animator = GetComponent<Animator>();

		selectedGradient.colorKeys = new GradientColorKey[] {
			new GradientColorKey(new Color(   1,    0, 0.88f), 0),
			new GradientColorKey(new Color(0.9f, 0.9f, 0.90f), 1)
		};
		neutralGradient.colorKeys = new GradientColorKey[] {
			new GradientColorKey(Color.cyan, 0),
			new GradientColorKey(Color.white, 1)
		};
		guiTextItems = GetComponentsInChildren<TextMeshProUGUI>(true);
		HandleGUIItems();
	}

	private void OnValidate() {
		foreach (var guiTextItem in guiTextItems) {
			guiTextItem.text = text;
		}
		gameObject.name = text + " Base";

		HandleGUIItems();
	}

	private void Update() {
		HandleGUIItems();
	}

	private void HandleGUIItems() {
		if (isSelected) {
			SetGUIState(selectedGUIItems, 
				neutralGUIItems, 
				selectedGradient,
				selectedOverlayXOffset,
				selectedOverlayYOffset);
		} else {
			SetGUIState(neutralGUIItems, 
				selectedGUIItems, 
				neutralGradient,
				neutralOverlayXOffset,
				neutralOverlayYOffset);
		}
	}

	private void SetGUIState(TextMeshProUGUI[] currentGUIItems,
							 TextMeshProUGUI[] otherGUIItems,
							 Gradient gradient,
							 float xOffset,
							 float yOffset) {
		SetGUIItemsColor(currentGUIItems, gradient);
		SetGUIItemsOffset(currentGUIItems, xOffset, yOffset);
		foreach (var guiItem in currentGUIItems) {
			guiItem.gameObject.SetActive(true);
		}
		foreach (var guiItem in otherGUIItems) {
			guiItem.gameObject.SetActive(false);
		}
	}

	private void SetGUIItemsColor(TextMeshProUGUI[] guiItems, Gradient gradient) {
		for (int i = 0; i < guiItems.Length; ++i) {
			float sampleValue = (float)i / (guiItems.Length - 1);
			float biasedSampleValue = 
				Mathf.Lerp(sampleValue, 1 - sampleValue, neutralGradientBias);
			guiItems[i].color = gradient.Evaluate(biasedSampleValue);
		}
	}

	private void SetGUIItemsOffset(TextMeshProUGUI[] guiItems, float xOffset, float yOffset) {
		for (int i = 0; i < guiItems.Length; ++i) {
			guiItems[i].rectTransform.localPosition = 
				new Vector2(xOffset, yOffset) * i;
		}
	}

	public void OnPointerEnter(PointerEventData eventData) { 
		animator.SetBool("IsSelected", isSelected = true);
	}

	public void OnPointerExit(PointerEventData eventData) {
		animator.SetBool("IsSelected", isSelected = false);
	}

	public void OnPointerClick(PointerEventData eventData) {
		OnClick?.Invoke();
	}
}
