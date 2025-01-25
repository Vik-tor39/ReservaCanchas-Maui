using ReservaCanchas_Maui.Repositories;

namespace ReservaCanchas_Maui
{
    public partial class App : Application
    {
        public static CanchaRepository _canchaRepository { get; private set; }
        public static ComplejoRepository _complejoRepository { get; private set; }
        public static ReservaRepository _reservaRepository { get; private set; }
        public static UsuarioRepository _usuarioRepository { get; private set; }

        public App(CanchaRepository canchaRepository, ComplejoRepository complejoRepository, ReservaRepository reservaRepository, UsuarioRepository usuarioRepository)
        {
            InitializeComponent();

            _canchaRepository = canchaRepository;
            _complejoRepository = complejoRepository;
            _reservaRepository = reservaRepository;
            _usuarioRepository = usuarioRepository;

            MainPage = new AppShell();
        }
    }
}
