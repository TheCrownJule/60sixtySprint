//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class Test : MonoBehaviour
//{
//    private Pathfinding pathfinding; 
 

//    public Transform startTransform;
//    public Transform targetTransform;

//    void Start()
//    {
//        int width = 10;  // Set your grid dimensions
//        int height = 10;

//        pathfinding = new Pathfinding(width, height);

//        // Assuming you have set the start and target transforms in the Unity Editor
//        FindAndDisplayPath();
//    }

//    void Update()
//    {
//        // Example: Recalculate path when the user clicks somewhere
//        if (Input.GetMouseButtonDown(0))
//        {
//            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
//            RaycastHit hit;

//            if (Physics.Raycast(ray, out hit))
//            {
//                targetTransform.position = hit.point;
//                FindAndDisplayPath();
//            }
//        }
//    }

//    void FindAndDisplayPath()
//    {
//        List<PathNode> path = pathfinding.FindPath(startTransform.position, targetTransform.position);

//        if (path != null)
//        {
//            Debug.Log("Path found!");
//            foreach (PathNode node in path)
//            {
//                Debug.DrawLine(node.Grid.GetXY(node.X, node.Y), node.Grid.GetXY(node.X, node.Y + 1), Color.red, 1f);
//                Debug.DrawLine(node.Grid.GetXY(node.X, node.Y), node.Grid.GetXY(node.X + 1, node.Y), Color.red, 1f);
//            }
//        }
//        else
//        {
//            Debug.Log("Path not found!");
//        }
//    }
//}
