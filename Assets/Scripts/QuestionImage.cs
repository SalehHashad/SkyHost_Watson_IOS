using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionImage : MonoBehaviour
{
    public DragDropManager _dragDropManager;
    public Texture[] ImagesList;
    public Transform ImageParent;
    public GameObject ImagePrefab;
    // Start is called before the first frame update

    private void Awake()
    {
        _dragDropManager = FindObjectOfType<DragDropManager>();
    }
    void Start()
    {
        reshuffle(ImagesList);
        StartCoroutine(SpawnImage());
    }
    public IEnumerator SpawnImage()
    {
        int x = 0;
        for (int i = 0; i < ImagesList.Length; i++)
        {
            // GameObject fishPrefab = Resources.Load<GameObject>("Prefabs/fish");

            GameObject newFish = Instantiate(ImagePrefab, ImageParent.position, Quaternion.identity, ImageParent);
            newFish.GetComponent<RawImage>().texture = ImagesList[x];
            newFish.GetComponent<RectTransform>().localScale = new Vector2(1, 1);
            Vector3 transformPosition = newFish.transform.position;
           //dragDropManager.AllPanels.Add(newFish);
            //transformPosition.x += Random.Range(-seaYRange, seaYRange);
            //newFish.transform.position = transformPosition;
            
            x++;

            Resources.UnloadUnusedAssets();
            yield return new WaitForSeconds(0);
          
        }
    }
    void reshuffle(Texture[] TempTexture)
    {
        // Knuth shuffle algorithm :: courtesy of Wikipedia :)
        for (int t = 0; t < TempTexture.Length; t++)
        {
            Texture tmp = TempTexture[t];
            int r = Random.Range(t, TempTexture.Length);
            TempTexture[t] = TempTexture[r];
            TempTexture[r] = tmp;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
