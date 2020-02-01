using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Linq;

public class MiniPuzzle : MonoBehaviour, IPointerClickHandler
{
    public Image Puzzle_1;
    public Image Puzzle_2;
    public Image Puzzle_3;
    public Image Puzzle_4;

    private List<Image> images = new List<Image>();

    int[] angles = new int[4];

    void Start()
    {
        Roll();
    }

    void Update()
    {
        if (images.All(x => x.gameObject.GetComponent<RectTransform>().rotation.eulerAngles.z == 0))
        {
            Debug.Log("done");
            Destroy(this.gameObject);
        }
    }

    void Roll()
    {
        images.Add(Puzzle_1);
        images.Add(Puzzle_2);
        images.Add(Puzzle_3);
        images.Add(Puzzle_4);

        angles[0] = 90;
        angles[1] = 180;
        angles[2] = 270;

        foreach (var image in images)
        {
            var angle = angles[Random.Range(0, 3)];
            image.rectTransform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        var rectTrans = eventData.pointerPressRaycast.gameObject.GetComponent<RectTransform>();
        rectTrans.Rotate(new Vector3(0, 0, 90));
    }
}
