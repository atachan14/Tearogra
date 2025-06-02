# 開発リスト
 - NextPosMarker

# Z
 - 0 : Creature
 - 1 : AroShadow


# フロー構造
 - FreeSkillManager
	- if[State:Free]
		- ExeFreeSkillList

 - CombatSkillManager
	- if[state:Combat]
		- ExeCombatSkillList
			- if(check:true)
				- exe
					- enter() [state:this]
					- yield return StartCoroutine(act)
					- exit() [state:ex.lastSkill]
 

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