Date:   Mon Oct 12 00:42:23 2015 +0300

*	Added tests fro Engine but only covered 7 % more
*	Fix: unit tests were not testing the ConsolePrinter. Too much mocking!
*   Only the first test is fixed!

Date:   Sun Oct 11 22:37:58 2015 +0300

  * Adding documentation files
  * Added Invalid message for user in GetUserInput()
  * added old player tests
  * 2 CommandFactory Tests now passing. Project  folder structure restored
  * Added CommandFactoryTests, HangmanGameTest, ConsolePrinterTests, WordInitializerTests, updated ClassDiagram1.cd
  * Added validation for player name, added tests for Player, existing tests migrated to NUnit
  * CommandFactory tests
  * Added validation and tests for invalid commands in CommandFactory
  * added test for scoreboard using moq
  * Added missing variable type at LoadRecords()
  * Fixed 60 stylecop mistakes. Only documentation ones left - another 24
  * Removed redundant comments
  * Flyweight pattern at Command Factory, Fixed bugged Restart, fixed bug with adding only noHelpUsed to Scoreboard
  * Logic for sorting and truncating  scoreboard entries moved from printer to scoreboard
  * Scoreboard unit test if more than 5 entries are entered (fail)
  * Removed redundant method for getting a public property from scoreboard
  * Most classes documented
  * Some documentation, some new TODO items, CommandFactory no longer needs the engine as a parameter, command in GetUserInput is declared at the last possible moment.
  * Organised folders,trying to figure out CommandContext.in progress
  * Added tests for Player, WordInitializer and ConsoleReader. From 8 to 21% code coverage

Date:   Sat Oct 10 20:21:49 2015 +0300

    * Reducing code in commands and fixing bug with display of top players
    * Detached Iprinter from Validator and Player. Fixed tests, improved const naming
    * Removed commands from Ninjector overrides factory
    * Single responsibility of method HandleVictory in HangmanEngine fixed. Fixed bug with entering already revealed letterin the same class.
    * Update HangManGameStarter.cs
    * Addded config file for Ninject
    * Implemented Ninject lib, Facade pattern and Singleton with HangManGameStarter.cs
    * Added missing GameEngine.cs file
    * Updated ClassDiagram1.cd

Date:   Fri Oct 9 23:42:49 2015 +0300

  *  moved encoding logic To Encoder.cs and decoding logig to Decoder.cs and fixed naming in the logic.
  *  Introducing Facade for file operations load and save in Scoreboard.cs through FileManagerFacade.cs
  *  Fixed issues resulting from merge conflict. Created more work for stylecop ...
  *  Created Bridge pattern/strategy/ready for Facade. Must remove ConsolePrinter dependents

Date:   Thu Oct 8 22:54:40 2015 +0300

  *  fixing some stylecop warnings. Comments and TODOs still remain.
  *  Removed redundant Console Printer
  *  Fixed bug caused by removal of WordInitializer inheritance, fixed tests dependencies
  *  Deleted redundant Test project, added permission for tests in assembly. Refactorred test names
  *  Replaced weird inheritance of WordInitializer with a WordInitializer wordInitializer property
  *  Added class diagram, a todo comment and a commented out unsuccessfull implementation for sawing the scoreboard
  *  Removed console dependency from Hangman engine. Preparing for proper bridge

Date:   Wed Oct 7 15:40:40 2015 +0300

   * Fixed Tests for Validator and sorted the last usings. Re-added ICommand.cs
   * Moved ICommand.cs to Contracts. All usings in project refactored

Date:   Mon Oct 5 16:21:05 2015 +0300

  *  Implemented memento pattern for saving the scoreboard
  *  Bugfix: The full guessed word was not shown before the victory message.
  *  Implemented printer abstraction in Top command and IEngine
  *  Dependency injection (printer) in validator)
  *  Implemented abstraction for output printer classes

Date:   Sun Oct 4 17:34:21 2015 +0300

  *  minor additions concerning .cproj file and deleting duplicating HangmanFactory class
  *  Added factory for commands. Commands are now removed From HangmanEngine

Date:   Tue Sep 29 19:38:06 2015 +0300

  *  Implementing Factory Design Pattern for Creating Games, in this Hangman Game

Date:   Mon Sep 28 23:47:50 2015 +0300

  *  dependency inversion applied to the engine of the game. Not sure if it is good idea though.

