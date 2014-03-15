using UnityEngine;
using System.Collections;

public class SGGooseController : MonoBehaviour {
    
    #region GLOBALS CONST
    public int _curScore = 0;//текущий счет
    public int _maxScore = 0;//максимальный,служит для хранения
    public int _maxReplies = 0;//На будущее для статистики кто сколько попыток совершал.
    #endregion
    private Camera _camera;
    public bool _firstTouch = false; //для изначального несильного толка без компенсации
    public State state = State.Prepare;//Типа стадии игры
    public Direction _dir = Direction.Right;
    public float _PosX; //Позиция с течением времени
    //public System.Random _rand = new System.Random();  Рандом для генерации
    public static KeyCode _code;//Изменение кнопки полета для удобства на пк
    public int _CurStage = 0;

    public enum Direction
    {
        Right,
        Left
    }
    public enum State
    {
        Prepare,
        Generate,
        Game,
        Lose
    }
	void Start(){
        _camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update()
    {    
    }

	void OnCollisionEnter2D(Collision2D coll) {
        state = State.Lose;
    }
    void OnGUI()
    {
        //специально сделал для адекватного вида всего этого
        if (state == State.Prepare)
        {
			_firstTouch = false;
            Prepare();
        }
        else if (state == State.Generate)
        {
            //Нужен метод для однократной генерации карты и на будущее просто менять состояние чтобы сгенерить и вызывать,если нужно будет догенерить уровень.
        }
        else if (state == State.Game)
        {
            Game();
        }
        else if (state == State.Lose)
        {
            Lose();
			this.transform.position = new Vector2(this.transform.position.x-0.2f,this.transform.position.y);
			this.GetComponent<Displacement>().enabled = false;
			this.GetComponent<TestSGController>().enabled = false;
			//Destroy(this.GetComponent<Displacement>());

        }
    }
	void FixedUpdate()
	{
		#region Аналогично из функции Update только для SPACE
		if (_firstTouch == true)
		{
			state = State.Game;
			this.GetComponent<Displacement>().enabled = true;
			this.GetComponent<TestSGController>().enabled = true;
		}
		if ((Input.GetKeyDown(KeyCode.Space)))
		{
			_firstTouch = true;
		}
		#endregion
		}

    private void Game()
    {
        if (_dir == Direction.Right)
        {
            _camera.transform.position = new Vector3(this.transform.position.x +6f, _camera.transform.position.y, -10.0f);
        }
        if (_dir == Direction.Left)
        {
            _camera.transform.position = new Vector3(this.transform.position.x-6f, _camera.transform.position.y,-10.0f);
        }
    }

    private void Lose()
    {
        if (GUI.Button(new Rect(Screen.width / 2 - 150, Screen.height / 2, 150, 150), "RETRY"))
        {
            state = State.Prepare;
            _firstTouch = false;
        }
        if (GUI.Button(new Rect(Screen.width / 2, Screen.height / 2, 150, 150), "EXIT"))
        {
            Application.Quit();
        }
    }
    void Prepare()
    {
		GUI.Label (new Rect (Screen.width / 2, Screen.height / 2, 100, 20), "PREPARE TO DIE");
      
    }
}
