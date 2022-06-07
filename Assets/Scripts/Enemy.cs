using System.Collections;
using System.Collections.Generic;
using UnityEngine; //NavMeshAgent
using UnityEngine.AI; //NavMeshAgent

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject target;
    NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        //enemy�� �������� target�� player�� �������� �ǵ��� �Ѵ�
        agent.destination = target.transform.position;
    }
}
