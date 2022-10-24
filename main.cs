using System;
using System.Collections.Generic;

class Program {

  static string ReadLineHelper() {
    Console.Write(": ");
    return Console.ReadLine();
  }
  
  //----

  static void GiveInstructions() {
    Console.WriteLine("Enter one of the following:");
    Console.WriteLine("(w) Move up");
    Console.WriteLine("(a) Move left");
    Console.WriteLine("(s) Move down");
    Console.WriteLine("(d) Move right");
    Console.WriteLine("(f) Pick up item");
    Console.WriteLine("(z) Quit game\n");
  }

  //----

  static string RunTurn(int turn, Board board) {
    Console.WriteLine($"\nTurn {turn}");

    board.printBoard();
    
    GiveInstructions();
    string choice = ReadLineHelper();

    switch (choice) {
      case "w":
        if (board.tryMoveUp()) {
          Console.WriteLine("You move up.");
        } else {
          Console.WriteLine("Sorry, you can't move there.");
        }
        break;
      case "a":
        if (board.tryMoveLeft()) {
          Console.WriteLine("You move left.");
        } else {
          Console.WriteLine("Sorry, you can't move there.");
        }
        break;
      case "s":
        if (board.tryMoveDown()) {
          Console.WriteLine("You move down.");
        } else {
          Console.WriteLine("Sorry, you can't move there.");
        }
        break;
      case "d":
        if (board.tryMoveRight()) {
          Console.WriteLine("You move right.");
        } else {
          Console.WriteLine("Sorry, you can't move there.");
        }
        break;
      case "f":
        board.tryPickupItem();
        break;
      case "z":
        break;
      default:
        Console.WriteLine("Please choose 'w', 'a', 's', 'd', 'f', or 'z'.");
        break;
    }
    return choice;
  }

  static bool CheckQuit() {
    Console.WriteLine("Are you sure you want to quit? (y/n)");
    string yesOrNo = ReadLineHelper();
    return yesOrNo == "y" ? true : false;
  }

  //----

  static void Main(string[] args) {
    Wall wall1 = new Wall(new Coord(0,2));
    Wall wall2 = new Wall(new Coord(1,2));
    Wall wall3 = new Wall(new Coord(2,2));
    Wall wall4 = new Wall(new Coord(3,2));

    Item flower = new Item(new Coord(2,5), "flower");
    Item diamond = new Item(new Coord(4,2), "diamond");
    Item cat = new Item(new Coord(1,1), "cat");

    List<Placeable> things = new List<Placeable>{
      wall1,
      wall2,
      wall3,
      wall4,
      flower,
      diamond,
      cat,
    };
    
    Board board = new Board(5, 6, new Coord(0,4));

    foreach (Placeable thing in things) {
      board.thingsOnBoard.Add(thing.position, thing);
    }

    // board.printBoard();

    //----
    
    // quickTest();
    
    //----
    
    for (int turn = 1; turn < 100; turn++) {
      string choice = RunTurn(turn, board);
      if (choice == "z" && CheckQuit()) {
        break;
      }
    }
    
    Console.WriteLine("\nOkay, thanks for playing!\n");
  }
}
