using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextControl : MonoBehaviour {

	public Text text;
	
	private enum States {bedroom_0, bedroom_1, closet, boxes, hallway, bathroom, shower, toilet, kids_bedroom, 
						guest_bed, master_bedroom, window, master_bathroom, master_closet, stairs, entryway, 
						dining_room, kitchen0, kitchen1, tv_room, living_room, shoebox, case1, end_game,
						clothes, shoot, yell, game_over};
	private States myState;



	// Use this for initialization
	void Start () {
		myState = States.bedroom_0;
	}

	bool gotGun = false;

	// Update is called once per frame
	void Update () {
		print (myState);
		print (gotGun);
		if 		(myState == States.bedroom_0) 		{bedroom_0();}
		else if (myState == States.bedroom_1)		{bedroom_1();}
		else if (myState == States.closet)			{closet();}
		else if (myState == States.boxes)			{boxes();}
		else if (myState == States.hallway)			{hallway();}
		else if (myState == States.bathroom)		{bathroom();}
		else if (myState == States.shower)			{shower();}
		else if (myState == States.toilet)			{toilet();}
		else if (myState == States.kids_bedroom)	{kids_bedroom();}
		else if (myState == States.guest_bed)		{guest_bed();}
		else if (myState == States.master_bedroom)	{master_bedroom();}
		else if (myState == States.window)			{window();}
		else if (myState == States.master_bathroom)	{master_bathroom();}
		else if (myState == States.master_closet)	{master_closet();}
		else if (myState == States.shoebox)			{shoebox();}
		else if (myState == States.case1)			{case1();}
		else if (myState == States.clothes)			{clothes();}
		else if (myState == States.entryway)		{entryway();}
		else if (myState == States.dining_room)		{dining_room();}
		else if (myState == States.kitchen0)		{kitchen0();}
		else if (myState == States.kitchen1)		{kitchen1();}
		else if (myState == States.tv_room)			{tv_room();}
		else if (myState == States.living_room)		{living_room();}
		else if (myState == States.shoot)			{shoot();}
		else if (myState == States.yell)			{yell();}
		else if (myState == States.game_over)		{game_over();}
		else if (myState == States.end_game)		{end_game();}
	}

	void end_game () {
		text.text = "You explain that you're housesitting for Chris. She says she's Chris's girlfriend " +
					"and stopped by to surprise him, but since he hasn't made her a key yet, she came in " +
					"through the window. She's very sorry. This was all a false alarm!\n\n" +
					"Everybody is okay, so YOU WIN!\n\n" +
					"P to Play again";
		if 		(Input.GetKeyDown(KeyCode.P))	{myState = States.bedroom_0;}
	}

	void game_over () {
		text.text = "That didn't end as you'd hoped.\n\n" +
					"GAME OVER\n\n" +
					"P to Play again";
		if 		(Input.GetKeyDown(KeyCode.P)) {gotGun = false ; myState = States.bedroom_0;}
	}

	void yell () {
		text.text = "You yell FREEZE!\nYou're slightly startled by the respone... It's a female voice, and she " +
					"sounds terrified. You click the lights on and find a pretty blonde girl, scared " +
					"and sobbing. Through her tears she cries WHO ARE YOU?\n\n" +
					"A to Answer her";
		if 		(Input.GetKeyDown(KeyCode.A)) {myState = States.end_game;}
	}

	void shoot () {
		text.text = "You raise the shotgun and pull the trigger.\nKABOOM!!!\nThe gun explodes and the " +
					"shadowy figure falls. You turn the lights on and OH NO!! The dead intruder is a " +
					"pretty blonde girl! Your guts begin to wretch as you realize you didn't shoot " +
					"a burglar, but a girl that came to visit Chris after hours.\n\nIf only you'd checked " +
					"before shooting...\n\n" +
					"N for Next";
		if (Input.GetKeyDown(KeyCode.N)) {myState = States.game_over;}
	}

	void kitchen1 () {
		if 		(gotGun == true)	{
			text.text = "You enter the kitchen and notice a dim light coming from the room on the opposite " +
						"side of the kitchen. You're just barely able to see the shadowy outline of the " +
						"intruder! Desn't seem like they've seen you...\n\n" +
						"S to Shoot the intruder\nY to Yell at the intruder";
			if 		(Input.GetKeyDown(KeyCode.S))	{myState = States.shoot;}
			else if (Input.GetKeyDown(KeyCode.Y))	{myState = States.yell;}
					}
		else if (gotGun == false)	{
			text.text = "You enter the kitchen and notice that there is a light coming from the room on " +
						"the opposite side of the kitchen. This provides just enough light to see the shadowy outline " +
						"of the intruder! They don't seem to see you...\n\n" +
						"Y to Yell at the intruder\nD to enter the Dining room";
			if 		(Input.GetKeyDown(KeyCode.D))	{myState = States.dining_room;}
			else if (Input.GetKeyDown(KeyCode.Y))	{myState = States.yell;}
		}
	}

	void kitchen0 () {
		if 		(gotGun == true)	{
			text.text = "You struggle to see in the dark after being in the light of the TV room, so you " +
						"lower your gun and rub your eyes. Just as you do, you feel a sharp knife PLUNGE " +
						"into your chest! You exhale lightly as your legs give out.\n\nGuess the burglar " +
						"saw your gun and struck first...\n\n" +
						"N for Next";
			if (Input.GetKeyDown(KeyCode.N)) {gotGun = false; myState = States.game_over;}
		}
		else if (gotGun == false){
			text.text = "Your eyes struggle to adjust to the dark, so you rub them. Just as you do, you " +
						"hear someone scream! Frightened, you find the light switch and turn the " +
						"light on! It's a pretty blonde girl holding a knife! She looks just as " +
						"terrified as you are. Holding the knife up, she asks WHO ARE YOU?.\n\n" +
						"A to Answer her";
			if (Input.GetKeyDown(KeyCode.A)) {myState = States.end_game;}
		}
	}

	void tv_room () {
		text.text = "The TV room is brightly lit by the television, which was not on when you went to bed! " +
					"Your eyes take a moment to adjust. You think to turn it off, but then you hear a strange " +
					"noise! A passage leads into the darkened kitchen and another into the living room.\n\n" +
					"K to enter the Kitchen\nL to enter the Living room";
		if 		(Input.GetKeyDown(KeyCode.K))	{myState = States.kitchen0;}
		else if (Input.GetKeyDown(KeyCode.L))	{myState = States.living_room;}
	}

	void living_room () {
		text.text = "The living room is empty, however the side window is wide open! A soft breeze moves " +
					"the curtains. A passage leads into the entryway and another into the TV room, where " +
					"a light seems to be on.\n\n" +
					"T for TV room\nE for Entryway";
		if 		(Input.GetKeyDown(KeyCode.T))	{myState = States.tv_room;}
		else if (Input.GetKeyDown(KeyCode.E))	{myState = States.entryway;}
	}

	void dining_room () {
		text.text = "The dining room is empty. The long dining table is set, as if company is expected. " +
					"You notice one napkin has fallen onto the ground. There is a door way leading " +
					"into the kitchen. And you think... that smell... some sort of perfume?\n\n" +
					"K for Kithen\nE for Entryway";
		if 		(Input.GetKeyDown(KeyCode.K))	{myState = States.kitchen1;}
		else if (Input.GetKeyDown(KeyCode.E))	{myState = States.entryway;}
	}

	void entryway () {
		text.text = "You slowly creep down the stairs into the entryway. It's VERY dark and you can " +
					"barely see anything. There is a passage into the living room and another leading " +
					"into the dining room.\n\n" +
					"L for Living room\nD for Dining Room\nU for Up the stairs";
		if 		(Input.GetKeyDown(KeyCode.L))	{myState = States.living_room;}
		else if (Input.GetKeyDown(KeyCode.D))	{myState = States.dining_room;}
		else if (Input.GetKeyDown(KeyCode.U))	{myState = States.hallway;}
	}

	void clothes () {
		text.text = "You part the clothes and find yourself staring at a shotgun! Thank god your " +
					"Chris believes in home security. Its even loaded for you.\n\n" +
					"T to Take the SHOTGUN\nR to Return to the master closet";
		if 		(Input.GetKeyDown(KeyCode.T))	{gotGun = true; myState = States.master_closet;}
		else if (Input.GetKeyDown(KeyCode.R))	{myState = States.master_closet;}
	}

	void case1 () {
		text.text = "You unlock the case and open the lid. You find a and expired passport and " +
					"a renewal application. Hmm. Strange.\n\n" +
					"R to Return to the master closet";
		if 		(Input.GetKeyDown(KeyCode.R))	{myState = States.master_closet;}
	}

	void shoebox () {
		text.text = "You open the shoebox to find several Polaroids of a pretty blonde girl you " +
					"do not recognize. They are VERY personal photos. You put them back.\n\n" +
					"R to Return to the master closet";
		if 		(Input.GetKeyDown(KeyCode.R))	{myState = States.master_closet;}
	}

	void master_closet () {
		text.text = "The master closet smells like moth balls. It reminds you of your grandmother's " +
					"house. There is a shoebox on the ground, a case, and a something behind the " +
					"hanging clothes.\n\n" +
					"S to open the Shoebox\nC to check the Case\nM to Move the clothes\n" +
					"B to enter the master Bathroom";
		if 		(Input.GetKeyDown(KeyCode.S))	{myState = States.shoebox;}
		else if (Input.GetKeyDown(KeyCode.C))	{myState = States.case1;}
		else if (Input.GetKeyDown(KeyCode.M))	{myState = States.clothes;}
		else if (Input.GetKeyDown(KeyCode.B))	{myState = States.master_bathroom;}
	}

	void master_bathroom () {
		text.text = "The master bathroom is large and smells slightly damp. Someone needs to " +
					"clean to clean this place. There is a shower with a glass door, which is empty, " +
					"and a door leading into what you assume is the master closet.\n\n" +
					"C to open the Closet\nM to enter the Master bedroom";
		if 		(Input.GetKeyDown(KeyCode.C))	{myState = States.master_closet;}
		else if (Input.GetKeyDown(KeyCode.M))	{myState = States.master_bedroom;}
	}

	void window () {
		text.text = "You look out the window and see there is dark car parked in front of the " +
					"house. The burglar must have come in the window directly below this room!\n\n" +
					"R to Return to the master bedroom";
		if 		(Input.GetKeyDown(KeyCode.R))	{myState = States.master_bedroom;}
	}

	void master_bedroom () {
		text.text = "You enter the spacious master bedroom. You see pictures of Chris and his family " +
					"sitting on the dressar with a large mirror. The sheets on the bed are messy. The " +
					"window is open a little, letting a hint of a breeze in. A doorway leads to the " +
					"master bathoom.\n\n" +
					"W to check the Window\nB to enter the master Bathroom\nH to enter the Hallway";
		if 		(Input.GetKeyDown(KeyCode.W))	{myState = States.window;}
		else if (Input.GetKeyDown(KeyCode.B))	{myState = States.master_bathroom;}
		else if (Input.GetKeyDown(KeyCode.H))	{myState = States.hallway;}
	}

	void guest_bed () {
		text.text = "You croutch next to the bed and quickly drop down to your hands to surprise " +
					"any burglur that might be hiding underneath. You GASP as you meet the gaze " +
					"of a shining pair of eyes! Wait... it's only a cat. WHEW!\n\n" +
					"R to Return to the guest bedroom";
		if 		(Input.GetKeyDown(KeyCode.R))	{myState = States.kids_bedroom;}
	}

	void kids_bedroom () {
		text.text = "Your heart skips a beat as you enter the kid's bedroom. The closet door is " +
					"open, revealing nothing of interest. However, the bed is elevated, making you" +
					"suspicious that there could be someone hiding underneath it.\n\n" +
					"B to look under the Bed\nH to enter the Hallway";
		if 		(Input.GetKeyDown(KeyCode.B))	{myState = States.guest_bed;}
		else if (Input.GetKeyDown(KeyCode.H))	{myState = States.hallway;}
	}


	void shower () {
		text.text = "You cautiously approach the closed shower... You quietly grab the edge " +
					" of the curtain... Then throw the curtain open!! " +
					"There is nothing here. Just an empty shower.\n\n" +
					"R to Return to the bathroom";
		if 		(Input.GetKeyDown(KeyCode.R))	{myState = States.bathroom;}
	}

	void toilet () {
		text.text = "You close the toilet bowl lid. You are now safe from falling in.\n\n" +
					"R to Return to the bathroom";
		if 		(Input.GetKeyDown(KeyCode.R))	{myState = States.bathroom;}
	}

	void bathroom () {
		text.text = "The bathroom looks normal. There are clothes on the floor, the shower " +
					"curtain is closed, and someone left the toilet seat up.\n\n" +
					"S to open the Shower curtain\nT to close the Toilet\nH to enter the Hallway";
		if 		(Input.GetKeyDown(KeyCode.S))	{myState = States.shower;}
		else if (Input.GetKeyDown(KeyCode.T))	{myState = States.toilet;}
		else if (Input.GetKeyDown(KeyCode.H))	{myState = States.hallway;}
	}

	void hallway () {
		text.text = "The hallway is dark and quiet. You don't dare turn the light on. " +
					"There are several doors, leading to the guest bedroom, the bathroom, " +
					"your bedroom, and the master bedroom. There are also stairs leading " +
					"to the main level.\n\n" +
					"G to enter the Guest room\nK to enter the Kid's room\nB to enter the Bathroom\n" +
					"M to enter the Master bedroom\nD to go Down the stairs";
		if 		(Input.GetKeyDown(KeyCode.G))	{myState = States.bedroom_1;}
		else if (Input.GetKeyDown(KeyCode.K))	{myState = States.kids_bedroom;}
		else if (Input.GetKeyDown(KeyCode.B))	{myState = States.bathroom;}
		else if (Input.GetKeyDown(KeyCode.M))	{myState = States.master_bedroom;}
		else if (Input.GetKeyDown(KeyCode.D))	{myState = States.entryway;}
	}

	void bedroom_1 () {
		text.text = "You're standing in the spare bedroom of your friend's house. There " +
					"is still an intruder on the loose! What are you going to do?\n\n" +
					"C to open the Closet\nH to enter the Hallway";
		if 		(Input.GetKeyDown(KeyCode.C))	{myState = States.closet;}
		else if (Input.GetKeyDown(KeyCode.H))	{myState = States.hallway;}
	}

	void boxes () {
		text.text = "You quickly rummage through the boxes, but only find clothes, some " +
					"old toys, and cassette tapes.\n\n" +
					"R to Return to the bedroom";
		if 		(Input.GetKeyDown(KeyCode.R))	{myState = States.bedroom_1;}
	}

	void closet () {
		text.text = "You open the closet door only to find it overflowing with clothes and " +
					"boxes. There's no way you can hide in here, but maybe there's " +
					"something in the boxes?\n\n" +
					"B to check the Boxes\nR to Return to the bedroom";
		if 		(Input.GetKeyDown(KeyCode.B)) 	{myState = States.boxes;}
		else if (Input.GetKeyDown(KeyCode.R)) 	{myState = States.bedroom_1;}
	}


	void bedroom_0 () {
		text.text = "You are housesitting for your friend, Chris, on a quiet Sunday evening. After " +
					"falling asleep in a spare bedroom, you are awoken by the beeping of the alarm. " +
					"You can faintly hear a window open. Someone is breaking into the house!\n\n" +
					"C to open the Closet\nH to enter the Hallway";
		if 		(Input.GetKeyDown(KeyCode.C)) 	{myState = States.closet;}
		else if (Input.GetKeyDown(KeyCode.H)) 	{myState = States.hallway;}
	}

}