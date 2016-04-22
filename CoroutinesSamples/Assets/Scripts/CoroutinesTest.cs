using UnityEngine;
using System.Collections;

public class CoroutinesTest : MonoBehaviour 
{

    // This function represents a generator of the fibonacci sequence
    private IEnumerator Fibonacci()
    {
        int Fkm2 = 1;
        int Fkm1 = 1;
        yield return 1; // The first two values are 1
        yield return 1;
        // Now, each time we continue execution, generate the next entry.
        while (Fkm1 + Fkm2 < int.MaxValue)
        {
            int Fk = Fkm2 + Fkm1;
            Fkm2 = Fkm1;
            Fkm1 = Fk;
            yield return Fk;
        }
    }

    // Use this for initialization
	void Start ()
	{
	    IEnumerator fib = Fibonacci();

	    for (int i = 0; i < 10; i++)
	    {
	        if (!fib.MoveNext())
	        {
	            break;
	        }

            Debug.Log((int)fib.Current);
	    }
	}
	
}
