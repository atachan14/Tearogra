# 開発リスト
 - aroListリファクタ
	- [aroList] Selector → AroManager
	- [aroId] uParams → unit
	- [FloorSetup] FloorManager → PlayerData → AroManager → Selector → 他


# Z
 - -1 : ac
 - 0 : unit
 - 1 : AroShadow

# orderInLayer
- -100 : bg
- -1 : item
- 0 : default



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
		- BaseUnit (Parameter,State)
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
				- UnConditionalSkills
			- Camp
				- Aro
					- NextPosMarker
					- Light2D
					- AroShadow
			- UnitItems
	- PlayerItems
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

	

スキルPrefabの基本構造（）
- SkillParent (ex.Fireball)←SkillParam（Modsを反映した実効値）,IRequireChecker,ISkillActore,ISkillParams（スキル毎の初期値）
	- Mods
		- Params
		- Others
	- Parts
		- AttackCollision
		- VisualSprite
