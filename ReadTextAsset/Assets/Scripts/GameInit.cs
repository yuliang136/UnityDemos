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
	    TextAsset ta = Resources.Load<TextAsset>("ProtoBytes/CharacterName");

        MemoryStream ms = new MemoryStream(ta.bytes);

        CharacterName data = Serializer.Deserialize<schemes.CharacterName>(ms);

        string strShowReadInfo = string.Format(
                                        "ReadInfo {0}",
                                        data.items.Count);

        Debug.Log(data.items[0].woman);

        Debug.Log(strShowReadInfo);
	}
	
}
