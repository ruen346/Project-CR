using System;
using System.Collections.Generic;
using UnityEngine;

public class CharacterWindow : BaseWindow
{
    public static CharacterWindow instance;
    
    public GameObject characterIcon;
    public GameObject characterParent;
    public List<CharacterIcon> CharacterIcons;

    private void Awake()
    {
        instance = this;
    }

    public void Start()
    {
        foreach (var data in DataManager.Instance.characterData.CharacterInfoDatas)
        {
            var character = Instantiate(characterIcon, characterParent.transform);
            var characterData = character.GetComponent<CharacterIcon>();
            characterData.Init(data);
            
            CharacterIcons.Add(characterData);
        }
    }

    public void UpdateData()
    {
        foreach (var character in CharacterIcons)
        {
            character.SetText();
        }
    }
}
