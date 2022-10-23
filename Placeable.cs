using System;

public struct Coord {
  public int row;
  public int col;

  public Coord(int r, int c) {
    this.row = r;
    this.col = c;
  }

  public override string ToString() {
    return String.Format("row {0}, col {1}", this.row, this.col);
  }
}

interface IPickupable { }

interface IBlocking { }

public class Placeable {
  // fields
  public Coord position { get; private set; }
  public void setPosition(Coord pos) {
    this.position = pos;
  }

  public string name { get; private set; }
  public void setName(string nameParam) {
    this.name = nameParam;
  }
  
  public string symbol { get; private set; }
  public void setSymbol(string symb) {
    this.symbol = symb;
  }

  public int priority { get; private set; }
  public void setPriority(int pri) {
    this.priority = pri;
  }

  // constructor
  public Placeable(Coord pos, string nameParam, string symb, int pri) {
    this.position = pos;
    this.name = nameParam;
    this.symbol = symb;
    this.priority = pri;
  }

  // printer functions
  public void printName() {
    Console.Write(this.name);
  }
  
  public void printSymbol() {
    Console.Write(this.symbol);
  }

  // get coord functions
  public Coord getCoordForMoveLeft() {
    return new Coord(this.position.row, this.position.col-1);
  }

  public Coord getCoordForMoveRight() {
    return new Coord(this.position.row, this.position.col+1);
  }

  public Coord getCoordForMoveUp() {
    return new Coord(this.position.row-1, this.position.col);
  }

  public Coord getCoordForMoveDown() {
    return new Coord(this.position.row+1, this.position.col);
  }
}