Date:   Wed Aug 26 22:45:10 2015 +0300

 *   Regressionfix: validator was not initialized
 *   Correcton in Validator.cs to recognise comands input
 *   Added validation to Player class
 *   Updated refactoring documentation
 *   Implemented abstraction for user input (IReader and ConsoleReader:IReader)
 *   Decoupled Scoreboard from ConsolePrinter and Validator
 *   Bugfix: scores were not loaded from file when the game starts.
 *   Variables should be initialized with correct data or null or default value.
 *   Extracted the scoreboard file path as a variable
 *   Updated refacrtoring documentation

Date:   Tue Aug 25 23:43:11 2015 +0300

  *  Update Refactoring Documentation.md
  *  documentation added
  *  Validator.Tests created.
  *  Added [assembly: InternalsVisibleTo("Hangman.Test")] on Validator class to be visible for tests.
  *  Tests for Validator implemented.
  *  Update Refactoring Documentation.md
  *  Rename Refactoring Documentation to Refactoring Documentation.md
  *  Create Refactoring Documentation
  *  Delete Refactoring Documentation.md
  *  Refactoriring ".md" file added
  *  1.Class Validator created.
  *  2.Check player name method created. (replace validation in scoreboard).
  *  3.Check input command method created. (replace validation in scoreboard).

Date:   Mon Aug 24 11:34:17 2015 +0300

 *  New class Player, replaced List of KeyValuePairs with List<Player>. New Sort method
 *  Fixed bug: when two or more players have the same number of mistakes, game crashes
 *  Extracted Encoder/Decoder classes and fixed bug with crashing text file operations

Date:   Sun Aug 23 22:08:40 2015 +0300

  *  Replaced string with const in Scoreboard, changed displayableWord to wordToGuess in all methods.
  *  Extracted constant game messages
  *  Changed Words to enum. Improved variable naming in WordInitializer.cs. Formatted class

Date:   Sat Aug 22 18:00:02 2015 +0300

  *  HighScore file exceptions and creation tweaks.
  *  Validation if the file was edited.
  *  Bear in mind that the file is hidden !!!
  *  Extracting printing functionality from Scoreboard.cs
  *  Detaching Game.cs from ConsolePrinter.cs
  *  Small refactor
  *  ConsolePrinter functionality completely extracted from Engine.cs. May need additional refactoring as to how to detach ConsolePrinter from Game.cs and maybe add some interface so that printer can be different than console.
  *  Creating ConsolePrinter.cs
  *  So far have extracted 5 methods from Engine.cs to ConsolePrinter.cs and
  *  made some changes in Game.cs to follow the flow of the game

Date:   Wed Aug 19 07:38:54 2015 +0300

  *  Added [assembly: InternalsVisibleTo("Hangman.Tests")] to AssemblyInfo.cs
  *  Added NUnit NuGet package
  *  Scoreboard is loading/saving his records from/to file, encoded to base64 (two passes)
	
Date:   Tue Aug 18 23:45:03 2015 +0300

  *  Reformatted the source code:
    1.	Moving properties before methods in Scoreboard class.
    2.	Removing empty lines in Scoreboard class.
    3.	All using directives are placed inside of the namespace in Engine class.
    4.	All private properties are placed after all internal properties in Engine class.
    5.	Added “this.” to scoreboard to indicate the intended method call: lines: 87, 141
    6.	Added “this.” to PrintInvalidEntryMessage to indicate the intended method call: lines: 150
  *  Added readonly modifier to inputLetter field
  *  Fixed minor StyleCop errors
  *  Commands renamed and moved to its own folder
	
Date:   Mon Aug 17 18:17:40 2015 +0300

  *  Implemented command pattern for all user commands, deduplicated the calling of the PrintInvalidEntryMessage method.
  *  Implemented singleton pattern in Scoreboard
  *  Bugfix: the scoreboard was whiped clean on each restart. The scoreboard is now initialized as a static variable in game engine
  *  Added basic inheritance
	
Date:   Sun Aug 16 10:04:43 2015 +0300

  *  Names are improved, optimizations are made
  *  Added colors
  *  Naming improved
  *  Method PlayOneGame() extracted to separate class NewGame.cs and renamed to Play()
  *  Main method extracted to empty class
  *  Changed words db to enum
  *  Optimized properties of project files
	
Date:   Thu Aug 13 00:29:52 2015 +0300

 *   Solution separated as follows:
 *   Hangman.Logic
 *   Hangman.Tests
 *   Hangman.UI
	
Date:   Wed Aug 12 23:54:54 2015 +0300

  *  Code is modified to comply with the rules of StyleCop
  *  Folder hierarchy is changed to match the task conditions
	
Date:   Mon Jul 13 05:20:39 2015 +0300

  *  Initial commit
