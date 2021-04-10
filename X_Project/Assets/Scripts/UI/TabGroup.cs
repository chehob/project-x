using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[Serializable]
public class TabPair
{
    public Button TabButton;
    public GameObject TabContent;
}

public class TabGroup : MonoBehaviour
{
    public TabPair[] TabCollection;
    public Button DefaultTab;

    protected int CurrentTabIndex { get; set; }

    protected void SetTabState(int index, bool picked)
    {
        TabPair affectedItem = TabCollection[index];
        affectedItem.TabContent.SetActive(picked);        
        //affectedItem.TabButton.image.sprite = picked ? TabIconPicked : TabIconDefault;
    }

    public void PickTab(int index)
    {
        SetTabState(CurrentTabIndex, false);
        CurrentTabIndex = index;
        SetTabState(CurrentTabIndex, true);
    }

    protected int? FindTabIndex(Button tabButton)
    {
        var currentTabPair = TabCollection.FirstOrDefault(x => x.TabButton == tabButton);
        if (currentTabPair == default)
        {
            Debug.LogWarning("The tab " + DefaultTab.gameObject.name + " does not belong to the tab strip " + name + ".");
            return null;
        }
        return Array.IndexOf(TabCollection, currentTabPair);
    }

    protected void OnEnable()
    {
        //Initialize all tabs to an unpicked state
        for (var i = 0; i < TabCollection.Length; i++)
        {
            SetTabState(i, false);
        }
        //Pick the default tab
        if (TabCollection.Length > 0)
        {
            var index = FindTabIndex(DefaultTab);
            //If tab is invalid, instead default to the first tab.
            if (index == null)
                index = 0;
            CurrentTabIndex = index.Value;
            SetTabState(CurrentTabIndex, true);
        }
    }

    protected void Start()
    {
        for (var i = 0; i < TabCollection.Length; i++)
        {
            //Storing the current value of i in a locally scoped variable.
            var index = i;
            TabCollection[index].TabButton.onClick.AddListener(new UnityAction(() => PickTab(index)));
        }
    }
}