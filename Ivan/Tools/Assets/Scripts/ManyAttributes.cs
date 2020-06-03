﻿using UnityEngine;

[SelectionBase]
public class ManyAttributes : MonoBehaviour {
    [Header("My Header")]
    //[TextArea]
    [Tooltip("Appears when hovering over")]
    [SerializeField]
    private string myVariable;

    [Multiline]
    [Tooltip("A string using the MultiLine attribute")]
    [SerializeField]
    private string descriptionMultiLine;

    [Header("Numeric Attributes")]
    [Tooltip("A float using the Range attribute")]
    [Range(-5f, 5f)]
    [SerializeField]
    private float rangedFloat;

    [Space]
    [Tooltip("An integer using the Range attribute")]
    [Range(-5, 5)]
    [SerializeField]
    private int rangedInt;

    [Header("Color Attributes")]

    [SerializeField]
    private Color colorNormal;

    [ColorUsage(false)]
    [SerializeField]
    private Color colorNoAlpha;

    [ColorUsage(true, true)]
    [SerializeField]
    private Color colorHdr;

    [ContextMenu("My Method")]
    private void ChooseRandomValues() {
        rangedFloat = Random.Range(-5f, 5f);
        rangedInt = Random.Range(-5, 5);
    }

    [Header("Context Menu Items")]
    [ContextMenuItem("RandomValue", "RandomizeValueFromRightClick")]
    [SerializeField]
    private float randomValue;

    private void RandomizeValueFromRightClick() {
        randomValue = Random.Range(-5f, 5f);
    }
}