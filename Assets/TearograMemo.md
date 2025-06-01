# 開発リスト
 - NextPosMarker

# Z
 - 0 : Creature
 - 1 : AroShadow


# フロー構造
 - FreeSkillManager
	- if[State:Free]
		- ExeFreeSkillList

 - ConbatSkillManager
	- if[state:Conbat]
		- ExeCombatSkillList
			- if(check:true)
				- [state:act]
				- yield return StartCoroutine(act)
				- [state:Conbat]
 

# Object構造
- PlayerData
	- Aros
		- Creature (Parameter,State)
			- Skills
				- CombatSkills
					- SkillParent(RequireChecker,Parameter)
						- Parameters
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