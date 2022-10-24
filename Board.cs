using System;
using System.Collections.Generic;
using System.Linq;

// priorities: 0=person, 1=item, 2=wall
// lower priority = higher priority (0=person should always be showing)

public class Wall : Placeable, IBlocking {
  // constructor
  public Wall(Coord pos, string nameParam="wall", string symb="#", int pri=2) : base(pos, nameParam, symb, pri) { }
}

public class Item : Placeable, IPickupable {
  // constructor
  public Item(Coord pos, string nameParam, string symb="?", int pri=1) : base(pos, nameParam, symb, pri) { }
}

public class Person : Placeable {
  // constructor
  public Person(Coord pos, string nameParam="person", string symb="o", int pri=0) : base(pos, nameParam, symb, pri) { }
}

public class Board {
  // fields
  public int numRows { get; private set; }
  public void setnumRows(int numR) {
    this.numRows = numR;
  }
  public int numCols { get; private set; }
  public void setnumCols(int numC) {
    this.numCols = numC;
  }

  public Person mc { get; private set; }
  
  public MultiValueDictionary<Coord, Placeable> thingsOnBoard { get; private set; }

  // constructor
  public Board(int numR, int numC, Coord mcPos) {
    this.numRows = numR;
    this.numCols = numC;

    this.mc = new Person(mcPos);
    
    this.thingsOnBoard = new MultiValueDictionary<Coord, Placeable>();
    this.thingsOnBoard.Add(mcPos, this.mc);
  }

  // helper functions

  private bool isBlocking(Coord pos) {
    Placeable blockingThing = null;
    if (this.thingsOnBoard.TryGetValue(pos, out var thingsOnSquare)) {
      foreach (Placeable thing in thingsOnSquare) {
        if (thing is IBlocking) {
          blockingThing = thing;
        }
      }
    }
    return (blockingThing != null);
  }
  
  // return False if the move is not valid
  // return True and change position if it is
  private bool tryMoveToCoord(Coord pos) {
    if (pos.row < 0 || pos.row >= this.numRows || 
       pos.col < 0 || pos.col >= this.numCols) { // out of bounds
      return false; 
    } else if (isBlocking(pos)) { // blocking
      return false;
    } else {
      this.thingsOnBoard.Remove(this.mc.position, this.mc);
      
      this.mc.setPosition(pos);
      this.thingsOnBoard.Add(pos, this.mc);
      
      return true; 
    }
  }

  private void printBorder() {
    Console.Write(" +");
    for (int i = 0; i < this.numCols; i++) {
      Console.Write(" -");
    }
    Console.WriteLine(" +");
  }

  private void printSquare(Coord pos) {
    if (this.thingsOnBoard.TryGetValue(pos, out var thingsOnSquare)) {
      
      // i know, i'm sorry
      Placeable toDisplayThing = null;
      foreach (Placeable thing in thingsOnSquare) {
        if (toDisplayThing == null || thing.priority < toDisplayThing.priority) {
          toDisplayThing = thing;
        }
      }
      
      Console.Write(" " + toDisplayThing.symbol);
    } else {
      Console.Write("  ");
    }
  }

  // real functions

  // return False if the move is not valid
  // return True and change position if it is
  public bool tryPickupItem() {
    Coord currPos = this.mc.position;

    Placeable toPickupThing = null;
    if (this.thingsOnBoard.TryGetValue(currPos, out var thingsOnSquare)) {
      foreach (Placeable thing in thingsOnSquare) {
        if (thing is IPickupable) {
          toPickupThing = thing;
        }
      }
    }

    if (toPickupThing == null) {
      Console.WriteLine("Sorry, there's nothing to pick up.");
      
      return false;
    } else {
      Console.WriteLine("You picked up a " + toPickupThing.name + "!");

      this.thingsOnBoard.Remove(currPos, toPickupThing);
      return true; 
    }
  }

  public bool tryMoveLeft() {
    Coord left = this.mc.getCoordForMoveLeft();
    return this.tryMoveToCoord(left);
  }

  public bool tryMoveRight() {
    Coord right = this.mc.getCoordForMoveRight();
    return this.tryMoveToCoord(right);
  }

  public bool tryMoveUp() {
    Coord Up = this.mc.getCoordForMoveUp();
    return this.tryMoveToCoord(Up);
  }

  public bool tryMoveDown() {
    Coord Down = this.mc.getCoordForMoveDown();
    return this.tryMoveToCoord(Down);
  }

  public void printBoard() {
    for (int row = -1; row < this.numRows + 1; row++) {
      if (row < 0 || row == numRows) { // border
        this.printBorder();
      } else { // regular row
        for (int col = -1; col < this.numCols + 1; col++) {
          if (col < 0) {
            Console.Write(" |");
          } else if (col == numCols) {
            Console.WriteLine(" |");
          } else {
            this.printSquare(new Coord(row, col));
          }
          
        } // end for
      }
      
    } // end for
  } 
}
