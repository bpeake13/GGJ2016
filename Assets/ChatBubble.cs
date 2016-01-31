using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ChatBubble : MonoBehaviour {

    public GameObject player;
    public GameObject TextBubbleGo;

    Text textMesh;
    LineRenderer LineRenderer;

    Vector3 triangleOffset;

	// Use this for initialization
	void Start () {

        Image ChatBubbleImage = TextBubbleGo.GetComponent<Image>();
        RectTransform chatRect = ChatBubbleImage.rectTransform;
    
    }
	
	// Update is called once per frame
	void Update () {

    }
}
