using UnityEngine;
using System.Collections;

public class SGGooseController : MonoBehaviour {
    
    #region GLOBALS CONST
    public int _curScore = 0;//текущий счет
    public int _maxScore = 0;//максимальный,служит для хранения
    public int _maxReplies = 0;//На будущее для статистики кто сколько попыток совершал.
    public float _curfirst = 1800f;//сила первого раза
    public float _curSecond = 3500f;//сила второго нажатия
    public float _gooseSpeed = 3.5f;//скорость гуся
    #endregion
    private Rigidbody2D _body;//тело
    private Camera _camera;
    public bool _firstTouch = false; //для изначального несильного толка без компенсации
    public State state = State.Prepare;//Типа стадии игры
    public Direction _dir = Direction.Right;
    public float _PosX; //Позиция с течением времени
    //public System.Random _rand = new System.Random();  Рандом для генерации
    public KeyCode _code;//Изменение кнопки полета для удобства на пк
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
        _body = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
        _camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        _body.isKinematic = true;
	}
	
	// Update is called once per frame
	void Update()
    {        
        #region Контроль движения
        if (_firstTouch == true)
            state = State.Game;
        #region TouchEvents
        if (Input.touchCount > 0)
        {
            if ((Input.GetTouch(0).phase == TouchPhase.Began) || (Input.GetKeyDown(KeyCode.Space)))
            {
                _body.isKinematic = false;
                if (_firstTouch == false)
                {
                    _body.AddForce(Vector2.up * _curSecond);
                }
                else _body.AddForce(Vector2.up * (_curSecond + _curfirst * 2));
                _firstTouch = true;
            }
        }
        #endregion
        #endregion
    }
    void FixedUpdate()
    {
        #region Аналогично из функции Update только для SPACE
        if (_firstTouch == true)
            state = State.Game;
        if ((Input.GetKeyDown(KeyCode.Space)))
        {
            _body.isKinematic = false;
            if (_firstTouch == false)
            {
                _body.AddForce(Vector2.up * _curSecond);
            }
            else _body.AddForce(Vector2.up * (_curSecond + _curfirst * 2));
            _firstTouch = true;
        }
        #endregion
    }
    void OnColliderEnter2D(Collider other){
        state = State.Lose;
    }
    void OnGUI()
    {
        //специально сделал для адекватного вида всего этого
        if (state == State.Prepare)
        {
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
        }
    }

    private void Game()
    {
        if (_dir == Direction.Right)
        {
            _camera.transform.position = new Vector3(_body.transform.position.x + 6.5f, _camera.transform.position.y, -10.0f);
            _PosX += (float)Time.deltaTime * _gooseSpeed;
            _body.transform.localPosition = new Vector2(_PosX, _body.transform.position.y);
        }
        if (_dir == Direction.Left)
        {
            _camera.transform.position = new Vector3(_body.transform.position.x-6.5f, _camera.transform.position.y,-10.0f);
            _PosX -= (float)Time.deltaTime * _gooseSpeed;
            _body.transform.localPosition = new Vector2(_PosX, _body.transform.position.y);
        }
    }

    private void Lose()
    {
        _body.isKinematic = true;
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
        _body.transform.position = new Vector2(-4, 0);
        _body.isKinematic = true;
      
    }
}
