using UnityEngine;
using System.Collections;
using System.Runtime.Remoting.Metadata.W3cXsd2001;

public class Main : MonoBehaviour
{
    private float incomingDamage = 242.0f;

    private string month = "December";
    private int day = 31;
    private int year = 2012;

    private int _nCount = 5;

    vp_Timer.Handle Timer = new vp_Timer.Handle();

    

    public void TestVpTimer()
    {
        //vp_Timer.In(1.0f, delegate() { print("Hello World");  });

        //vp_Timer.In(
        //            1.0f,
        //    delegate(object o)
        //    {
        //        InflictDamage((float) o);
        //    },
        //    incomingDamage

        //    );

        //vp_Timer.In(5.0f, delegate(object o)
        //{
        //    object[] arg = (object[]) o;

        //    print("Month: " + (string)arg[0]
        //          + ", Day:" + (int)arg[1]
        //          + ", Year:" + (int)arg[2]);
        //}, new object[] {month,day,year}
        //);

        //Debug.Log("here");
        //vp_Timer.CancelAll();



        //vp_Timer.In(0.0f, SomeMethod, 5, 1, Timer);

        //vp_Timer.In(3, delegate() { Timer.Cancel();});

        //vp_Timer.In(2.0f,SomeMethod,Timer);

        //if (!Timer.Active)
        //{
        //    vp_Timer.In(1.5f,SomeMethod,Timer);
        //}

        vp_Timer.In(0f, SomeMethod, "", 6, 1, Timer);

    }

    public void Update()
    {
        //if (Input.GetKeyUp(KeyCode.Space))
        //{
        //    Timer.Cancel();
        //}
    }



    //void InflictDamage(float fSet)
    //{
    //    Debug.Log(fSet);
    //}

    //public void SomeMethod(object o)
    //{
    //    object[] arg = (object[]) o;

    //    print("Month: " + (string)arg[0]
    //            + ", Day:" + (int)arg[1]
    //            + ", Year:" + (int)arg[2]);
    //}

    public void SomeMethod(object o)
    {
        Debug.Log(_nCount);

        _nCount--;
    }

    //public void SomeMethod()
    //{
    //    //int s = (int) o;
        
    //    //print(s);

    //    Debug.Log("12");
    //}

}
