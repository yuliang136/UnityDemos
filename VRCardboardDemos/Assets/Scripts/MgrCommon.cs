using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class MgrCommon
{

    private static UnityEngine.Material s_materialGray = null;

    /// <summary>
    /// 设置图片置灰.
    /// </summary>
    /// <param name="imgSet">设置的图片</param>
    /// <param name="bSet">设置为灰,或者还原.</param>
    public static void SetImageGray(Image imgSet, bool bSet)
    {
        if (s_materialGray == null)
        {
            //Shader sha = Resources.lo<Shader>("Default Grey");
            Shader sha = Resources.Load<Shader>("shader/Default Grey");
            s_materialGray = new UnityEngine.Material(sha);
        }

        imgSet.material = bSet ? s_materialGray : null;



        // Debug.Log("here");

    }

}
