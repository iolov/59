using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class generator : MonoBehaviour
{
    [SerializeField]private GameObject river, send, grond, stone,baryer,player,krepost;
    [SerializeField]private float sid,zoom,n;
    [SerializeField]private int sise,r;
    [SerializeField] List<Vector2> listK = new List<Vector2>();
    [SerializeField] List<float> Ncol = new List<float>();
    void Start()
    {
        Time.timeScale = 1;
        DataHolder.StartScore++;
        if (DataHolder.StartScore <= 1)
        {
            sid = Random.Range(0, 9999999);
            DataHolder.sidIS = sid;
        }
        else
        {
            sid = DataHolder.sidIS;
        }
        int lenth = sid.ToString().Length;
        for (int i = 0; i < sise + 1; i++)
        {
            for (int j = 0; j < sise + 1; j++)
            {
                n = Mathf.PerlinNoise((i + sid) / zoom, (j + sid) / zoom);

                if (n < 0.2) { listK.Add(new Vector2(i, j)); Ncol.Add(n); }

                if (n < 0.5&&  n>0.2) { listK.Add(new Vector2(i, j)); Ncol.Add(n); }
            }
        }
        Ins(krepost, listK[Ncol.IndexOf(Ncol.Max())]);
        Ins(krepost, listK[Ncol.IndexOf(Ncol.Min())]);

        for (int i = 0; i < sise + 1; i++)
        {
            for (int j = 0; j < sise + 1; j++)
            {
                n = Mathf.PerlinNoise((i + sid) / zoom, (j + sid) / zoom);

                if (n < 0.2)
                {
                    Ins(river, new Vector2(i, j));
                    continue;
                }
                if (n < 0.5)
                {
                    Ins(send, new Vector2(i, j));
                    continue;
                }
                if (n < 0.7)
                {
                    Ins(grond, new Vector2(i, j));
                    continue;
                }
                if (n > 0.7)
                {
                    Ins(stone, new Vector2(i, j));
                }
            }
        }
        if (DataHolder.StartScore <= 1)
        {
            DataHolder.siseIs = sise;
        }
        else
        {
            sise = DataHolder.siseIs;
        }
        if (DataHolder.StartScore <= 1)
        {
            DataHolder.playerPosition = player.transform.position;
            player.transform.localPosition = new Vector2(sise / 2, sise / 2);
        }
        else
        {
            player.transform.position = DataHolder.playerPosition;
        }
            for (int i = 0; i < sise + 1; i++)
            {
                Ins(baryer, new Vector2( i, 0 - 1));
                Ins(baryer, new Vector2(0 - 1, i));
                Ins(baryer, new Vector2(sise + 1, i));   
                Ins(baryer, new Vector2(i, sise + 1));
            }
    }
    void Ins(GameObject obg,Vector2 vec)
    {
        Instantiate(obg,vec,Quaternion.identity);
    }
    private void FixedUpdate()
    {
        DataHolder.playerPosition = player.transform.position;
    }
}
