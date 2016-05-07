using UnityEngine;
using System.Collections;
using System.IO;
using ProtoBuf;
using schemes;

public class GameInit : MonoBehaviour 
{

	// Use this for initialization
	void Start ()
	{
        //TextAsset ta = Resources.Load<TextAsset>("ProtoBytes/CharacterName");

        //MemoryStream ms = new MemoryStream(ta.bytes);

        //CharacterName data = Serializer.Deserialize<schemes.CharacterName>(ms);

        //string strShowReadInfo = string.Format(
        //                                "ReadInfo {0}",
        //                                data.items.Count);

        //Debug.Log(data.items[0].woman);

	    CharacterName data = LoadBinaryData<schemes.CharacterName>("ProtoBytes/CharacterName");

        Debug.Log(data.items[0].woman);

	    // 尝试用泛型函数加载数据.

	}

    public T LoadBinaryData<T>(string strPath)
    {
        TextAsset ta = Resources.Load<TextAsset>(strPath);

        MemoryStream ms = new MemoryStream(ta.bytes);

        T data = Serializer.Deserialize<T>(ms);

        return data;

    }

}
