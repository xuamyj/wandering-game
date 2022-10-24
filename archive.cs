  // static void quickTestIsPickupable(Placeable placeable) {
  //   Console.Write(placeable.name + " : Pickupable : ");
  //   Console.Write(placeable is IPickupable ? "YES" : "no");
  //   Console.WriteLine();
  // }
  
  // static void quickTestIsBlocking(Placeable placeable) {
  //   Console.Write(placeable.name + " : Blocking : ");
  //   Console.Write(placeable is IBlocking ? "YES" : "no");
  //   Console.WriteLine();
  // }
  
  // static void quickTest() {  
  //   Wall wall1 = new Wall(new Coord(0,2));
  //   Wall wall2 = new Wall(new Coord(1,2));
  //   Wall wall3 = new Wall(new Coord(2,2));
  //   Wall wall4 = new Wall(new Coord(3,2));

  //   Item flower = new Item(new Coord(2,5), "flower");
  //   Item diamond = new Item(new Coord(4,2), "diamond");
  //   Item cat = new Item(new Coord(1,1), "cat");

  //   Person mc = new Person(new Coord(0,4));

  //   List<Placeable> things = new List<Placeable>{
  //     wall1,
  //     wall2,
  //     wall3,
  //     wall4,
  //     flower,
  //     diamond,
  //     cat,
  //     mc
  //   };

  //   foreach (Placeable thing in things) {
  //     quickTestIsPickupable(thing);
  //   }
  //   Console.WriteLine();
    
  //   foreach (Placeable thing in things) {
  //     quickTestIsBlocking(thing);
  //   }
  //   Console.WriteLine();

  //   Console.WriteLine("Person has..");
  //   Console.WriteLine("Position: " + mc.position);
  //   Console.WriteLine("Name: " + mc.name);
  //   Console.WriteLine("Symbol: " + mc.symbol);
  //   Console.WriteLine("Priority: " + mc.priority);
  //   Console.WriteLine();
    
  //   Console.WriteLine("Person moves..");
  //   Console.WriteLine("Left: " + mc.getCoordForMoveLeft());
  //   Console.WriteLine("Right: " + mc.getCoordForMoveRight());
  //   Console.WriteLine("Up: " + mc.getCoordForMoveUp());
  //   Console.WriteLine("Down: " + mc.getCoordForMoveDown());
  //   Console.WriteLine();
  // }








  // --------

  // static bool MoveForward() {
  //   Console.WriteLine("You move forward.");
  //   return true;
  // }

  // static bool MoveLeft() {
  //   Console.WriteLine("You move left.");
  //   return true;
  // }

  // static bool MoveBackward() {
  //   Console.WriteLine("You move backward.");
  //   return true;
  // }

  // static bool MoveRight() {
  //   Console.WriteLine("You move right.");
  //   return true;
  // }

  // static bool PickUpItem() {
  //   Console.WriteLine("You try to pick up an item.");
  //   return true;
  // }