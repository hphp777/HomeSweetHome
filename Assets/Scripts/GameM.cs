using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;



/*
 *	ゲームの情報を管理するクラス
 *	Maruchu
 */
public		class		GameM				: MonoBehaviour {
	
	
	
	
	private	static		bool		m_stageClearFlag		= false;	//これが true ならステージクリアとする
	
	/*
	 *	ステージクリアしたら呼ばれる
	 */
	public	static		void		SetStageClear() {
		//ステージクリアにする
		m_stageClearFlag		= true;
		SceneManager.LoadScene("basement");
	}
	
	/*
	 *	ステージクリアしたかどうか確認
	 */
	public	static		bool		IsStageCleared() {
		//SceneManager.LoadScene("basement");
		return	m_stageClearFlag;
	}
	
	
	
	
}
