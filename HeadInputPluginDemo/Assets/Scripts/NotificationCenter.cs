using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class NotificationCenter
{
    private static NotificationCenter m_instance;

    public static NotificationCenter Instance
    {
        get
        {
            if (m_instance == null)
            {
                m_instance = new NotificationCenter();
            }
            return m_instance;
        }
    }

    private Dictionary<string, EventHandler> m_eventDic;

    public NotificationCenter()
    {
        m_eventDic = new Dictionary<string, EventHandler>();
    }

    public void AddEventHandler(string name, EventHandler handler)
    {
        if (m_eventDic.ContainsKey(name))
        {
            m_eventDic[name] += handler;
        }
        else
        {
            m_eventDic.Add(name, handler);
        }
    }

    public void RemoveEventHandler(string name, EventHandler handler)
    {
        if (m_eventDic.ContainsKey(name))
        {
            m_eventDic[name] -= handler;
            if (m_eventDic[name] == null)
            {
                m_eventDic.Remove(name);
            }
        }
    }

    public void NotifyEvent(string name, EventArgs args)
    {
        if (m_eventDic.ContainsKey(name) && Application.isPlaying)
        {
            m_eventDic[name].Invoke(m_eventDic[name].Target, args);
        }
    }

}
