https://github.com/Jsalaz/VideoGameTesting
Hazel The Alien:

Extending LukoSek:

Oct 3rd: First commit and testing git and github with unity.
Oct 5th: Error in trying to fix one of the bugs. Was not able 
		to revert back to the original merge. 
Oct 6th: Had to clone the project from github.
	 Fixed bugs:
		1) GameOver now shows proper distance and coin ammounts
		2) LevelGenerator fixed so that Player repaws will clear old platforms
			and then spawn new platforms under the player.
		3) Fixed the bug where only one type of platform would be created
		4) Fixed bug where distance would continue to increase after death
		5) Fixed other minor bugs
	 Extending LukoSek
		1) Added a coinGen branch to git and github
		2) Added a coin generation script and gameObjects
		3) Tested making coins. Bug found, coins don't get destroyed 
			after they are created. (infinite coins)

Oct 7th: 	1) Coin Spawning bugged fixed. 
		2) Included a working coin generator and destroyer.
		3) Implemented a DoubleJump feature.

Oct 9th:	1) Completed steeady speedup
		2) EndLevel Canvas Completed
		3) Implented Scene 2
		4) Worked on Level Manager Script
		5) Added 2 level generator prefabs
		6) Implement level swicth rules (15 coins to mode to the next level)

Oct 10th:	1) Scene 2 completed
		2) Finnished compelted game canvas
		3) Fixed bugs with acumulated coins and distances not dyplaying 
			properly on canvases

Oct 11th:	1) Fixed other minor bugs
		2) Added functionality to the "up" arrow to jump
		3) Added Spikes to certain prefabs
		4) Added the README file

I wasn't sure exactlly what would count as an extension for Lukosek vs my own feature.
Therefore these are what I would consider my own features.

		1) Added DoubleJump rather than sumperjump.
		2) Added Spikes to levelPrefabs in scene 2.
		3) Added functionality to the "up" arrow to jump.
		4) Created a levelManager.cs script to manage the way data
			was tranfered between levels.
		5) Created a script that destroys objects once they are offscreen.
		6) Made the collection of coin more relevant to the game by
			implementing that to move on to the next level you need to collect
			15 coins. The rule could be extended to further levels.
		7) Added a Completed Game Canvas.

In all I think that there is no single feature that I could say is worth the extra point, but rather the implementation of all the solutions and additions to the LukoSek project.