﻿using ReservaCanchasApp.Repositories;

namespace ReservaCanchasApp
{
    public partial class App : Application
    {
        public static CanchaRepository? _canchaRepository { get; private set; }
        public static ComplejoRepository? _complejoRepository { get; private set; }
        public static ReservaRepository? _reservaRepository { get; private set; }
        public static UsuarioRepository? _usuarioRepository { get; private set; }

        public App(CanchaRepository canchaRepository, ComplejoRepository complejoRepository, ReservaRepository reservaRepository, UsuarioRepository usuarioRepository)
        {
            InitializeComponent();
            MainPage = new AppShell();

            _canchaRepository = canchaRepository ?? throw new ArgumentNullException(nameof(canchaRepository));
            _complejoRepository = complejoRepository ?? throw new ArgumentNullException(nameof(complejoRepository));
            _reservaRepository = reservaRepository ?? throw new ArgumentNullException(nameof(reservaRepository));
            _usuarioRepository = usuarioRepository ?? throw new ArgumentNullException(nameof(usuarioRepository));

        }
    }
}
