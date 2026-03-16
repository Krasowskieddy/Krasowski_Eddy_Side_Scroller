using UnityEngine;

public class patrol : MonoBehaviour
{
    public Transform chara;
    public Transform patrolA;
    public Transform patrolB;

    public float dir = -1f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(chara.position, patrolA.position) < 0.1f)
        {
            dir = 1f;
        }
        else if (Vector2.Distance(chara.position, patrolB.position) < 0.1f)
        {
            dir = -1f;
        }

        chara.position += new Vector3(1*Time.deltaTime * dir, 0, 0);    

    }
}
