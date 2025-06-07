# 開発リスト
 - aroCommond toggleの複数選択
 - foundのビックリ演出。というよりCombatとRunの演出。
 - BasicSkillsもAdvanceSkillsと一緒にSkillManagerで回す。
	- Free
		- Checker
			- !isAlert
			- !Walk_Free
		- Actor
			- なし

	- Walk
		- Checker
			- !isAlert
			- Walk_Free
		- Actor
			- override Execute()
			- override Enter()
			- Act()
	
	- Found
		- Checker
			- !isAlert
			- Search_Ignore
			- Target == true
		- Actor
			- Exit
				- isAlert = true
	
	- Combat
		- Checker
			- isAlert
			- Combat_Run
			
		- Actor
			- override Execute()
				- !Target{isAlert=false}
	- Run
		- Checker
			- isAlert
			- !Combat_Run
			- Target == true
		- Actor
			- override Execute()
				- !Target{isAlert=false}
# Z
 - 0 : Creature
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
