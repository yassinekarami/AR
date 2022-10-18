using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

using Utils.SceneManagement.Manager;
public class ToggleManager : MonoBehaviour
{
    private ToggleGroup toggleGroup;
    public List<Toggle> toggles;
    private Toggle selectedToggle;

    private void Start()
    {
        toggleGroup = GetComponent<ToggleGroup>();
        foreach(Toggle toggle in toggles)
        {
            toggleGroup.RegisterToggle(toggle);
            toggle.onValueChanged.AddListener(delegate
            {
                OnPointerClick(toggle);
            });
       
        }
    }

    void OnPointerClick(Toggle change)
    {
        toggleGroup.NotifyToggleOn(change, true);

        //TODO: remplacer par un system d'evenement
        //la manager ne doit pas etre appelé directement
        Manager<string>.Load(change.gameObject.tag.ToString());
    }
}
