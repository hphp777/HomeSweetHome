using UnityEngine;
using System.Collections;

public class PlayerM: MonoBehaviour {

	//public 으로 선언되어 inspector view에서 입력할 수 있는 변수 3종류이다	
	public	GameObject	playerObject= null;	//플레이어
	public	GameObject	bulletObject= null;	//총알 프리팹
	public	Transform	bulletStartPosition= null; //총알이 발사되는 지점
	
	
	private	static readonly	float		MOVE_Z_FRONT			=  5.0f;
	private	static readonly	float		MOVE_Z_BACK				= -2.0f;
	
	private	static readonly	float		ROTATION_Y_KEY			= 360.0f;
	private	static readonly	float		ROTATION_Y_MOUSE		= 720.0f;
	
	private	float		m_rotationY				= 0.0f;
	
	private	bool		m_mouseLockFlag			= true;


    [System.Obsolete]
    private		void	Update() {
		
		if( GameM.IsStageCleared()) {
			return;
		}
		
		//マウスロック処理
		CheckMouseLock();
		
		//移動処理
		CheckMove();
	}


    /*
	 *	マウスロック処理のチェック
	 */
    [System.Obsolete]
    private		void	CheckMouseLock() {
		
		//Escキーをおした時の動作
		if( Input.GetKeyDown( KeyCode.Escape)) {
			//フラグをひっくり返す
			m_mouseLockFlag	= !m_mouseLockFlag;
		}
		
		//マウスロックされてる？
		if( m_mouseLockFlag) {
			//ロックしていたらロック解除
			Screen.lockCursor	= true;
			//Screen.showCursor	= false;
		} else {
			//ロック解除されていたらロック
			Screen.lockCursor	= false;
			//Screen.showCursor	= true;
		}
	}

	// 이동 처리 검사
	private	void CheckMove() {
		
		//회전
		{
			//이 프레임에서 움직이는 회전량
			float	addRotationY	= 0.0f;
			if( Input.GetKey( KeyCode.Q)) {
				addRotationY		= -ROTATION_Y_KEY;
			} else
			if( Input.GetKey( KeyCode.E)) {
				addRotationY		=  ROTATION_Y_KEY;
			}
			
			//마우스 이동량에 의한 회전
			
			if( m_mouseLockFlag) {
				//마우스를 좌우로 움직이는 이동향을 얻어 각도로 넘겨준다
				addRotationY += (Input.GetAxis( "Mouse X")	*ROTATION_Y_MOUSE);
			}
			
			//현재 각도에 넘겨받은 값을 더한다
			m_rotationY	+= (addRotationY*Time.deltaTime);
			
			//이동량, 회전량의 경우 Time.deltaTime을 곱해서 실행 환경에 따른 차이가 없게 한다
			//여기서 실행 환경이란, 기기 성능에 의해 발생되는 프레임 수의 차이를 말한다

			//오일러 각으로 입력한다
			//Y축 회전을 통해 캐릭터 방향을 옆으로 바꾼다
			transform.rotation	= Quaternion.Euler( 0, m_rotationY, 0);
		}
		
		//이동
		Vector3	addPosition	= Vector3.zero;		//이동량 (z값은 메카님에도 넘겨준다)
		{
			//Vector3.zero는 new Vector3(0f,0f,0f)와 같다고 한다. 내 생각에는 버전차이인듯하다 (mutjin23)

			//키 조작에서 이동할 양을 얻는다
			//z에 앞 뒤 방향을 입력한다 w누르면 vecInput.z>0 이라 앞으로 가고 s누르면 반대인 것이다 (mutjin23)
			Vector3 vecInput		= new Vector3( 0f, 0, Input.GetAxisRaw( "Vertical"));
			
			//z에 값이 입력되어 있는지 확인한다
			if( vecInput.z > 0) { //전진
				addPosition.z		= MOVE_Z_FRONT;
			} else
			if( vecInput.z < 0) { //후퇴
				addPosition.z		= MOVE_Z_BACK;
			}
			
			//이동량을 transform에 넘겨주어 이동시킨다
			transform.position	+= ((transform.rotation	 	*addPosition)		*Time.deltaTime);
			//Vector3 형식으로 transform.rotation을 곱하면 그 방향으로 꺾어진다
			//이 때, Vector3 은 Z+ 방향 (양수방향)을 정면으로 여긴다
		}
		
		//射撃
		bool	shootFlag;
		{
			//射撃ボタン(クリック)押してる？
			if( Input.GetButtonDown( "Fire1")) {
				//撃った
				shootFlag	= true;
				
				//弾を発車する位置のボーンはある？
				if( null!=bulletStartPosition) {
					//弾を生成する位置
					Vector3 vecBulletPos	= bulletStartPosition.position;
					//進行方向にちょっと前へ
					vecBulletPos			+= (transform.rotation	*Vector3.forward);
					//Yは高さを適当に上げる
					vecBulletPos.y			= 1.0f;
					
					//弾を生成
					Instantiate( bulletObject, vecBulletPos, transform.rotation);
				}
			} else {
				//撃ってない
				shootFlag	= false;
			}
		}
		
		
		//メカニム(モーション)
		{
			//アニメーターを取得
			Animator	animator	= playerObject.GetComponent<Animator>();
			
			//Animatorで設定した値を渡す
			animator.SetFloat(	"SpeedZ",	addPosition.z);	//Z(前後の移動量)
			animator.SetBool(	"Shoot",	shootFlag);		//射撃フラグ
		}
	}
	
	
	
	
}
