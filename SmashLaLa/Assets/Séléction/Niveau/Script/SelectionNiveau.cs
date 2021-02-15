using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SelectionNiveau : MonoBehaviour
{
    private int selectionNiveauxIndex;
    private Color desiredColor;

    [Header("liste des niveaux")]
    [SerializeField] private List<SelectionNiveauObject> niveauList = new List<SelectionNiveauObject>();


    [Header("UI References")]
    [SerializeField] private TextMeshProUGUI niveauNom;
    [SerializeField] private Image niveauSplash;
    [SerializeField] private Image fondCouleur;


    private void Start()
    {
        UpdateSelectionDeNiveau();
    }


    public void boutonGauche()
    {
        selectionNiveauxIndex--;
        if (selectionNiveauxIndex < 0)
        {
            selectionNiveauxIndex = niveauList.Count - 1;
        }
        UpdateSelectionDeNiveau(); 
    }

    public void boutonDroit()
    {
        selectionNiveauxIndex++;
        if (selectionNiveauxIndex == niveauList.Count)
        {
            selectionNiveauxIndex = 0;
        }
        UpdateSelectionDeNiveau();
    }

    public void boutonConfirmation()
    {
        Debug.Log(string.Format("niveau {0}:{1} est choisis", selectionNiveauxIndex, niveauList[selectionNiveauxIndex].nomNiveau));
    }

    private void UpdateSelectionDeNiveau()
    {
        //splash, nom, contour couleur
        niveauSplash.sprite = niveauList[selectionNiveauxIndex].splash;
        niveauNom.text = niveauList[selectionNiveauxIndex].nomNiveau;
        fondCouleur.color = niveauList[selectionNiveauxIndex].niveauCouleur;
        desiredColor = niveauList[selectionNiveauxIndex].niveauCouleur;
    }

    [System.Serializable]
    public class SelectionNiveauObject
    {
        public Sprite splash;
        public string nomNiveau;
        public Color niveauCouleur;
    }
}
