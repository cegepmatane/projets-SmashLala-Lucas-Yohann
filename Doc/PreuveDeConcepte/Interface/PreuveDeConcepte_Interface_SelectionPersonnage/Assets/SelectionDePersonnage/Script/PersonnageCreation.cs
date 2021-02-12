using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class PersonnageCreation : MonoBehaviour
{
	private int selectionPersonnageIndex;
	private Color desiredColor;

	[Header("liste des personnages")]
	[SerializeField] private List<SelectionPersonnageObject> personnageList = new List<SelectionPersonnageObject>();


	[Header("UI References")]
	[SerializeField] private TextMeshProUGUI personnageNom;
	[SerializeField] private Image personnageSplash;
	[SerializeField] private Image fondCouleur;


	private void Start()
	{
		UpdateSelectionDePersonnage();
	}

	public void boutonGauche()
	{
		selectionPersonnageIndex--;
		if (selectionPersonnageIndex< 0)
		{
			selectionPersonnageIndex = personnageList.Count -1;
		}
		UpdateSelectionDePersonnage();
	}

	public void boutonDroit()
	{
		selectionPersonnageIndex++;
		if (selectionPersonnageIndex == personnageList.Count)
		{
			selectionPersonnageIndex = 0;
		}
		UpdateSelectionDePersonnage();
	}

	public void boutonConfirmation()
	{
		Debug.Log(string.Format("personnage {0}:{1} est choisis", selectionPersonnageIndex, personnageList[selectionPersonnageIndex].nomPersonnage));
	}

	private void UpdateSelectionDePersonnage()
	{
		//splash, nom, contour couleur
		personnageSplash.sprite = personnageList[selectionPersonnageIndex].splash;
		personnageNom.text = personnageList[selectionPersonnageIndex].nomPersonnage;
		fondCouleur.color = personnageList[selectionPersonnageIndex].personnageCouleur;
		desiredColor = personnageList[selectionPersonnageIndex].personnageCouleur;			
	}

	[System.Serializable]
	public class SelectionPersonnageObject
	{ 
		public Sprite splash;
		public string nomPersonnage;
		public Color personnageCouleur;
	}
}