# Bubble-Befuddle

[Online Demo](http://raycoti.com/index.php/2016/09/15/bubble-befuddle-demo/)
# Table of Contents
[Gameplay](#gameplay)

[Main Scripts](#scripts)

<a name ="gameplay"/>
## Gameplay 
 Players pick between purple and blue teams and must pop bubbles according to their team color, any bubble that hits a wall will result in their teams water level rising. Popping certain amounts of bubbles will result in gaining power-ups such as a puffer fish that you can fling at your opponents bubbles to make their water level rise faster or a sponge you can drag that lowers the water level of the bubble’s corresponding color.  Being up close to the screen added the challenge of limited scope which heightens the intensity, physical strategies exist as well as players are moving around each other and could box each other out
 
 <a name ="scripts"/>
## Main Scripts 

###[Ball.cs](https://github.com/raycoti/Bubble-Befuddle/blob/master/Assets/Scripts/Ball.cs)
This handles the many ways a bubble can pop and how that affects the game. This is done by using colliders and the function OncollisionEnter2d. We check for the tag of the object that hit the bubble and define what happens as a result. Adding new items is done simply by creating a new prefab giving it a tag and defining what happens when that item collides with the bubble. At the end a new gameobject is called which handles the popping animations. Right now it passes a boolean of 'good', but it can be changed to pass integers to implement more animations.  

###[BubbleGenerator.cs](https://github.com/raycoti/Bubble-Befuddle/blob/master/Assets/Scripts/BubbleGenerator.cs)
This handles the main game for player one. It handles how often and where bubbles spawn and the requirments for getting powerups. Ballgenerator.cs was a test for generating bubbles in general, bubblegeneartor2.cs controlls things for player2.  
###[popstuff.cs](https://github.com/raycoti/Bubble-Befuddle/blob/master/Assets/Scripts/popstuff.cs)
This is a timed gameobject that changes sprites overtime and eventually destroys itself. The boolean of 'good' is passed when true a plus one is displayed, when it is false a minus one is displayed. As mentioned before you can instead pass integers to index into an array of final display images instead. 

###[all scripts here](https://github.com/raycoti/Bubble-Befuddle/tree/master/Assets/Scripts)
