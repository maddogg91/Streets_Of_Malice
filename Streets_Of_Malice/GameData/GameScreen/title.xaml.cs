using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using OptionsLibrary;
using CharacterLibrary;
using InterfaceLibrary;



namespace GameScreen
{
    /// <summary>
    /// Interaction logic for title.xaml
    /// </summary>
    public partial class Title : Window
    {
        public Title()
        {
            InitializeComponent();
        }

        private void NewButton_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Player player = GameOptions.NewPlayer();
            GameOptions.CreateUserOptions(player.Name);
            GameObjects options = LoadOptions.InitializeObjects(player);
            MessageBox.Show(StandardMessages.TitleCard());

            Rooms room = GameOptions.MakeRoom(options.Rooms, options.Player.RoomID);
            SearchCommands.ViewRoom(room.Name);

            GeneralCommands.CommandInput(options);
        }

        private void LoadButton_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            GameObjects options = LoadOptions.LoadObjects(" ");
            Rooms room = GameOptions.MakeRoom(options.Rooms, options.Player.RoomID);
            SearchCommands.ViewRoom(room.Name);

            GeneralCommands.CommandInput(options);
        }
    }
}
