using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class pathcalculator : MonoBehaviour
{
    public GameObject target;
    public GameObject monster;

    private NavMeshPath path ;
    private NavMeshAgent agent ;

    
    //public bool canPath;

    private int mask;

    public float realLength;
    public float pathLength;

    public bool canJoin;

    public GameObject player;
    
    // Start is called before the first frame update
    void Start()
    {
        path = new NavMeshPath();
        
        mask = 1;
        canJoin = false;

        agent = monster.GetComponent<NavMeshAgent>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(agent == null)
            agent = monster.GetComponent<NavMeshAgent>();


        realLength = Vector3.Distance(monster.transform.position, target.transform.position);
        
        
        GetPath(path, monster.transform.position, player.transform.position, NavMesh.AllAreas);
        pathLength = GetPathLength(path);

        FPC.monster_pathDistance = pathLength;
        //canPath = NavMesh.CalculatePath(target.transform.position, monster.transform.position, NavMesh.AllAreas, path);
        

        if(canJoin)
        {
            canJoin = false;
            agent.destination = target.transform.position;
        }


        if(GameManager.instance.progression > 8)
        {
            checkDistance();
        }

        //Debug.Log(pathLength);

    }

    public static bool GetPath(NavMeshPath _path, Vector3 fromPos, Vector3 toPos, int passableMask)
    {
        if(_path != null)
        {
            _path.ClearCorners();
            //Debug.Log("path different de nul");
        }



        if (NavMesh.CalculatePath(fromPos, toPos, passableMask, _path) == false)
        {
            /*Debug.Log("CalculatePath == false");
            Debug.Log(fromPos);
            Debug.Log(toPos);
            Debug.Log(_path);
            Debug.Log(passableMask);
            Debug.Log("CalculatePath == false");
            */
            return false;

        }
        return true;
    }

    public static float GetPathLength(NavMeshPath _path)
    {
        float lng = 0.0f;

        if ((_path.status != NavMeshPathStatus.PathInvalid) && (_path.corners.Length > 1))
        {
            //Debug.Log("path status different de false");
            for (int i = 1; i < _path.corners.Length; ++i)
            {
                lng += Vector3.Distance(_path.corners[i - 1], _path.corners[i]);
            }
        }

        return lng;
    }

    private void checkDistance()
    {
        if(pathLength < 6 && pathLength > 0)
        {
            monster.GetComponent<s_monster>().isLooking = true;
            //player.GetComponent<FPC>().animator.SetTrigger("");
        }
        else
        {
            monster.GetComponent<s_monster>().isLooking = false;

        }
    }
}
