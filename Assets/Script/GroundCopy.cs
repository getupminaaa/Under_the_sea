using UnityEngine;

public class GroundCopy : MonoBehaviour
{
    float size = 2.7f;
    public GameObject originGround;

    // Start is called before the first frame update
    void Start()
    {
        float pos = originGround.transform.position.x;
        for (int i = 1; i <= 30; i++)
        {
            pos += size;
            GameObject ground = Instantiate(originGround, gameObject.transform);
            ground.transform.position = new Vector2(pos, ground.transform.position.y);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
