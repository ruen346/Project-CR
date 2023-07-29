using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI.Extensions;

public class EventGroup : MonoBehaviour
{
    public HorizontalScrollSnap scrollSnap;
    public List<EventNaviButton> naviButtons;

    private void Awake()
    {
        scrollSnap.OnSelectionPageChangedEvent.AddListener(ChangePage);
    }
    
    private void ChangePage(int index)
    {
        for (int i = 0; i < naviButtons.Count; i++)
        {
            naviButtons[i].OnActive(index == i);
        }
    }
}
