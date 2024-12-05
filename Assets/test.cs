using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class CoordinateReader : MonoBehaviour
{
    public string filePath = @"C:\Users\asadb\Documents\coding\python stuff\valReplayCoords\final.txt";
    public GameObject targetObject;
    public float scaleFactor = 1f;
    public float movementSpeed = 1.0f;


    void Start()
    {
        if (File.Exists(filePath))
        {
            string[] lines = File.ReadAllLines(filePath);
            List<Vector3> positions = new List<Vector3>();
            List<Vector3> moves = new List<Vector3>();

            foreach (string line in lines)
            {
                string[] coordinates = line.Trim('(', ')').Split(',');
                float x = float.Parse(coordinates[0]);
                float y = float.Parse(coordinates[1]);
                x = x * 100;
                y = y * 100;
                Vector3 position = new Vector3(x * scaleFactor, 0f, y * scaleFactor); // Adjust the vector to match Unity's coordinate system.
                positions.Add(position);
                //Debug.Log(x + ", " + y + " : " + position);
            }

            for (int i = 0; i < positions.Count-1; i++)
            {
                Vector3 temp = positions[i] - positions[i + 1];
                temp.x = temp.x * -0.238697917f;
                temp.z = temp.z * 0.238697917f;
                moves.Add(temp);
                Debug.Log(temp);
            }

            StartCoroutine(MoveObjectAlongPathCoroutine(moves));
        }
        else
        {
            Debug.LogError("File not found: " + filePath);
        }
    }

    IEnumerator MoveObjectAlongPathCoroutine(List<Vector3> moves)
    {

        if (targetObject == null)
        {
            Debug.LogError("Target object is not assigned!");
            yield break;
        }

        for (int i = 0; i < moves.Count; i++)
        {
            Vector3 startPosition = targetObject.transform.position;
            Vector3 targetPosition = moves[i];


            targetObject.transform.position += moves[i];
            //Debug.Log(positions[i]);

            // Wait for a short delay before moving to the next position.
            yield return new WaitForSeconds(0.1f);
        }
    }
}
