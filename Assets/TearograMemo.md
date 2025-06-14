# 開発リスト
 - aroCommond toggleの複数選択
 - aroCommond NextPosとかClick関連のスワイプとかの。

 - SkillManager統一
	- Free
		- Checker
			- IsFree && CanState(0) 
		- Actor
			- override Enter()　Add.this
			- override Exit() 空

	- Walk
		- Checker
			Free && CanState(Free,Walk) && !NextPos==unit.transform.position
		- Actor
			- override Enter() Clear → Add.this
			- override Exit() if(!NextPos==unit.transform.position){Remove.this}
			- Act()　処理　最後に座標合わせる。

	- Fetch
		- Checker
			IsFree && CanState(Free,Walk,Fetch) && Target
		- Actor
			- override Enter() Clear → Add.this
			- override Exit() if(!Target){Remove.this}
			- Act()　処理

	- Pick
		- Checker
			IsFree && CanState(Free,Walk,Fetch) && Target
		- Actor
			- override Enter() Clear → Add.this
			- override Exit() Remove.this
			- Act()　処理　
	
	- Found
		- Checker
			IsFree && CanState(Free,Walk,Fetch) && Search_Ignore && Target
		- Actor(Coroutine)
			- override Enter() Clear → Add.this
			- override Exit() Remove.this
			- override Front() 動作　→　IsAlert=true
 	
	- Lost
		- Checker
			IsCombat,IsRun && CanState(0) && !Target
		- Actor
			- override Enter() Add.this
			- override Exit() RemoveAt.this
			- override Main() 動作　→　IsAlert=false

	- Combat
		- Checker
			- IsCombat && CanState(0) && !Target
		- Actor
			- override Enter() Add.this
			- override Exit() RemoveAt.this
			- Act()　処理

	- Run
		- Checker
			- IsRun && CanState(0) && !Target
		- Actor
			- override Enter() Add.this
			- override Exit() RemoveAt.this
			- Act()　処理

	- SkillA
		- Checker
			- IsCombat && CanState(0)
		- Actor
			- override Enter() Add.this
			- override Exit() RemoveAt.this
			- Act()　処理
	- 
# Z
 - -1 : ac
 - 0 : unit
 - 1 : AroShadow




# Object構造

- BaseUnit
	- Sprite
		- Body
		- ArosSelectorIcon
		- ArosStatusIcon
	- Camp(敵か味方かの判別兼、陣営固有のオブジェクト置き場)
	- Skills
		- FreeSkills
			- ex.walk...
		- CombatSkills
			- ex.fireball...
	- CreatureItems


- PlayerData
	- Aros
		- Creature (Parameter,State)
			- Skills
				- BasicSkills
					- search
						- combat
						- run
					- walk
					- free
				- CombatSkills
					- SkillParent(RequireChecker,Parameter)
						- Mods
							- Param
							- Other
						- Actor
							- AttackCollision
							- VisualEffect
				- UnConditionalSkills
			- Camp
				- Aro
					- AroCommands
						- Free/Walk
							- NextPosMarker
						- Search/Ignore
						- Combat/Run
						- Follow/Fixed
					- Light2D
					- AroShadow
			- Items
	- Items
- InDangeonUICanvas
		- AroCommandsUI
		- ArosSelectorUI
		- MiniMapUI
		- EnemyStateUI
- StageData
	- 壁とか
	- PopPoint
- GameData
	- 階層とか

	
- BaseUnit（ここに当たり判定ColliderやUnitState.UnitParams等）
    - Visual（= 表示用）
    - Camp（陣営ごとのオブジェクト配置）
    - Skills
        - FreeSkills
        - CombatSkills
    - CreatureItems（開発はずっと先。消費アイテムやドロップアイテム）

スキルPrefabの基本構造（）
- SkillParent (ex.Fireball)←SkillParam（Modsを反映した実効値）,IRequireChecker,ISkillActore,ISkillParams（スキル毎の初期値）
	- Mods
		- Params
		- Others
	- Parts
		- AttackCollision
		- VisualSprite
