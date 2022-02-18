using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoRaquete : MonoBehaviour
{
    // Start is called before the first frame update
    [Range(1, 15)]
    public float velocidade = 8.0f;
    GameManager gm;
    public int firstStep = 0;
    public int secondStep = 0;
    void Start()
    {
        gm = GameManager.GetInstance();
    }

    // Update is called once per frame

void Update()
    {
        if (gm.gameState != GameManager.GameState.GAME) return;
        float inputX = Input.GetAxis("Horizontal");
        Vector2 posicaoViewport = Camera.main.WorldToViewportPoint(transform.position);
        if( posicaoViewport.x >= 0.07 && inputX < 0)
        {
            transform.position += new Vector3(inputX, 0, 0) * Time.deltaTime * velocidade;
        }
        else if( posicaoViewport.x <= 0.93 && inputX > 0){

            transform.position += new Vector3(inputX, 0, 0) * Time.deltaTime * velocidade;
        }
        if(Input.GetKeyDown(KeyCode.Escape) && gm.gameState == GameManager.GameState.GAME) {
        gm.ChangeState(GameManager.GameState.PAUSE);
        }
        if(gm.pontos == 10 && firstStep == 0){
            transform.localScale -= new Vector3(0.5f, 0, 0);
            firstStep = 1;
        }
        if(gm.pontos == 20 && secondStep == 0){
            transform.localScale -= new Vector3(0.5f, 0, 0);
            secondStep = 1;
        }

    }
}
