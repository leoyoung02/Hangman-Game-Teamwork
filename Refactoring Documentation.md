**17.08.2015**
  1.    Implemented singleton pattern for scoreboard to prevent the possibility of whiping it clean during initialization.
  2.    Implemented Implemented command pattern for all user commands.
  3.    Deduplicated the calling of the PrintInvalidEntryMessage method.
  4.    Decoupled GameEngine and Game
**18.08.2015**
  5.	Moving properties before methods in Scoreboard class.
  6.	Removing empty lines in Scoreboard class.
  7.	All using directives are placed inside of the namespace in Engine class.
  8.	All private properties are placed after all internal properties in Engine class.
  9.	Added “this.” to scoreboard to indicate the intended method call: lines: 87, 141
  10.	Added “this.” to PrintInvalidEntryMessage to indicate the intended method call: lines: 150

**25.08.2015**
  11.	Class Validator created.
  12.	Check player name method created. (replace validation in scoreboard).
  13.	Check input command method created. (replace validation in scoreboard).
  
**26.08.2015**
  14.   Validator.Tests created.
  15.   Added [assembly: InternalsVisibleTo("Hangman.Test")] on Validator class to be visible for tests.
  16.   Tests for Validator implemented.
  17.   Implemented abstraction for user input (IReader and ConsoleReader:IReader)
  18.   Decoupled Scoreboard from ConsolePrinter and Validator
  19.   Extracted the scoreboard file path as a constant
	
