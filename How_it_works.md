# Streets_Of_Malice
Dungeon Crawler

Commands.cs (Where we store the methods involving user inputs and commands)
>GetCommand() Gets user commands
>CommandInput(int roomid) Processes the input from user and directs it accordingly.
>IsValidCommand(string command) Checks if input is a valid command
>IsMovement(string command) Checks if input is a movement command
>ControlMap(int roomid) To be removed, right now this displays the current room.
>ViewAll(int roomid, string[] data or List<string> data) Views data depending on the user input. Rooms, weapons, etc.
>ViewRoom(string room) Simply displays the room in all uppercase, to be changed.
>



Map.cs (Controls movement and items stored in areas around the map)
>UserMove(int roomid, string direction) Determines where the user moves depending on the direction and current room

>SwitchRoom(string Room) Changes the current room

Options.cs (Contains our pre-loaded options)
>SetRooms/Weapons/Items/Mobs() Stores current lists and arrays for the options.

Program.cs (Runs the program)

Standard_Messages.cs (Contains dialogue and messages)
