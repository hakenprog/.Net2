using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplication4.Models
{
    public class UsuarioModel
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int NumTelf { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }

        public static List<UsuarioModel> consultar()
        {
            var conexion = new SqlConnection(@"Data Source=taxiserve.database.windows.net;Initial Catalog=dbMVC;User ID=hakenprog;Password=605312653Dd.;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            conexion.Open();
            List<UsuarioModel> listModel = new List<UsuarioModel>();
            string sql = "SELECT Nombre, Apellido, NumTelf, Marca, Modelo FROM usuarios inner join " +
                "empleados on empleados.id_Usuario = usuarios.id_Usuario inner join conductors on conductors.id_Empleado = empleados.id_Empleado " +
                "inner join Taxis on taxis.id_Conductor = conductors.id_Conductor";

            SqlCommand command = new SqlCommand(sql, conexion);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                UsuarioModel user = new UsuarioModel();
                user.Nombre = reader.GetString(0);
                user.Apellido = reader.GetString(1);
                user.NumTelf = reader.GetInt32(2);
                user.Marca = reader.GetString(3);
                user.Modelo = reader.GetString(4);


                listModel.Add(user);
            }


            conexion.Close();
            return listModel;
        }

    }
}