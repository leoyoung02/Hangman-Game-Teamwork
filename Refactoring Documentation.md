**17.08.2015**
  1.    Implemented singleton pattern for scoreboard to prevent the possibility of whiping it clean during initialization.
  2.    Implemented Implemented command pattern for all user commands.
  3.    Deduplicated the calling of the PrintInvalidEntryMessage method.
  4.    Decoupled GameEngine and Game
**18.08.2015**
  1.	Moving properties before methods in Scoreboard class.
  2.	Removing empty lines in Scoreboard class.
  3.	All using directives are placed inside of the namespace in Engine class.
  4.	All private properties are placed after all internal properties in Engine class.
  5.	Added “this.” to scoreboard to indicate the intended method call: lines: 87, 141
  6.	Added “this.” to PrintInvalidEntryMessage to indicate the intended method call: lines: 150

**25.08.2015**
  7.	Class Validator created.
  8.	Check player name method created. (replace validation in scoreboard).
  9.	Check input command method created. (replace validation in scoreboard).
  
**26.08.2015**
  10. Validator.Tests created.
  11. Added [assembly: InternalsVisibleTo("Hangman.Test")] on Validator class to be visible for tests.
  12. Tests for Validator implemented.
	
