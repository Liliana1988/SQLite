﻿using SQLite.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SQLite
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        //variable de conexion
        private SQLiteAsyncConnection _conn;
        public Login()
        {
            InitializeComponent();
            _conn = DependencyService.Get<Database>().GetConecction();

        }

        public static IEnumerable<Estudiante> SELECT_WHERE(SQLiteConnection db, string usuario, string contrasena){
            return db.Query<Estudiante>("SELECT * FROM Estudiante where Usuario= ? and Contrasena = ?", usuario, contrasena);



        }


        private void btnRegistro_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Registro());
        }

        private void btnLogin_Clicked(object sender, EventArgs e)
        {
            try
            {
                var datasepath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),"uisrael.db3");
                var db = new SQLiteConnection(datasepath);
                db.CreateTable<Estudiante>();
                IEnumerable<Estudiante> resultado = SELECT_WHERE(db, txtUsuario.Text, txtContrasena.Text);
                if(resultado.Count() > 0)
                {
                    Navigation.PushAsync(new ConsultaRegistro());

                }
                else
                {
                    DisplayAlert("Alerta", "Datos erroneos", "ok");
                }
            }
            
            catch (Exception ex)
                {
                DisplayAlert("Alerta", ex.Message, "ok");
            }

        }
    }
}