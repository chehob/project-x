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
    public TabButton TabButton;
    public GameObject TabContent;
}

public class TabGroup : MonoBehaviour
{
    [SerializeField] private TabEventChannelSO _clickTabEvent = default;
    [SerializeField] private TabEventChannelSO _enterTabEvent = default;
    [SerializeField] private TabEventChannelSO _exitTabEvent = default;

    public TabPair[] TabCollection;
    public TabButton DefaultTab;
    public Color TabIdleColor;
    public Color TabActiveColor;
    public Color TabHoverColor;

    protected TabButton CurrentTab { get; set; }

    protected void SetTabState(TabButton tabButton, bool picked)
    {        
        TabPair affectedItem = TabCollection.FirstOrDefault(tp => tp.TabButton == tabButton);
        affectedItem.TabContent.SetActive(picked);
        affectedItem.TabButton.Background.color = picked ? TabActiveColor : TabIdleColor;
    }

    public void PickTab(TabButton tabButton)
    {
        SetTabState(CurrentTab, false);
        CurrentTab = tabButton;
        SetTabState(CurrentTab, true);
    }

    protected int FindTabIndex(TabButton tabButton)
    {
        int index = 0;
        var currentTabPair = TabCollection.FirstOrDefault(x => x.TabButton == tabButton);
        if (currentTabPair == default)
        {
            Debug.LogWarning("The tab " + DefaultTab.gameObject.name + " does not belong to the tab strip " + name + ".");
            return index;
        }

        index = Array.IndexOf(TabCollection, currentTabPair);
        if(index == -1)
        {
            index = 0;
        }
        return index;
    }

    protected void OnEnable()
    {
        //Initialize all tabs to an unpicked state
        foreach (TabPair tp in TabCollection)
        {
            SetTabState(tp.TabButton, false);
        }
        //Pick the default tab
        if (TabCollection.Length > 0)
        {
            CurrentTab = DefaultTab;
            SetTabState(CurrentTab, true);
        }
    }

    protected void Start()
    {
        if(_clickTabEvent != null)
        {
            _clickTabEvent.OnEventRaised += PickTab;
        }
        if(_enterTabEvent != null)
        {
            _enterTabEvent.OnEventRaised += OnTabEnter;
        }
        if (_exitTabEvent != null)
        {
            _exitTabEvent.OnEventRaised += OnTabExit;
        }
    }

    private void OnTabEnter(TabButton tabButton)
    {
        if (tabButton != CurrentTab)
        {
            tabButton.Background.color = TabHoverColor;
        }
    }

    private void OnTabExit(TabButton tabButton)
    {
        if (tabButton != CurrentTab)
        {
            tabButton.Background.color = TabIdleColor;
        }
    }
}
