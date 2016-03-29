using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class YLManager
{

    public int _nVolume;        // 音量.
    public bool _bEarphonePlug; // 是否连接上耳机.



    private static YLManager m_instance;

    public static YLManager Instance
    {
        get
        {
            if (m_instance == null)
            {
                m_instance = new YLManager();
            }
            return m_instance;
        }
    }
}
